using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bienestar.Entities.Entities
{
    [Table("TL_RelacionPadresHijos")]
    public class RelacionPadreHijo
    {
        public int PadreId { get; set; }
        public int HijoId { get; set; }
        public Padre Padre { get; set; }
        public Hijo Hijo { get; set; }


    }
}
