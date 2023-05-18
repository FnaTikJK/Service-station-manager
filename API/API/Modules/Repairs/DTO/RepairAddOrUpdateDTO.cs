namespace API.Modules.Repairs.DTO
{
    public class RepairAddOrUpdateDTO
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public int ClientId { get; set; }
        public IEnumerable<int> ServiceIds { get; set; }
        public string Car { get; set; }
        public DateOnly Start { get; set; }
    }
}
