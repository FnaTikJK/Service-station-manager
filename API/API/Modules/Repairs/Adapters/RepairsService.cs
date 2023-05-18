using API.Infrastructure;
using API.Modules.Clinets.Core;
using API.Modules.Clinets.DTO;
using API.Modules.Clinets.Ports;
using API.Modules.Repairs.Core;
using API.Modules.Repairs.DTO;
using API.Modules.Repairs.Ports;
using AutoMapper;

namespace API.Modules.Repairs.Adapters
{
    public class RepairsService : IRepairsService
    {
        private readonly IMapper mapper;
        private readonly IRepairsRepository repairsRepository;

        public RepairsService(IMapper mapper, IRepairsRepository repairsRepository)
        {
            this.mapper = mapper;
            this.repairsRepository = repairsRepository;
        }

        public IEnumerable<RepairOutDTO> GetAll()
        {
            return mapper.Map<IEnumerable<RepairOutDTO>>(repairsRepository.GetAll());
        }

        public RepairOutDTO? GetById(int id)
        {
            return mapper.Map<RepairOutDTO>(repairsRepository.GetById(id));
        }

        public async Task<Result<bool>> AddOrUpdateAsync(RepairAddOrUpdateDTO repairDto)
        {
            var mapped = mapper.Map<Repair>(repairDto);
            if (!mapped.IsCorrect(out var message))
                return Result.Fail<bool>(message);

            var existed = repairsRepository.GetById(repairDto.Id);
            if (existed != null)
            {
                mapper.Map(repairDto, existed);
            }
            else
            {
                repairDto.Id = 0;
                await repairsRepository.AddAsync(mapper.Map<Repair>(repairDto));
            }
            await repairsRepository.SaveChangesAsync();
            return Result.Ok(true);
        }

        public async Task RemoveAsync(int id)
        {
            var existed = repairsRepository.GetById(id);
            if (existed != null)
            {
                repairsRepository.Remove(existed);
                await repairsRepository.SaveChangesAsync();
            }
        }
    }
}
