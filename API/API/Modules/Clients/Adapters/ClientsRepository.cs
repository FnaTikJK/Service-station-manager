using API.DAL;
using API.Modules.Clinets.Core;
using API.Modules.Clinets.Ports;

namespace API.Modules.Clinets.Adapters
{
    public class ClientsRepository : Repository<Client>, IClientsRepository
    {
        public ClientsRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public IEnumerable<Client> GetAll()
        {
            return Set;
        }

        public Client? GetById(int id)
        {
            return Set.FirstOrDefault(x => x.Id == id);
        }

        public async Task AddAsync(Client client)
        {
            await Set.AddAsync(client);
        }

        public void Remove(Client client)
        {
            Set.Remove(client);
        }
    }
}
