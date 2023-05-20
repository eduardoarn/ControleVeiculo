using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleVeiculo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motoristas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PrimeiroNome = table.Column<string>(type: "text", nullable: false),
                    SobreNome = table.Column<string>(type: "text", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uuid", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motoristas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Marca = table.Column<string>(type: "text", nullable: false),
                    Modelo = table.Column<string>(type: "text", nullable: false),
                    Placa = table.Column<string>(type: "text", nullable: false),
                    Localidade = table.Column<string>(type: "text", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uuid", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Abastecimentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MotoristaId = table.Column<Guid>(type: "uuid", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uuid", nullable: false),
                    KM = table.Column<int>(type: "integer", nullable: false),
                    Litros = table.Column<double>(type: "double precision", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uuid", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abastecimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abastecimentos_Motoristas_MotoristaId",
                        column: x => x.MotoristaId,
                        principalTable: "Motoristas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Abastecimentos_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotoristasVeiculos",
                columns: table => new
                {
                    VeiculoId = table.Column<Guid>(type: "uuid", nullable: false),
                    MotoristaId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uuid", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotoristasVeiculos", x => new { x.MotoristaId, x.VeiculoId });
                    table.ForeignKey(
                        name: "FK_MotoristasVeiculos_Motoristas_MotoristaId",
                        column: x => x.MotoristaId,
                        principalTable: "Motoristas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MotoristasVeiculos_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TurnoLancamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MotoristaId = table.Column<Guid>(type: "uuid", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uuid", nullable: false),
                    KM = table.Column<int>(type: "integer", nullable: false),
                    Litros = table.Column<double>(type: "double precision", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uuid", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurnoLancamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TurnoLancamentos_Motoristas_MotoristaId",
                        column: x => x.MotoristaId,
                        principalTable: "Motoristas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TurnoLancamentos_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abastecimentos_MotoristaId",
                table: "Abastecimentos",
                column: "MotoristaId");

            migrationBuilder.CreateIndex(
                name: "IX_Abastecimentos_VeiculoId",
                table: "Abastecimentos",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_MotoristasVeiculos_VeiculoId",
                table: "MotoristasVeiculos",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_TurnoLancamentos_MotoristaId",
                table: "TurnoLancamentos",
                column: "MotoristaId");

            migrationBuilder.CreateIndex(
                name: "IX_TurnoLancamentos_VeiculoId",
                table: "TurnoLancamentos",
                column: "VeiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abastecimentos");

            migrationBuilder.DropTable(
                name: "MotoristasVeiculos");

            migrationBuilder.DropTable(
                name: "TurnoLancamentos");

            migrationBuilder.DropTable(
                name: "Motoristas");

            migrationBuilder.DropTable(
                name: "Veiculos");
        }
    }
}
