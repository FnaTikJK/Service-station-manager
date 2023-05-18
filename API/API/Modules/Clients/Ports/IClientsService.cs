using API.Modules.Clinets.DTO;

namespace API.Modules.Clinets.Ports
{
    public interface IClientsService
    {
        public IEnumerable<ClientDTO> GetAll();
        public ClientDTO? GetById(int id);
        public Task AddOrUpdateAsync(ClientDTO workerDto);
        public Task RemoveAsync(int id);
    }
}
