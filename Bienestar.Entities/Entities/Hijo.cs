using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bienestar.Entities.Entities
{
    [Table("TL_Hijos")]
    public class Hijo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public char Estudia { get; set; }
        [Required]
        public Int16 EstaturaCms { get; set; }

        public string DescripcionFisica { get; set; }
        [NotMapped]
        public Usuario Usuario { get; set; }
        public HashSet<RelacionPadreHijo> RelacionPadreHijo { get; set; }
    }
}
