using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biine.API.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonaName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PersonaNameEn",
                table: "Recipes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonaNameSv",
                table: "Recipes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PersonaNameEn", "PersonaNameSv" },
                values: new object[] { "The Roman Heartbreaker", "Den Romerska Hjärtekrossaren" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PersonaNameEn", "PersonaNameSv" },
                values: new object[] { "The Sunset Wildling", "Solterrassens Vildhjärta" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PersonaNameEn", "PersonaNameSv" },
                values: new object[] { "The Balanced Soulmate", "Den Balanserade Soulmate" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PersonaNameEn", "PersonaNameSv" },
                values: new object[] { "The Velvet Temptress", "Den Sammetslenlige" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PersonaNameEn", "PersonaNameSv" },
                values: new object[] { "The Elegant Mystery", "Det Eleganta Mysteriet" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PersonaNameEn", "PersonaNameSv" },
                values: new object[] { "The Reliable Package", "Det Pålitliga Paketet" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PersonaNameEn", "PersonaNameSv" },
                values: new object[] { "The Complex Dream", "Den Komplexa Drömmen" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PersonaNameEn", "PersonaNameSv" },
                values: new object[] { "The Mediterranean Charmer", "Medelhavscharmen" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PersonaNameEn", "PersonaNameSv" },
                values: new object[] { "The Timeless Icon", "Den Tidlösa Ikonen" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PersonaNameEn", "PersonaNameSv" },
                values: new object[] { "The Soulful Night", "Den Själsfulla Natten" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PersonaNameEn", "PersonaNameSv" },
                values: new object[] { "The Spicy Secret", "Den Heta Hemligheten" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "PersonaNameEn", "PersonaNameSv" },
                values: new object[] { "The Nation's Favourite", "Nationens Favorit" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "PersonaNameEn", "PersonaNameSv" },
                values: new object[] { "The Little Secret Keeper", "Den Lilla Hemlighållaren" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "PersonaNameEn", "PersonaNameSv" },
                values: new object[] { "The Golden Suitor", "Den Gyllene Friaren" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "PersonaNameEn", "PersonaNameSv" },
                values: new object[] { "Berlin's Best Friend", "Berlins Bästa Vän" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "PersonaNameEn", "PersonaNameSv" },
                values: new object[] { "The Herbaceous Seducer", "Den Gröna Förföraren" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "PersonaNameEn", "PersonaNameSv" },
                values: new object[] { "The Colorful Perfectionist", "Den Färgglada Ordningsfantasten" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "PersonaNameEn", "PersonaNameSv" },
                values: new object[] { "The Patient Masterpiece", "Det Tålmodiga Mästerstycket" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "PersonaNameEn", "PersonaNameSv" },
                values: new object[] { "The Undisputed Party King", "Festens Obestridde Konung" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "PersonaNameEn", "PersonaNameSv" },
                values: new object[] { "The Sunday Morning Heartbeat", "Söndagsmorgonens Hjärtslaget" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "PersonaNameEn", "PersonaNameSv" },
                values: new object[] { "The Comforting Icon", "Den Trygga Ikonen" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "PersonaNameEn", "PersonaNameSv" },
                values: new object[] { "The Party's Secret Weapon", "Kalasets Hemliga Vapen" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "PersonaNameEn", "PersonaNameSv" },
                values: new object[] { "The Reliable Everyday Heart", "Det Pålitliga Vardagshjärtat" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "PersonaNameEn", "PersonaNameSv" },
                values: new object[] { "The Retro Comfort Package", "Det Retroa Tröstpaketet" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "PersonaNameEn", "PersonaNameSv" },
                values: new object[] { "The Gentle Secret Whisperer", "Den Mjuka Hemlighetsberättaren" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonaNameEn",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "PersonaNameSv",
                table: "Recipes");
        }
    }
}
