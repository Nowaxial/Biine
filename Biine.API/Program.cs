using Biine.API.Data;
using Biine.API.Seeders;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// ── Seeder mode: dotnet run -- --seed-restaurants ─────────────────────────────
if (args.Contains("--seed-restaurants"))
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

    var seedApp = builder.Build();
    using var scope = seedApp.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var apiKey = builder.Configuration["GooglePlaces:ApiKey"]
        ?? throw new InvalidOperationException("GooglePlaces:ApiKey is not set in user-secrets");

    await RestaurantSeeder.SeedAsync(db, apiKey);
    return;
}
// ─────────────────────────────────────────────────────────────────────────────

// Database
// EnableRetryOnFailure handles Neon cold-start transient failures (free tier wakes up slowly)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        npgsql => npgsql.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(5), errorCodesToAdd: null)
    ));

// CORS — allow frontend origins (Vercel prod + local dev)
builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:4321",      // Astro dev server
                "http://localhost:3000",
                "https://*.vercel.app",       // Vercel preview/prod
                builder.Configuration["AllowedOrigins"] ?? "" // env override
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Rate limiting — 30 requests/minute per session ID (or IP fallback)
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("PerSession", limiterOptions =>
    {
        limiterOptions.Window = TimeSpan.FromMinutes(1);
        limiterOptions.PermitLimit = 30;
        limiterOptions.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        limiterOptions.QueueLimit = 0;
    });

    options.RejectionStatusCode = 429;
});

// Add services to the container.
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Frontend");

app.UseRateLimiter();

app.UseAuthorization();

app.MapControllers().RequireRateLimiting("PerSession");

app.Run();
