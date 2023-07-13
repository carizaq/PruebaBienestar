using Bienestar.Entities;
using Bienestar.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Bienestar.Data.Configurations
{
    public class PadreConfig : IEntityTypeConfiguration<Padre>
    {
        public void Configure(EntityTypeBuilder<Padre> builder)
        {
            builder.HasIndex(p => p.UsuarioId);
        }
    }
}
