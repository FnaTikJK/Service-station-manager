using System.ComponentModel.DataAnnotations;

namespace API.Modules.Services.Core
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
