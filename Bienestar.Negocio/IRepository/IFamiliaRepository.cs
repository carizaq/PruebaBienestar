using Bienestar.Negocio.DTO;

namespace Bienestar.Negocio.IRepository
{
    public interface IFamiliaRepository<T> where T:class//, IAsyncDisposable
    {
        Task<T> ObtenerUsuarioPorId(int pId);
        Task<T> ObtenerUsuarioPorIdentificacion(Int64 pIdentificacion);
        Task<IEnumerable<T>> ObtenerUsuariosPorNombre(string pNombre);
        Task CrearFamilia(FamiliaDTO pFamilia);        
        Task<bool> EliminarUsuario(int pId);
        Task<T> ActualizarUsuario(T pUsuario);
        Task AlmacenarCambios();
    }
}
