using API.Modules.Clients.DTO;
using API.Modules.Clinets.DTO;

namespace API.Modules.Clinets.Ports
{
    public interface IClientsService
    {
        public IEnumerable<ClientOutDTO> GetAll();
        public ClientOutDTO? GetById(int id);
        public Task AddOrUpdateAsync(ClientAddDTO workerAddDto);
        public Task RemoveAsync(int id);
    }
}
