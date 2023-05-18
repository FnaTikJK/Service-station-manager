using API.Modules.Workers.Core;

namespace API.Modules.Workers.Ports
{
    public interface IWorkersRepository
    {
        public IEnumerable<Worker> GetWorkers();
        public Worker? GetWorkerById(int id);
        public Task AddAsync(Worker worker);
        public void Remove(Worker worker);
        public Task SaveChangesAsync();
    }
}
