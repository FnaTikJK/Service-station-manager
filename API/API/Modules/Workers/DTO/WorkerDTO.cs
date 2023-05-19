using static API.Infrastructure.JsonConfig;
using System.Text.Json.Serialization;

namespace API.Modules.Workers.DTO
{
    public class WorkerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
