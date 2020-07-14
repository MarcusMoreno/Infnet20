namespace AvaliacaoInfnet.Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvaliacaoResposta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Idperfil = c.Int(nullable: false),
                        IdRespondente = c.Int(nullable: false),
                        IdAvaliacao = c.Int(nullable: false),
                        Entrevistado_Id = c.Int(),
                        Pergunta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entrevistado", t => t.Entrevistado_Id)
                .ForeignKey("dbo.Pergunta", t => t.Pergunta_Id)
                .Index(t => t.Entrevistado_Id)
                .Index(t => t.Pergunta_Id);
            
            CreateTable(
                "dbo.PerguntaRespostaAvaliacao",
                c => new
                    {
                        IdTipoResposta = c.Int(nullable: false, identity: true),
                        IdAvalicao = c.Int(nullable: false),
                        IdPergunta = c.Int(nullable: false),
                        AvaliacaoResposta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.IdTipoResposta)
                .ForeignKey("dbo.AvaliacaoResposta", t => t.AvaliacaoResposta_Id)
                .Index(t => t.AvaliacaoResposta_Id);
            
            CreateTable(
                "dbo.TipoResposta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 100, unicode: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pergunta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 100, unicode: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Avaliacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 100, unicode: false),
                        Titulo = c.String(maxLength: 100, unicode: false),
                        Status = c.Boolean(nullable: false),
                        DataInicio = c.DateTime(nullable: false),
                        DataFim = c.DateTime(nullable: false),
                        Perfil_Id = c.Int(),
                        Entrevistado_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Perfil", t => t.Perfil_Id)
                .ForeignKey("dbo.Entrevistado", t => t.Entrevistado_Id)
                .Index(t => t.Perfil_Id)
                .Index(t => t.Entrevistado_Id);
            
            CreateTable(
                "dbo.Perfil",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 100, unicode: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Entrevistado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Telefone = c.String(maxLength: 100, unicode: false),
                        Status = c.Boolean(nullable: false),
                        Senha = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoRespostaAvaliacaoResposta",
                c => new
                    {
                        TipoResposta_Id = c.Int(nullable: false),
                        AvaliacaoResposta_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TipoResposta_Id, t.AvaliacaoResposta_Id })
                .ForeignKey("dbo.TipoResposta", t => t.TipoResposta_Id)
                .ForeignKey("dbo.AvaliacaoResposta", t => t.AvaliacaoResposta_Id)
                .Index(t => t.TipoResposta_Id)
                .Index(t => t.AvaliacaoResposta_Id);
            
            CreateTable(
                "dbo.PerfilEntrevistado",
                c => new
                    {
                        Perfil_Id = c.Int(nullable: false),
                        Entrevistado_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Perfil_Id, t.Entrevistado_Id })
                .ForeignKey("dbo.Perfil", t => t.Perfil_Id)
                .ForeignKey("dbo.Entrevistado", t => t.Entrevistado_Id)
                .Index(t => t.Perfil_Id)
                .Index(t => t.Entrevistado_Id);
            
            CreateTable(
                "dbo.AvaliacaoPergunta",
                c => new
                    {
                        Avaliacao_Id = c.Int(nullable: false),
                        Pergunta_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Avaliacao_Id, t.Pergunta_Id })
                .ForeignKey("dbo.Avaliacao", t => t.Avaliacao_Id)
                .ForeignKey("dbo.Pergunta", t => t.Pergunta_Id)
                .Index(t => t.Avaliacao_Id)
                .Index(t => t.Pergunta_Id);
            
            CreateTable(
                "dbo.PerguntaTipoResposta",
                c => new
                    {
                        Pergunta_Id = c.Int(nullable: false),
                        TipoResposta_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pergunta_Id, t.TipoResposta_Id })
                .ForeignKey("dbo.Pergunta", t => t.Pergunta_Id)
                .ForeignKey("dbo.TipoResposta", t => t.TipoResposta_Id)
                .Index(t => t.Pergunta_Id)
                .Index(t => t.TipoResposta_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PerguntaTipoResposta", "TipoResposta_Id", "dbo.TipoResposta");
            DropForeignKey("dbo.PerguntaTipoResposta", "Pergunta_Id", "dbo.Pergunta");
            DropForeignKey("dbo.AvaliacaoResposta", "Pergunta_Id", "dbo.Pergunta");
            DropForeignKey("dbo.AvaliacaoPergunta", "Pergunta_Id", "dbo.Pergunta");
            DropForeignKey("dbo.AvaliacaoPergunta", "Avaliacao_Id", "dbo.Avaliacao");
            DropForeignKey("dbo.PerfilEntrevistado", "Entrevistado_Id", "dbo.Entrevistado");
            DropForeignKey("dbo.PerfilEntrevistado", "Perfil_Id", "dbo.Perfil");
            DropForeignKey("dbo.Avaliacao", "Entrevistado_Id", "dbo.Entrevistado");
            DropForeignKey("dbo.AvaliacaoResposta", "Entrevistado_Id", "dbo.Entrevistado");
            DropForeignKey("dbo.Avaliacao", "Perfil_Id", "dbo.Perfil");
            DropForeignKey("dbo.TipoRespostaAvaliacaoResposta", "AvaliacaoResposta_Id", "dbo.AvaliacaoResposta");
            DropForeignKey("dbo.TipoRespostaAvaliacaoResposta", "TipoResposta_Id", "dbo.TipoResposta");
            DropForeignKey("dbo.PerguntaRespostaAvaliacao", "AvaliacaoResposta_Id", "dbo.AvaliacaoResposta");
            DropIndex("dbo.PerguntaTipoResposta", new[] { "TipoResposta_Id" });
            DropIndex("dbo.PerguntaTipoResposta", new[] { "Pergunta_Id" });
            DropIndex("dbo.AvaliacaoPergunta", new[] { "Pergunta_Id" });
            DropIndex("dbo.AvaliacaoPergunta", new[] { "Avaliacao_Id" });
            DropIndex("dbo.PerfilEntrevistado", new[] { "Entrevistado_Id" });
            DropIndex("dbo.PerfilEntrevistado", new[] { "Perfil_Id" });
            DropIndex("dbo.TipoRespostaAvaliacaoResposta", new[] { "AvaliacaoResposta_Id" });
            DropIndex("dbo.TipoRespostaAvaliacaoResposta", new[] { "TipoResposta_Id" });
            DropIndex("dbo.Avaliacao", new[] { "Entrevistado_Id" });
            DropIndex("dbo.Avaliacao", new[] { "Perfil_Id" });
            DropIndex("dbo.PerguntaRespostaAvaliacao", new[] { "AvaliacaoResposta_Id" });
            DropIndex("dbo.AvaliacaoResposta", new[] { "Pergunta_Id" });
            DropIndex("dbo.AvaliacaoResposta", new[] { "Entrevistado_Id" });
            DropTable("dbo.PerguntaTipoResposta");
            DropTable("dbo.AvaliacaoPergunta");
            DropTable("dbo.PerfilEntrevistado");
            DropTable("dbo.TipoRespostaAvaliacaoResposta");
            DropTable("dbo.Entrevistado");
            DropTable("dbo.Perfil");
            DropTable("dbo.Avaliacao");
            DropTable("dbo.Pergunta");
            DropTable("dbo.TipoResposta");
            DropTable("dbo.PerguntaRespostaAvaliacao");
            DropTable("dbo.AvaliacaoResposta");
        }
    }
}
