using API.Modules.Workers.DTO;

namespace API.Modules.Workers.Ports
{
    public interface IWorkersService
    {
        public IEnumerable<WorkerDTO> GetWorkers();
        public WorkerDTO? GetWorkerById(int id);
        public Task AddOrUpdateAsync(WorkerDTO workerDto);
        public Task RemoveAsync(int id);
    }
}
