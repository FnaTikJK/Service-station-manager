using API.Modules.Services.Core;
using API.Modules.Services.DTO;
using API.Modules.Services.Ports;
using AutoMapper;

namespace API.Modules.Services.Mapper
{
    public class ServicesMappingProfile : Profile
    {
        public ServicesMappingProfile()
        {
            CreateMap<Service, Service>();
            CreateMap<Service, ServiceShortDTO>();
            CreateMap<IEnumerable<int>, IEnumerable<Service>>().ConvertUsing(typeof(ServicesTypeConverter));
        }

        public class ServicesTypeConverter : ITypeConverter<IEnumerable<int>, IEnumerable<Service>>
        {
            private readonly IServicesRepository servicesRepository;

            public ServicesTypeConverter(IServicesRepository servicesRepositroy)
            {
                this.servicesRepository = servicesRepositroy;
            }

            public IEnumerable<Service> Convert(IEnumerable<int> source, IEnumerable<Service> destination, ResolutionContext context)
            {
                return servicesRepository.GetRange(source).ToList();
            }
        }

        public class ServicesConverter : IValueConverter<IEnumerable<int>, IEnumerable<Service>>
        {
            private readonly IServicesRepository servicesRepository;

            public ServicesConverter(IServicesRepository servicesRepositroy)
            {
                this.servicesRepository = servicesRepositroy;
            }

            public IEnumerable<Service> Convert(IEnumerable<int> sourceMember, ResolutionContext context)
            {
                return servicesRepository.GetRange(sourceMember);
            }
        }
    }
}
