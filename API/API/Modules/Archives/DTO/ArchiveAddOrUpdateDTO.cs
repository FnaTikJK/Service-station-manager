namespace API.Modules.Archives.DTO
{
    public class ArchiveAddOrUpdateDTO
    {
        public int Id { get; set; }
        public int RepairId { get; set; }
        public string Parts { get; set; }
        public DateOnly End { get; set; }
    }
}
