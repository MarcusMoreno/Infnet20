using CourseRating.Application.Interface;
using CourseRating.Domain.Entities;
using CourseRating.Domain.Interfaces.Services;

namespace CourseRating.Application.Services
{
    public  class ModuloAppService : AppServiceBase<Modulo>, IModuloAppService
    {
        private readonly IModuloService ModuloService;

        public ModuloAppService(IModuloService serviceBase) : base(serviceBase)
        {
            ModuloService = serviceBase;
        }
    }
}
