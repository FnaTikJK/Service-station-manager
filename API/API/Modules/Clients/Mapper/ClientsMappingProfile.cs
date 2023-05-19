using API.Modules.Clients.DTO;
using API.Modules.Clinets.Core;
using API.Modules.Clinets.DTO;
using API.Modules.Clinets.Ports;
using AutoMapper;

namespace API.Modules.Clinets.Mapper
{
    public class ClientsMappingProfile : Profile
    {
        public ClientsMappingProfile()
        {
            CreateMap<Client, ClientAddDTO>().ForMember(dest => dest.BirthDate, 
                opt => opt.MapFrom(src => DateOnly.FromDateTime(src.BirthDate)));
            CreateMap<ClientAddDTO, Client>().ForMember(dest => dest.BirthDate,
                opt => opt.MapFrom(src => src.BirthDate.ToDateTime(new TimeOnly())));
            CreateMap<Client, ClientShortDTO>()
                .ForMember(dest => dest.SecondNameWithInitials,
                    opt => opt.MapFrom(src => $"{src.SecondName} {src.FirstName.First()}.{src.ThirdName.First()}."));
            CreateMap<Client, ClientOutDTO>();
        }

        public class ClientsConverter : IValueConverter<int, Client>
        {
            private readonly IClientsRepository clientsRepository;

            public ClientsConverter(IClientsRepository clientsRepository)
            {
                this.clientsRepository = clientsRepository;
            }

            public Client? Convert(int sourceMember, ResolutionContext context)
            {
                return clientsRepository.GetById(sourceMember);
            }
        }
    }
}
