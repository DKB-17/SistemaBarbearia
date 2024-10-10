using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaBarbearia.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barbeiros",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbeiros", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Caixas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dia = table.Column<DateOnly>(type: "date", nullable: false),
                    lucro = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caixas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    inicio = table.Column<TimeOnly>(type: "time", nullable: false),
                    fim = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    valor = table.Column<double>(type: "float", nullable: false),
                    minutos = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    barbeiroID = table.Column<int>(type: "int", nullable: false),
                    clienteId = table.Column<int>(type: "int", nullable: false),
                    horarioId = table.Column<int>(type: "int", nullable: false),
                    diaAgendado = table.Column<DateOnly>(type: "date", nullable: false),
                    trabalhoStatus = table.Column<int>(type: "int", nullable: false),
                    valor_total = table.Column<double>(type: "float", nullable: false),
                    tempo_total = table.Column<double>(type: "float", nullable: false),
                    idCaixa = table.Column<int>(type: "int", nullable: false),
                    caixaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Agendas_Barbeiros_barbeiroID",
                        column: x => x.barbeiroID,
                        principalTable: "Barbeiros",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendas_Caixas_caixaid",
                        column: x => x.caixaid,
                        principalTable: "Caixas",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Agendas_Clientes_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendas_Horarios_horarioId",
                        column: x => x.horarioId,
                        principalTable: "Horarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicosAgendas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    desconto = table.Column<int>(type: "int", nullable: false),
                    agendaID = table.Column<int>(type: "int", nullable: false),
                    servicoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicosAgendas", x => x.id);
                    table.ForeignKey(
                        name: "FK_ServicosAgendas_Agendas_agendaID",
                        column: x => x.agendaID,
                        principalTable: "Agendas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicosAgendas_Servicos_servicoID",
                        column: x => x.servicoID,
                        principalTable: "Servicos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_barbeiroID",
                table: "Agendas",
                column: "barbeiroID");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_caixaid",
                table: "Agendas",
                column: "caixaid");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_clienteId",
                table: "Agendas",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_horarioId",
                table: "Agendas",
                column: "horarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicosAgendas_agendaID",
                table: "ServicosAgendas",
                column: "agendaID");

            migrationBuilder.CreateIndex(
                name: "IX_ServicosAgendas_servicoID",
                table: "ServicosAgendas",
                column: "servicoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicosAgendas");

            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Barbeiros");

            migrationBuilder.DropTable(
                name: "Caixas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Horarios");
        }
    }
}
