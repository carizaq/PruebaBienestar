
namespace Bienestar.Negocio.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public Int64 NumeroIdentificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public char Genero { get; set; }

        public int UsuarioId { get; set; }



    }
}
