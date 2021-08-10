using AutoMapper;
using Sacolao.Api.Models;
using Sacolao.Api.v1.Dtos;

namespace Sacolao.Api.v1.Profiles
{
    public class SacolaoProfile : Profile
    {
        public SacolaoProfile()
        {
            CreateMap<Fruta, FrutaDto>();
            CreateMap<FrutaDto, Fruta>();
            CreateMap<Fruta, FrutaRegistroDto>().ReverseMap();
        }
    }
}
