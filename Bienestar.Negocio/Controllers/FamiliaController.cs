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
        
        private readonly IFamiliaRepository<UsuarioDTO> _familiaRepository;

        public FamiliaController(IFamiliaRepository<UsuarioDTO> familiaRepository)
        {
            this._familiaRepository = familiaRepository;
        }

        [HttpGet]
        [Route("UsuarioPorIdentificacion/")]
        public async Task<UsuarioDTO> ObtenerUsuarioPorIdentificacion(Int64 pIdentificacion)
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
        [Route("CrearFamilia/")]
        public async Task<ActionResult> CrearFamilia(FamiliaDTO pFamilia)
        {
            try
            {
                await _familiaRepository.CrearFamilia(pFamilia);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        [HttpPatch]
        [Route("ElimnarrUsuario/")]
        public async Task<UsuarioDTO> ActualizarUsuario(UsuarioDTO pUsuario)
        {
            return await _familiaRepository.ActualizarUsuario(pUsuario);
        }

        [HttpDelete]
        [Route("ActualizarUsuario/")]
        public async Task<ActionResult> ElimnarUsuario(int pId)
        {
            bool eliminado = await _familiaRepository.EliminarUsuario(pId);
             if(eliminado)
                return Ok();
             else
                return NotFound("No fue posible eliminar el usuario");
        }



    }
}
