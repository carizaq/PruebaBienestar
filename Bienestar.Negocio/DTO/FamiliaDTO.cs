using Bienestar.Entities.Entities;

namespace Bienestar.Negocio.DTO
{
    public class FamiliaDTO
    {
        public PadresDTO Padre { get; set; }
        public PadresDTO Madre { get; set; }
        public IEnumerable<HijosDTO> HijosArray { get; set; }

    }

    public class PadresDTO : UsuarioDTO
    {
        public char TipoEmpleo { get; set; }
        public Int16? ExperienciaLaboral { get; set; }
        public string Observaciones { get; set; }
    }

    public class HijosDTO : UsuarioDTO
    {
        public char Estudia { get; set; }
        public Int16 EstaturaCms { get; set; }
        public string DescripcionFisica { get; set; }
    }
}
