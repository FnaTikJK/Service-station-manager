using API.Modules.Services.Core;

namespace API.Modules.Services.Ports
{
    public interface IServicesRepository
    {
        public IEnumerable<Service> GetServices();
        public Service? GetService(int id);
        public IEnumerable<Service> GetRange(IEnumerable<int> ids);
        public Task AddAsync(Service service);
        public Task RemoveAndSaveAsync(int id);
        public Task SaveChangesAsync();
    }
}
