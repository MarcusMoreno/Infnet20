using ContosoDDD.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ContosoDDD.Infraestrutura.Persistencia.Configurações
{
    public class AlunoConfiguracao : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(a => a.Id);
            builder.ToTable("Alunos");
            builder.Property(a => a.DataMatricula)
                .HasColumnName("Matricula")
                .IsRequired()
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()");
            builder.Property(a => a.DataCadastro)
                .HasColumnName("Cadastro")
                .IsRequired()
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()");
        }
    }
}
