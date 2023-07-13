using Bienestar.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bienestar.Entities
{
    [Table("TL_Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int NumeroIdentificacion { get; set; }
        [MaxLength(250)]
        [Required]
        public string Nombres { get; set; }
        [Required]
        [MaxLength(250)]
        public string Apellidos { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public char Genero { get; set; }

        public Hijo Hijo { get; set; }
        public Padre Padre { get; set; }
    }
}
