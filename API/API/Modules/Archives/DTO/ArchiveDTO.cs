using API.Modules.Repairs.DTO;

namespace API.Modules.Archives.DTO
{
    public class ArchiveDTO
    {
        public int Id { get; set; }
        public RepairOutDTO Repair { get; set; }
        public string Parts { get; set; }
        public DateOnly End { get; set; }
    }
}
