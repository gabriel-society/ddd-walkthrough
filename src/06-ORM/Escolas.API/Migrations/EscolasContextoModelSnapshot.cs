﻿// <auto-generated />
using System;
using Escolas.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Escolas.API.Migrations
{
    [DbContext(typeof(EscolasContexto))]
    partial class EscolasContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Escolas.Dominio.Alunos.Aluno", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(37)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("Escolas.Dominio.Alunos.Divida", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(37)");

                    b.Property<string>("AlunoId")
                        .HasColumnType("varchar(37)");

                    b.Property<string>("InscricaoId")
                        .HasColumnType("varchar(37)");

                    b.Property<string>("Situacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Vencimento")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("InscricaoId");

                    b.ToTable("Dividas");
                });

            modelBuilder.Entity("Escolas.Dominio.Alunos.Inscricao", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(37)");

                    b.Property<string>("AlunoId")
                        .HasColumnType("varchar(37)");

                    b.Property<DateTime>("InscritoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("TurmaId")
                        .HasColumnType("varchar(37)");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Inscricoes");
                });

            modelBuilder.Entity("Escolas.Dominio.Turmas.Turma", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(37)");

                    b.Property<bool>("Aberta")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("DuracaoEmMeses")
                        .HasColumnType("int");

                    b.Property<int>("IdadeMinima")
                        .HasColumnType("int");

                    b.Property<int>("LimiteAlunos")
                        .HasColumnType("int");

                    b.Property<int>("TotalInscritos")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorMensal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("Escolas.Dominio.Alunos.Divida", b =>
                {
                    b.HasOne("Escolas.Dominio.Alunos.Aluno", null)
                        .WithMany("Dividas")
                        .HasForeignKey("AlunoId");

                    b.HasOne("Escolas.Dominio.Alunos.Inscricao", null)
                        .WithMany()
                        .HasForeignKey("InscricaoId");
                });

            modelBuilder.Entity("Escolas.Dominio.Alunos.Inscricao", b =>
                {
                    b.HasOne("Escolas.Dominio.Alunos.Aluno", null)
                        .WithMany("Inscricoes")
                        .HasForeignKey("AlunoId");

                    b.HasOne("Escolas.Dominio.Turmas.Turma", "Turma")
                        .WithMany()
                        .HasForeignKey("TurmaId");
                });
#pragma warning restore 612, 618
        }
    }
}
