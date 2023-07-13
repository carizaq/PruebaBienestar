using Bienestar.Negocio.DTO;

namespace Bienestar.Negocio.IRepository
{
    public interface IFamiliaRepository<T> where T:class//, IAsyncDisposable
    {
        Task<T> ObtenerUsuarioPorId(int pId);
        Task<T> ObtenerUsuarioPorIdentificacion(int pIdentificacion);
        Task<IEnumerable<T>> ObtenerUsuariosPorNombre(string pNombre);
        Task<UsuarioDTO> CrearFamilia(UsuarioDTO pUsuarioDTO);        
        Task<bool> EliminarUsuario(int pId);
        Task<T> ActualizarUsuario(T pUsuario);
        Task AlmacenarCambios();
    }
}
