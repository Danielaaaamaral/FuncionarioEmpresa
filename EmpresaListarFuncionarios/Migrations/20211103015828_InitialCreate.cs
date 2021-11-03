using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpresaListarFuncionarios.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "Funcionario");

            migrationBuilder.AddColumn<int>(
                name: "IdCargo",
                table: "Funcionario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Empresa",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Empresa",
                maxLength: 9,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Empresa",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Empresa",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Empresa",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Empresa",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "Empresa",
                maxLength: 2,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmpresaFuncionario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaFuncionario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpresaFuncionario");

            migrationBuilder.DropColumn(
                name: "IdCargo",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Uf",
                table: "Empresa");

            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    IdEndereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bairro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Uf = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.IdEndereco);
                });
        }
    }
}
