using API.DAL;
using API.Modules.Services.Core;
using API.Modules.Services.Ports;
using Microsoft.EntityFrameworkCore;

namespace API.Modules.Services.Adapters
{
    public class ServicesRepository : Repository<Service>, IServicesRepository
    {
        public ServicesRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public IEnumerable<Service> GetServices()
        {
            return Set;
        }

        public Service? GetService(int id)
        {
            return Set.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Service> GetRange(IEnumerable<int> ids)
        {
            return Set.Where(s => ids.Contains(s.Id));
        }

        public async Task AddAsync(Service service)
        {
            await Set.AddAsync(service);
        }

        public async Task RemoveAndSaveAsync(int id)
        {
            var existed = await Set.FirstOrDefaultAsync(e => e.Id == id);

            if (existed != null)
            {
                Set.Remove(existed);
                await SaveChangesAsync();
            }
        }
    }
}
