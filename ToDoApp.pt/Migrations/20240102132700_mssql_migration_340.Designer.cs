﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoApp.pt.Models;

#nullable disable

namespace ToDoApp.pt.Migrations
{
    [DbContext(typeof(ToDoContext))]
    [Migration("20240102132700_mssql_migration_340")]
    partial class mssql_migration_340
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ToDoApp.pt.Models.Categoria", b =>
                {
                    b.Property<string>("CategoriaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            CategoriaId = "tarefa",
                            Nome = "Tarefa"
                        },
                        new
                        {
                            CategoriaId = "casa",
                            Nome = "Casa"
                        },
                        new
                        {
                            CategoriaId = "ex",
                            Nome = "Exercicio"
                        },
                        new
                        {
                            CategoriaId = "compra",
                            Nome = "Compra"
                        },
                        new
                        {
                            CategoriaId = "contato",
                            Nome = "Contato"
                        });
                });

            modelBuilder.Entity("ToDoApp.pt.Models.Situacao", b =>
                {
                    b.Property<string>("SituacaoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SituacaoId");

                    b.ToTable("Situacoes");

                    b.HasData(
                        new
                        {
                            SituacaoId = "aberto",
                            Nome = "Aberto"
                        },
                        new
                        {
                            SituacaoId = "concluido",
                            Nome = "Concluido"
                        });
                });

            modelBuilder.Entity("ToDoApp.pt.Models.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoriaId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SituacaoId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("Vencimento")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("SituacaoId");

                    b.ToTable("ToDos");
                });

            modelBuilder.Entity("ToDoApp.pt.Models.ToDo", b =>
                {
                    b.HasOne("ToDoApp.pt.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToDoApp.pt.Models.Situacao", "Situacao")
                        .WithMany()
                        .HasForeignKey("SituacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Situacao");
                });
#pragma warning restore 612, 618
        }
    }
}
