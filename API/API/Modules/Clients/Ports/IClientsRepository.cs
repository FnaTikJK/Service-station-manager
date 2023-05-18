using API.Modules.Clinets.Core;

namespace API.Modules.Clinets.Ports
{
    public interface IClientsRepository
    {
        public IEnumerable<Client> GetAll();
        public Client? GetById(int id);
        public Task AddAsync(Client client);
        public void Remove(Client worker);
        public Task SaveChangesAsync();
    }
}
