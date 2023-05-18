using API.Modules.Workers.Core;
using API.Modules.Workers.DTO;
using API.Modules.Workers.Ports;
using AutoMapper;

namespace API.Modules.Workers.Adapters
{
    public class WorkersService : IWorkersService
    {
        private readonly IMapper mapper;
        private readonly IWorkersRepository workersRepository;

        public WorkersService(IMapper mapper, IWorkersRepository workersRepository)
        {
            this.mapper = mapper;
            this.workersRepository = workersRepository;
        }

        public IEnumerable<WorkerDTO> GetWorkers()
        {
            return mapper.Map<IEnumerable<WorkerDTO>>(workersRepository.GetWorkers());
        }

        public WorkerDTO? GetWorkerById(int id)
        {
            return mapper.Map<WorkerDTO>(workersRepository.GetWorkerById(id));
        }

        public async Task AddOrUpdateAsync(WorkerDTO workerDto)
        {
            var existed = workersRepository.GetWorkerById(workerDto.Id);
            if (existed != null)
            {
                mapper.Map(workerDto, existed);
            }
            else
            {
                workerDto.Id = 0;
                await workersRepository.AddAsync(mapper.Map<Worker>(workerDto));
            }
            await workersRepository.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var existed = workersRepository.GetWorkerById(id);
            if (existed != null)
            {
                workersRepository.Remove(existed);
                await workersRepository.SaveChangesAsync();
            }
        }
    }
}
