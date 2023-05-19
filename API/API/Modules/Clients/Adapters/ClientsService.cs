using API.Modules.Clients.DTO;
using API.Modules.Clinets.Core;
using API.Modules.Clinets.DTO;
using API.Modules.Clinets.Ports;
using API.Modules.Repairs.Ports;
using AutoMapper;

namespace API.Modules.Clinets.Adapters
{
    public class ClientsService : IClientsService
    {
        private readonly IMapper mapper;
        private readonly IClientsRepository clientsRepository;
        private readonly IRepairsRepository repairsRepository;

        public ClientsService(IMapper mapper, IClientsRepository clientsRepository, IRepairsRepository repairsRepository)
        {
            this.mapper = mapper;
            this.clientsRepository = clientsRepository;
            this.repairsRepository = repairsRepository;
        }

        public IEnumerable<ClientOutDTO> GetAll()
        {
            var clients = mapper.Map<IEnumerable<ClientOutDTO>>(clientsRepository.GetAll());
            foreach (var client in clients)
            {
                client.Cars = repairsRepository.GetCars(client.Id);
            }

            return clients;
        }

        public ClientOutDTO? GetById(int id)
        {
            var client = mapper.Map<ClientOutDTO>(clientsRepository.GetById(id));
            client.Cars = repairsRepository.GetCars(client.Id);
            return client;
        }

        public async Task AddOrUpdateAsync(ClientAddDTO workerAddDto)
        {
            var existed = clientsRepository.GetById(workerAddDto.Id);
            if (existed != null)
            {
                mapper.Map(workerAddDto, existed);
            }
            else
            {
                workerAddDto.Id = 0;
                await clientsRepository.AddAsync(mapper.Map<Client>(workerAddDto));
            }
            await clientsRepository.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var existed = clientsRepository.GetById(id);
            if (existed != null)
            {
                clientsRepository.Remove(existed);
                await clientsRepository.SaveChangesAsync();
            }
        }
    }
}
