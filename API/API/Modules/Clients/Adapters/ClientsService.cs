using API.Modules.Clinets.Core;
using API.Modules.Clinets.DTO;
using API.Modules.Clinets.Ports;
using AutoMapper;

namespace API.Modules.Clinets.Adapters
{
    public class ClientsService : IClientsService
    {
        private readonly IMapper mapper;
        private readonly IClientsRepository clientsRepository;

        public ClientsService(IMapper mapper, IClientsRepository clientsRepository)
        {
            this.mapper = mapper;
            this.clientsRepository = clientsRepository;
        }

        public IEnumerable<ClientDTO> GetAll()
        {
            return mapper.Map<IEnumerable<ClientDTO>>(clientsRepository.GetAll());
        }

        public ClientDTO? GetById(int id)
        {
            return mapper.Map<ClientDTO>(clientsRepository.GetById(id));
        }

        public async Task AddOrUpdateAsync(ClientDTO workerDto)
        {
            var existed = clientsRepository.GetById(workerDto.Id);
            if (existed != null)
            {
                mapper.Map(workerDto, existed);
            }
            else
            {
                workerDto.Id = 0;
                await clientsRepository.AddAsync(mapper.Map<Client>(workerDto));
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
