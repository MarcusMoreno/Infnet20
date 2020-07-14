using System;
using SistemaDeAvaliacao.Infra.CrossCutting.Identity.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SistemaDeAvaliacao.Infra.CrossCutting.Identity.Context
{
    /// <summary>
    /// Contexto do Identity, não da Infra
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public ApplicationDbContext()
            : base("SistemaDeAvaliacaoIdentityDb", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}