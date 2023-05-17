using API.Modules.Services.Core;
using API.Modules.Services.Ports;
using AutoMapper;

namespace API.Modules.Services.Adapters
{
    public class ServicesService : IServicesService
    {
        private readonly IServicesRepository servicesRepository;
        private readonly IMapper mapper;

        public ServicesService(IMapper mapper, IServicesRepository servicesRepository)
        {
            this.mapper = mapper;
            this.servicesRepository = servicesRepository;
        }

        public IEnumerable<Service> GetServices()
        {
            return servicesRepository.GetServices();
        }

        public Service? GetServiceById(int id)
        {
            return servicesRepository.GetService(id);
        }

        public async Task<int> AddOrUpdateAsync(Service service)
        {
            var existed = servicesRepository.GetService(service.Id);

            if (existed != null)
            {
                mapper.Map(service, existed);
                await servicesRepository.SaveChangesAsync();
                return existed.Id;
            }
            else
            {
                service.Id = 0;
                await servicesRepository.AddAsync(service);
                await servicesRepository.SaveChangesAsync();
                return service.Id;
            }
        }

        public async Task RemoveAsync(int id)
        {
            await servicesRepository.RemoveAndSaveAsync(id);
        }
    }
}
