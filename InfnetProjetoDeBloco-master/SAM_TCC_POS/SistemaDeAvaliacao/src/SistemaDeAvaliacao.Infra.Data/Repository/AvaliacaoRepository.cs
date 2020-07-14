using SistemaDeAvaliacao.Domain.Entities;
using SistemaDeAvaliacao.Domain.Interface.Repository;
using SistemaDeAvaliacao.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SistemaDeAvaliacao.Infra.Data.Repository
{
    public class AvaliacaoRepository : RepositoryBase<Avaliacao>, IAvaliacaoRepository
    {
        public AvaliacaoRepository(SistemaDeAvaliacaoDbContext context) : base(context)
        {
        }

        public Avaliacao UpdateAvaliacaoQuestoes(Avaliacao avaliacao)
        {
            var avaliacaoAtual = Db.Avaliacoes.Single(a => a.AvaliacaoId == avaliacao.AvaliacaoId);
            var entry = Db.Entry(avaliacaoAtual);
            
            entry.Collection(at => at.Questoes).Load();
            avaliacaoAtual.Questoes.Clear();

            avaliacaoAtual.Questoes = avaliacao.Questoes;
            avaliacaoAtual.Curso = avaliacao.Curso;
            avaliacaoAtual.Objetivo = avaliacao.Objetivo;
            avaliacaoAtual.DataInicio = avaliacao.DataInicio;
            avaliacaoAtual.DataTermino = avaliacaoAtual.DataTermino;
            avaliacaoAtual.Curso = avaliacao.Curso;
            avaliacaoAtual.TurmaId = avaliacao.TurmaId;
            avaliacaoAtual.Professor = avaliacao.Professor;

            DbSet.Attach(avaliacaoAtual);
            Db.Entry(avaliacaoAtual).State = EntityState.Modified;
            return avaliacaoAtual;
        }
        
        public Avaliacao FindByCodigoDeAcesso(Guid codigoDeAcesso)
        {
            return Db.Avaliacoes.SingleOrDefault(a => a.CodigoAcesso == codigoDeAcesso);
        }
    }
}
