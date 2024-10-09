﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaBarbearia.Models;

#nullable disable

namespace SistemaBarbearia.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20241008214008_alteracaoCaixaModel3")]
    partial class alteracaoCaixaModel3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SistemaBarbearia.Models.Agenda", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("barbeiroID")
                        .HasColumnType("int");

                    b.Property<int?>("caixaid")
                        .HasColumnType("int");

                    b.Property<int>("clienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("diaAgendado")
                        .HasColumnType("datetime2");

                    b.Property<int>("horarioId")
                        .HasColumnType("int");

                    b.Property<int>("idCaixa")
                        .HasColumnType("int");

                    b.Property<double>("tempo_total")
                        .HasColumnType("float");

                    b.Property<int>("trabalhoStatus")
                        .HasColumnType("int");

                    b.Property<double>("valor_total")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("barbeiroID");

                    b.HasIndex("caixaid");

                    b.HasIndex("clienteId");

                    b.HasIndex("horarioId");

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("SistemaBarbearia.Models.Barbeiro", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.HasKey("id");

                    b.ToTable("Barbeiros");
                });

            modelBuilder.Entity("SistemaBarbearia.Models.Caixa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateOnly>("dia")
                        .HasColumnType("date");

                    b.Property<double>("lucro")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("Caixas");
                });

            modelBuilder.Entity("SistemaBarbearia.Models.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.HasKey("id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("SistemaBarbearia.Models.Horario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<TimeOnly>("fim")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("inicio")
                        .HasColumnType("time");

                    b.HasKey("id");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("SistemaBarbearia.Models.Servico", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("minutos")
                        .HasColumnType("int");

                    b.Property<double>("valor")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("SistemaBarbearia.Models.ServicoAgenda", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("agendaID")
                        .HasColumnType("int");

                    b.Property<int>("desconto")
                        .HasColumnType("int");

                    b.Property<int>("servicoID")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("agendaID");

                    b.HasIndex("servicoID");

                    b.ToTable("ServicosAgendas");
                });

            modelBuilder.Entity("SistemaBarbearia.Models.Agenda", b =>
                {
                    b.HasOne("SistemaBarbearia.Models.Barbeiro", "barbeiro")
                        .WithMany()
                        .HasForeignKey("barbeiroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaBarbearia.Models.Caixa", "caixa")
                        .WithMany("Agendas")
                        .HasForeignKey("caixaid");

                    b.HasOne("SistemaBarbearia.Models.Cliente", "cliente")
                        .WithMany("Agendas")
                        .HasForeignKey("clienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaBarbearia.Models.Horario", "horario")
                        .WithMany()
                        .HasForeignKey("horarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("barbeiro");

                    b.Navigation("caixa");

                    b.Navigation("cliente");

                    b.Navigation("horario");
                });

            modelBuilder.Entity("SistemaBarbearia.Models.ServicoAgenda", b =>
                {
                    b.HasOne("SistemaBarbearia.Models.Agenda", "agenda")
                        .WithMany("servicosAgendas")
                        .HasForeignKey("agendaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaBarbearia.Models.Servico", "Servico")
                        .WithMany("servicosAgendas")
                        .HasForeignKey("servicoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Servico");

                    b.Navigation("agenda");
                });

            modelBuilder.Entity("SistemaBarbearia.Models.Agenda", b =>
                {
                    b.Navigation("servicosAgendas");
                });

            modelBuilder.Entity("SistemaBarbearia.Models.Caixa", b =>
                {
                    b.Navigation("Agendas");
                });

            modelBuilder.Entity("SistemaBarbearia.Models.Cliente", b =>
                {
                    b.Navigation("Agendas");
                });

            modelBuilder.Entity("SistemaBarbearia.Models.Servico", b =>
                {
                    b.Navigation("servicosAgendas");
                });
#pragma warning restore 612, 618
        }
    }
}
