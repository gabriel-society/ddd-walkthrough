﻿// <auto-generated />
using System;
using Escolas.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Escolas.API.Migrations
{
    [DbContext(typeof(EscolasContexto))]
    [Migration("20200813002442_versao_com_calculo_desconto")]
    partial class versao_com_calculo_desconto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

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

                    b.Property<string>("TipoPagamento")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

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

                    b.Property<int>("TotalInscritos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("Escolas.Dominio.Alunos.Aluno", b =>
                {
                    b.OwnsOne("Escolas.Dominio.Alunos.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<string>("AlunoId")
                                .HasColumnType("varchar(37)");

                            b1.Property<string>("Bairro")
                                .HasColumnType("varchar(60)");

                            b1.Property<string>("Cep")
                                .HasColumnType("varchar(20)");

                            b1.Property<string>("Cidade")
                                .HasColumnType("varchar(60)");

                            b1.Property<string>("Complemento")
                                .HasColumnType("varchar(40)");

                            b1.Property<int>("DistanciaAteEscola")
                                .HasColumnType("int");

                            b1.Property<string>("Numero")
                                .HasColumnType("varchar(20)");

                            b1.Property<string>("Rua")
                                .HasColumnType("varchar(60)");

                            b1.HasKey("AlunoId");

                            b1.ToTable("Alunos");

                            b1.WithOwner()
                                .HasForeignKey("AlunoId");
                        });
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
                    b.HasOne("Escolas.Dominio.Alunos.Aluno", "Aluno")
                        .WithMany("Inscricoes")
                        .HasForeignKey("AlunoId");

                    b.HasOne("Escolas.Dominio.Turmas.Turma", "Turma")
                        .WithMany()
                        .HasForeignKey("TurmaId");
                });

            modelBuilder.Entity("Escolas.Dominio.Turmas.Turma", b =>
                {
                    b.OwnsOne("Escolas.Dominio.Turmas.ConfiguracaoInscricao", "ConfiguracaoInscricao", b1 =>
                        {
                            b1.Property<string>("TurmaId")
                                .HasColumnType("varchar(37)");

                            b1.Property<int>("DuracaoEmMeses")
                                .HasColumnType("int");

                            b1.Property<int>("IdadeMinima")
                                .HasColumnType("int");

                            b1.Property<int>("LimiteAlunos")
                                .HasColumnType("int");

                            b1.HasKey("TurmaId");

                            b1.ToTable("Turmas");

                            b1.WithOwner()
                                .HasForeignKey("TurmaId");
                        });

                    b.OwnsOne("Escolas.Dominio.Turmas.ConfiguracaoValor", "ConfiguracaoValor", b1 =>
                        {
                            b1.Property<string>("TurmaId")
                                .HasColumnType("varchar(37)");

                            b1.Property<decimal>("DescontoCriancas")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<decimal>("DescontoDistancia")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<decimal>("DescontoMaximo")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<decimal>("DescontoMulheres")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<decimal>("DescontoPagamentoAntecipado")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<decimal>("ValorMensal")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("TurmaId");

                            b1.ToTable("Turmas");

                            b1.WithOwner()
                                .HasForeignKey("TurmaId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
