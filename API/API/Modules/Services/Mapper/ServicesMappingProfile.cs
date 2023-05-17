using API.Modules.Services.Core;
using AutoMapper;

namespace API.Modules.Services.Mapper
{
    public class ServicesMappingProfile : Profile
    {
        public ServicesMappingProfile()
        {
            CreateMap<Service, Service>();
        }
    }
}
