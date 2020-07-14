using CourseRating.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseRating.Data.Config
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
        }
    }
}
