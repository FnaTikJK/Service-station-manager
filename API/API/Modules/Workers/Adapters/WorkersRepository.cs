using API.DAL;
using API.Modules.Workers.Core;
using API.Modules.Workers.Ports;

namespace API.Modules.Workers.Adapters
{
    public class WorkersRepository : Repository<Worker>, IWorkersRepository
    {
        public WorkersRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public IEnumerable<Worker> GetWorkers()
        {
            return Set;
        }

        public Worker? GetWorkerById(int id)
        {
            return Set.FirstOrDefault(x => x.Id == id);
        }

        public async Task AddAsync(Worker worker)
        {
            await Set.AddAsync(worker);
        }

        public void Remove(Worker worker)
        {
            Set.Remove(worker);
        }
    }
}
