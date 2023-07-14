using AutoMapper;
using Bienestar.Entities;
using Bienestar.Entities.Entities;
using Bienestar.Negocio.DTO;

namespace Bienestar.Negocio.Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();//mapea desde Autor hacia AutorDTO y viceversa
            CreateMap<Padre, PadresDTO>().ReverseMap();//mapea desde Autor hacia AutorDTO y viceversa
            CreateMap<Hijo, HijosDTO>().ReverseMap();//mapea desde Autor hacia AutorDTO y viceversa
            //CreateMap<, FamiliaDTO>();//mapea desde AutorCreacionDTO hacia Autor
        }
    }


}
