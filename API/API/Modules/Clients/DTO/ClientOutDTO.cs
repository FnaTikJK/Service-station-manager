namespace API.Modules.Clients.DTO
{
    public class ClientOutDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public DateOnly BirthDate { get; set; }
        public IEnumerable<string> Cars { get; set; }
    }
}
