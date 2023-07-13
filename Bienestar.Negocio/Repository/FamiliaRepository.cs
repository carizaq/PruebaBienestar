using AutoMapper;
using Bienestar.Data;
using Bienestar.Entities;
using Bienestar.Negocio.DTO;
using Bienestar.Negocio.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Bienestar.Negocio.Repository
{
    public class FamiliaRepository : IFamiliaRepository<UsuarioDTO>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FamiliaRepository(ApplicationDbContext context,IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
            
        }

        public Task<UsuarioDTO> ActualizarUsuario(UsuarioDTO pUsuario)
        {
            throw new NotImplementedException();
        }
        
        public Task<UsuarioDTO> CrearFamilia(UsuarioDTO pUsuarioDTO)
        {
            return null;
        }

        public async Task<bool> EliminarUsuario(int pId)
        {
            var usuario = await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==pId);
            if (usuario != null)
            {

            }
            else
                return false;

            return true;
        }

        public async Task<UsuarioDTO> ObtenerUsuarioPorId(int pId)
        {
            UsuarioDTO usuaDTO = new UsuarioDTO();
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(x=>x.Id==pId);    
                usuaDTO = _mapper.Map<UsuarioDTO>(usuario);
              
                return usuaDTO;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<UsuarioDTO> ObtenerUsuarioPorIdentificacion(int pIdentificacion)
        {
            var usuario = await _context.Usuarios.AsNoTracking().Where(x => x.NumeroIdentificacion == pIdentificacion).FirstOrDefaultAsync();
            UsuarioDTO usuaDTO = new UsuarioDTO();
            if (usuario != null)
            {
                usuaDTO = new UsuarioDTO()
                {
                    Id= usuario.Id,
                    Apellidos=usuario.Apellidos,
                    FechaNacimiento=usuario.FechaNacimiento,
                    Genero=usuario.Genero,
                    Nombres=usuario.Nombres,
                    NumeroIdentificacion = usuario.NumeroIdentificacion,
                    UsuarioId=usuario.Id,
                    
                };
            }
            return usuaDTO;
        }

        public async Task<IEnumerable<UsuarioDTO>> ObtenerUsuariosPorNombre(string pNombre)
        {
            var usuariosDTO = new List<UsuarioDTO>();
            var usuarios =await _context.Usuarios.AsNoTracking().Where(x=>x.Nombres.Contains(pNombre) || x.Apellidos.Contains(pNombre)).ToListAsync();
            if (usuarios.Any())
            {
                usuariosDTO = _mapper.Map<List<UsuarioDTO>>(usuarios);
            }
            return usuariosDTO;
        }

        public async Task AlmacenarCambios()
        {
            await _context.SaveChangesAsync();
        }

        //static MapperConfiguration GetMapperConfiguration()
        //{
        //    return new MapperConfiguration(cfg => cfg.CreateMap<Usuario,UsuarioDTO>());
        //}
        
    }
}
