using API.Infrastructure;
using API.Modules.Repairs.DTO;

namespace API.Modules.Repairs.Ports
{
    public interface IRepairsService
    {
        public IEnumerable<RepairOutDTO> GetAll();
        public RepairOutDTO? GetById(int id);
        public Task<Result<bool>> AddOrUpdateAsync(RepairAddOrUpdateDTO workerDto);
        public Task RemoveAsync(int id);
    }
}
