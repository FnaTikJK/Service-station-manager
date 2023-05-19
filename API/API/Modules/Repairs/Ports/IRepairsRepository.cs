using API.Modules.Repairs.Core;

namespace API.Modules.Repairs.Ports
{
    public interface IRepairsRepository
    {
        public IEnumerable<Repair> GetAll();
        public Repair? GetById(int id);
        public IEnumerable<string> GetCars(int clientId);
        public Task AddAsync(Repair repair);
        public void Remove(Repair repair);
        public Task SaveChangesAsync();
    }
}
