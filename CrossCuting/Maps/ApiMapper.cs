using Application.Dtos;
using AutoMapper;
using DataAccess.Resposta;
using Domain.Models;

namespace CrossCuting.Maps
{
    public class ApiMapper : Profile
    {
        public ApiMapper()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();

            CreateMap(typeof(RespostaOperacao<>), typeof(RespostaOperacaoDto<>))
            .ForMember("Objeto", opt => opt.MapFrom("Objeto"))
            .ReverseMap();
        }
    }
}
