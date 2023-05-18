using API.Modules.Clients.DTO;
using API.Modules.Services.DTO;
using API.Modules.Workers.DTO;

namespace API.Modules.Repairs.DTO
{
    public class RepairOutDTO
    {
        public int Id { get; set; }
        public WorkerShortDTO Worker { get; set; }
        public ClientShortDTO Client { get; set; }
        public List<ServiceShortDTO> Services { get; set; }
        public string Car { get; set; }
        public DateOnly Start { get; set; }
    }
}
