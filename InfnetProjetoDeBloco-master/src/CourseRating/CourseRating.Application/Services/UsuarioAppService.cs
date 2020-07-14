using CourseRating.Application.Interface;
using CourseRating.Domain.Entities;
using CourseRating.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseRating.Application.Services
{
   public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService UsuarioService;

        public UsuarioAppService(IUsuarioService serviceBase) : base(serviceBase)
        {
            UsuarioService = serviceBase;
        }
    }
}
