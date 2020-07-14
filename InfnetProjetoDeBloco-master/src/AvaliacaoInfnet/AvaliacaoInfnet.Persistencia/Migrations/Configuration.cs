namespace AvaliacaoInfnet.Persistencia.Migrations
{
    using AvaliacaoInfnet.Domain;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.AvaliacaoInfnetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context.AvaliacaoInfnetContext context)
        {
            //TODO: inlcuir no tipoResposta os padroes do likert. 


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.TipoRespostas.AddOrUpdate(
                p => p.Descricao,
                new TipoResposta { Descricao = "Concordo totalmente" },
                new TipoResposta { Descricao = "Concordo" },
                new TipoResposta { Descricao = "Não concordo nem discordo" },
                new TipoResposta { Descricao = "Discordo" },
                new TipoResposta { Descricao = "Discordo totalmente" },
                new TipoResposta { Descricao = "Não sei avaliar" }
            );
        }
    }
}
