using CourseRating.Domain.Entities;
using CourseRating.Domain.Interfaces.Repositories;
using CourseRating.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseRating.Domain.Services
{
    public class ProfessorService : ServiceBase<Professor>, IProfessorService
    {
        private readonly IProfessorRepository ProfessorRepository;

        public ProfessorService(IProfessorRepository repository) : base(repository)
        {
            ProfessorRepository = repository;
        }
    }
}
