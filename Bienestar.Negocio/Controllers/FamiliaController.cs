using Bienestar.Data;
using Bienestar.Negocio.DTO;
using Bienestar.Negocio.IRepository;
using Bienestar.Negocio.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bienestar.Negocio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IFamiliaRepository<UsuarioDTO> _familiaRepository;


        public FamiliaController(IFamiliaRepository<UsuarioDTO> familiaRepository)
        {
            this._familiaRepository = familiaRepository;
        }

        [HttpGet]
        [Route("UsuarioPorIdentificacion/")]
        public async Task<UsuarioDTO> ObtenerUsuarioPorIdentificacion(int pIdentificacion)
        {
            return await _familiaRepository.ObtenerUsuarioPorIdentificacion(pIdentificacion); 
        }

        [HttpGet]
        [Route("UsuarioPorNombre/")]
        public async Task<IEnumerable<UsuarioDTO>> ObtenerUsuariosPorNombre(string pNombre)
        {
            return await _familiaRepository.ObtenerUsuariosPorNombre(pNombre);
        }

        [HttpGet]
        [Route("UsuarioPorId/")]
        public async Task<UsuarioDTO> ObtenerUsuarioPorId(int pId)
        {
            return await _familiaRepository.ObtenerUsuarioPorId(pId);
        }

        [HttpPost]
        [Route("CrearUsuario/")]
        public async Task<UsuarioDTO> CrearUsuario(UsuarioDTO pUsuario)
        {
            return await _familiaRepository.CrearFamilia(pUsuario);
        }
    }
}
