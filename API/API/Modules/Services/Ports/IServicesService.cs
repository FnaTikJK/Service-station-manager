using API.Modules.Services.Core;

namespace API.Modules.Services.Ports
{
    public interface IServicesService
    {
        public IEnumerable<Service> GetServices();
        public Service? GetServiceById(int id);
        public Task<int> AddOrUpdateAsync(Service service);
        public Task RemoveAsync(int id);
    }
}
