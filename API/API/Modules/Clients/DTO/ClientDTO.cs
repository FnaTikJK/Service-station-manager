using static API.Infrastructure.JsonConfig;
using System.Text.Json.Serialization;

namespace API.Modules.Clinets.DTO
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly BirthDate { get; set; }
    }
}
