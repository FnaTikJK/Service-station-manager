using API.DAL;
using API.Modules.Repairs.Core;
using API.Modules.Repairs.Ports;
using Microsoft.EntityFrameworkCore;

namespace API.Modules.Repairs.Adapters
{
    public class RepairsRepository : Repository<Repair>, IRepairsRepository
    {
        public RepairsRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public IEnumerable<Repair> GetAll()
        {
            return Set
                .Include(e => e.Worker)
                .Include(e => e.Client)
                .Include(e => e.Services)
                .Where(e => !e.Archives.Any());
        }

        public Repair? GetById(int id)
        {
            return Set
                .Include(e => e.Worker)
                .Include(e => e.Client)
                .Include(e => e.Services)
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<string> GetCars(int clientId)
        {
            return Set.Where(e => e.Client.Id == clientId).Select(e => e.Car).Distinct();
        }

        public async Task AddAsync(Repair repair)
        {
            await Set.AddAsync(repair);
        }

        public void Remove(Repair repair)
        {
            Set.Remove(repair);
        }
    }
}
