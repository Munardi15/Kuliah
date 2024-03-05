using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kuliah.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dosen",
                columns: table => new
                {
                    Nip = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama_Dosen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosen", x => x.Nip);
                });

            migrationBuilder.CreateTable(
                name: "Mahasiswa",
                columns: table => new
                {
                    Nim = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama_Msh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tgl_Lahir = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Jenis_Kelamin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mahasiswa", x => x.Nim);
                });

            migrationBuilder.CreateTable(
                name: "Marakuliah",
                columns: table => new
                {
                    Kode_MK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama_MK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marakuliah", x => x.Kode_MK);
                });

            migrationBuilder.CreateTable(
                name: "Perkuliahan",
                columns: table => new
                {
                    Nim = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kode_MK = table.Column<int>(type: "int", nullable: false),
                    Nip = table.Column<int>(type: "int", nullable: false),
                    Nilai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perkuliahan", x => x.Nim);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dosen");

            migrationBuilder.DropTable(
                name: "Mahasiswa");

            migrationBuilder.DropTable(
                name: "Marakuliah");

            migrationBuilder.DropTable(
                name: "Perkuliahan");
        }
    }
}
