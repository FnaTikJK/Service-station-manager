using System.ComponentModel.DataAnnotations;
using API.Modules.Repairs.Core;

namespace API.Modules.Archives.Core
{
    public class Archive
    {
        public int Id { get; set; }
        public Repair Repair { get; set; }
        public string Parts { get; set; }
        public DateTime End { get; set; }
    }
}
