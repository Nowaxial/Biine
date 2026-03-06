using Microsoft.EntityFrameworkCore;

namespace Biine.API.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
}
