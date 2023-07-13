using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bienestar.Entities.Entities
{
    [Table("TL_Padres")]
    public class Padre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UsuarioId { get;set; }
        [Required]
        public char TipoEmpleo { get; set; }
        
        public Int16? ExperienciaLaboral { get; set; }

        public string Observaciones { get; set; }

        [NotMapped]
        public Usuario Usuario { get; set; }
        public HashSet<RelacionPadreHijo> RelacionPadreHijo { get; set; }

    }
}
