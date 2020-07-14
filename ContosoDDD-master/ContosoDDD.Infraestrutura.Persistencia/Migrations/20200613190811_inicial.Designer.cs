﻿// <auto-generated />
using System;
using ContosoDDD.Infraestrutura.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContosoDDD.Infraestrutura.Persistencia.Migrations
{
    [DbContext(typeof(ContosoDbContext))]
    [Migration("20200613190811_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ContosoDDD.Dominio.Entidade.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Cadastro")
                        .HasColumnType("Date")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<DateTime>("DataMatricula")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Matricula")
                        .HasColumnType("Date")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("UltimoAcesso")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("ContosoDDD.Dominio.Entidade.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Creditos")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titulo")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("ContosoDDD.Dominio.Entidade.Matricula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int?>("Conceito")
                        .HasColumnType("int");

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("CursoId");

                    b.ToTable("Matriculas");
                });

            modelBuilder.Entity("ContosoDDD.Dominio.Entidade.Matricula", b =>
                {
                    b.HasOne("ContosoDDD.Dominio.Entidade.Aluno", "Aluno")
                        .WithMany("Matriculas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContosoDDD.Dominio.Entidade.Curso", "Curso")
                        .WithMany("Matriculas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
