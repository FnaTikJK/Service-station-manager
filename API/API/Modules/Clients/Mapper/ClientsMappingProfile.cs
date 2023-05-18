using API.Modules.Clinets.Core;
using API.Modules.Clinets.DTO;
using AutoMapper;

namespace API.Modules.Clinets.Mapper
{
    public class ClientsMappingProfile : Profile
    {
        public ClientsMappingProfile()
        {
            CreateMap<Client, ClientDTO>().ForMember(dest => dest.BirthDate, 
                opt => opt.MapFrom(src => DateOnly.FromDateTime(src.BirthDate)));
            CreateMap<ClientDTO, Client>().ForMember(dest => dest.BirthDate,
                opt => opt.MapFrom(src => src.BirthDate.ToDateTime(new TimeOnly())));
        }
    }
}
