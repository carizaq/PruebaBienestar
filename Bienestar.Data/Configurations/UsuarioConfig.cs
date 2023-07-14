using Bienestar.Entities;
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
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasIndex(p => p.NumeroIdentificacion).IsUnique(true);

            builder.Property(p => p.Nombres)
            .HasMaxLength(250);

            builder.Property(p => p.Apellidos)
                    .HasMaxLength(250);

            builder.Property(p => p.FechaNacimiento)
                    .HasColumnType("date");

        }
    }
}
