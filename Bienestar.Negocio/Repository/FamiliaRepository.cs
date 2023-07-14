using AutoMapper;
using Bienestar.Data;
using Bienestar.Entities;
using Bienestar.Entities.Entities;
using Bienestar.Negocio.DTO;
using Bienestar.Negocio.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bienestar.Negocio.Repository
{
    public class FamiliaRepository : IFamiliaRepository<UsuarioDTO>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FamiliaRepository(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;

        }

        public Task<UsuarioDTO> ActualizarUsuario(UsuarioDTO pUsuario)
        {
            throw new NotImplementedException();
        }

        public async Task CrearFamilia(FamiliaDTO pFamiliaDTO)
        {
            var existeUsuario = false;
            int idPadre = 0;
            int idMadre = 0;

            if (pFamiliaDTO.Madre != null)
            {
                existeUsuario = await _context.Usuarios.Where(x => x.NumeroIdentificacion == pFamiliaDTO.Madre.NumeroIdentificacion).AnyAsync();
                if (!existeUsuario)
                {
                    var usuario = await CrearUsuario(_mapper.Map<Usuario>(pFamiliaDTO.Madre));
                    pFamiliaDTO.Madre.UsuarioId = usuario;
                    var madreBD = _context.Padres.Add(_mapper.Map<Padre>(pFamiliaDTO.Madre));
                    await AlmacenarCambios();
                    idMadre = madreBD.Entity.Id;

                }
            }
            if (pFamiliaDTO.Padre != null)
            {
                existeUsuario = await _context.Usuarios.Where(x => x.NumeroIdentificacion == pFamiliaDTO.Padre.NumeroIdentificacion).AnyAsync();
                if (!existeUsuario)
                {
                    var usuario = await CrearUsuario(_mapper.Map<Usuario>(pFamiliaDTO.Padre));
                    pFamiliaDTO.Padre.UsuarioId = usuario;
                    var padre = _context.Padres.Add(_mapper.Map<Padre>(pFamiliaDTO.Padre));
                    await AlmacenarCambios();
                    idPadre = padre.Entity.Id;
                }
            }
            if (pFamiliaDTO.HijosArray.Any())
            {
                List<Int64> idUsuariosExistentes = await _context.Usuarios.Where(x => pFamiliaDTO.HijosArray.Select(y => y.NumeroIdentificacion).ToList().Contains(x.NumeroIdentificacion)).Select(x => x.NumeroIdentificacion).ToListAsync();
                foreach (HijosDTO hijo in pFamiliaDTO.HijosArray)
                {
                    existeUsuario = idUsuariosExistentes.Contains(hijo.NumeroIdentificacion);
                    if (!existeUsuario)
                    {
                        var usuario = await  CrearUsuario(_mapper.Map<Usuario>(hijo));
                        hijo.UsuarioId = usuario;
                        var hijoBD = _context.Hijos.Add(_mapper.Map<Hijo>(hijo));
                        await AlmacenarCambios();


                        if (idMadre != 0)
                        {
                            _context.RelacionPadreHijos.Add(new RelacionPadreHijo()
                            {
                                HijoId = hijoBD.Entity.Id,
                                PadreId = idMadre
                            });
                        }
                        if (idPadre != 0)
                        {
                            _context.RelacionPadreHijos.Add(new RelacionPadreHijo()
                            {
                                HijoId = hijoBD.Entity.Id,
                                PadreId = idPadre
                            });
                        }
                        await AlmacenarCambios();
                    }

                }


            }

        }

        public async Task<bool> EliminarUsuario(int pId)
        {
            var usuarioPadre = await _context.Usuarios.AsNoTracking()
                                .Join(_context.Padres,
                                        usua => usua.Id,
                                        padr => padr.UsuarioId,
                                        (usua, padr) => new { usua = usua, padr = padr }).FirstOrDefaultAsync(x => x.usua.Id == pId);
            if (usuarioPadre != null)
            {
                _context.RelacionPadreHijos.RemoveRange(_context.RelacionPadreHijos.Where(x => x.PadreId == usuarioPadre.padr.Id).ToList());
                _context.Padres.Remove(usuarioPadre.padr);
                _context.Usuarios.Remove(usuarioPadre.usua);
                await AlmacenarCambios();
            }

            var usuarioHijo = await _context.Usuarios.AsNoTracking()
                                .Join(_context.Hijos,
                                        usua => usua.Id,
                                        hijo => hijo.UsuarioId,
                                        (usua, hijo) => new { usua = usua, hijo = hijo }).FirstOrDefaultAsync(x => x.usua.Id == pId);
            if (usuarioHijo != null)
            {
                _context.RelacionPadreHijos.RemoveRange(_context.RelacionPadreHijos.Where(x => x.HijoId == usuarioHijo.hijo.Id).ToList());
                _context.Hijos.Remove(usuarioHijo.hijo);
                _context.Usuarios.Remove(usuarioPadre.usua);
                await AlmacenarCambios();
            }

            return true;
        }

        public async Task<UsuarioDTO> ObtenerUsuarioPorId(int pId)
        {
            UsuarioDTO usuaDTO = new UsuarioDTO();
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == pId);
                usuaDTO = _mapper.Map<UsuarioDTO>(usuario);

                return usuaDTO;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<UsuarioDTO> ObtenerUsuarioPorIdentificacion(Int64 pIdentificacion)
        {
            var usuario = await _context.Usuarios.AsNoTracking().Where(x => x.NumeroIdentificacion == pIdentificacion).FirstOrDefaultAsync();
            UsuarioDTO usuaDTO = new UsuarioDTO();
            if (usuario != null)
            {
                usuaDTO = new UsuarioDTO()
                {
                    Id = usuario.Id,
                    Apellidos = usuario.Apellidos,
                    FechaNacimiento = usuario.FechaNacimiento,
                    Genero = usuario.Genero,
                    Nombres = usuario.Nombres,
                    NumeroIdentificacion = usuario.NumeroIdentificacion,
                    UsuarioId = usuario.Id,

                };
            }
            return usuaDTO;
        }

        public async Task<IEnumerable<UsuarioDTO>> ObtenerUsuariosPorNombre(string pNombre)
        {
            var usuariosDTO = new List<UsuarioDTO>();
            var usuarios = await _context.Usuarios.AsNoTracking().Where(x => x.Nombres.Contains(pNombre) || x.Apellidos.Contains(pNombre)).ToListAsync();
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

        private async Task<int> CrearUsuario(Usuario pUsua)
        {
            var usuarioBD =_context.Usuarios.Add(pUsua);
            await AlmacenarCambios();
            return usuarioBD.Entity.Id;
        }

    }
}
