namespace CourseRating.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Matricula = c.Int(nullable: false),
                        Email = c.String(),
                        Nome = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Cpf = c.String(),
                        Sexo = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Senha = c.String(),
                        TipoAcessoUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Avaliacao",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Codigo = c.String(),
                        ObjetivoAvaliacao = c.String(),
                        DataInicio = c.DateTime(nullable: false),
                        DataTermino = c.DateTime(nullable: false),
                        Concluida = c.Boolean(nullable: false),
                        Curso_Id = c.String(maxLength: 128),
                        Professor_Id = c.Int(),
                        Questionario_Id = c.Int(),
                        Respondete_Id = c.Int(),
                        Turma_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Curso", t => t.Curso_Id)
                .ForeignKey("dbo.Professor", t => t.Professor_Id)
                .ForeignKey("dbo.Questionario", t => t.Questionario_Id)
                .ForeignKey("dbo.Aluno", t => t.Respondete_Id)
                .ForeignKey("dbo.Turma", t => t.Turma_Id)
                .Index(t => t.Curso_Id)
                .Index(t => t.Professor_Id)
                .Index(t => t.Questionario_Id)
                .Index(t => t.Respondete_Id)
                .Index(t => t.Turma_Id);
            
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Professor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Coordernador = c.Boolean(nullable: false),
                        Nome = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Cpf = c.String(),
                        Sexo = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Questionario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Detalhe = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Turma",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PeriodoMinistradoInicio = c.DateTime(nullable: false),
                        PeriodoMinistradoFim = c.DateTime(nullable: false),
                        Modulo_Id = c.String(maxLength: 128),
                        Professor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Modulo", t => t.Modulo_Id)
                .ForeignKey("dbo.Professor", t => t.Professor_Id)
                .Index(t => t.Modulo_Id)
                .Index(t => t.Professor_Id);
            
            CreateTable(
                "dbo.Modulo",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Nome = c.String(),
                        DataInicio = c.DateTime(nullable: false),
                        DataTermino = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Avaliacao", "Turma_Id", "dbo.Turma");
            DropForeignKey("dbo.Turma", "Professor_Id", "dbo.Professor");
            DropForeignKey("dbo.Turma", "Modulo_Id", "dbo.Modulo");
            DropForeignKey("dbo.Avaliacao", "Respondete_Id", "dbo.Aluno");
            DropForeignKey("dbo.Avaliacao", "Questionario_Id", "dbo.Questionario");
            DropForeignKey("dbo.Avaliacao", "Professor_Id", "dbo.Professor");
            DropForeignKey("dbo.Professor", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.Avaliacao", "Curso_Id", "dbo.Curso");
            DropForeignKey("dbo.Aluno", "Usuario_Id", "dbo.Usuario");
            DropIndex("dbo.Turma", new[] { "Professor_Id" });
            DropIndex("dbo.Turma", new[] { "Modulo_Id" });
            DropIndex("dbo.Professor", new[] { "Usuario_Id" });
            DropIndex("dbo.Avaliacao", new[] { "Turma_Id" });
            DropIndex("dbo.Avaliacao", new[] { "Respondete_Id" });
            DropIndex("dbo.Avaliacao", new[] { "Questionario_Id" });
            DropIndex("dbo.Avaliacao", new[] { "Professor_Id" });
            DropIndex("dbo.Avaliacao", new[] { "Curso_Id" });
            DropIndex("dbo.Aluno", new[] { "Usuario_Id" });
            DropTable("dbo.Modulo");
            DropTable("dbo.Turma");
            DropTable("dbo.Questionario");
            DropTable("dbo.Professor");
            DropTable("dbo.Curso");
            DropTable("dbo.Avaliacao");
            DropTable("dbo.Usuario");
            DropTable("dbo.Aluno");
        }
    }
}
