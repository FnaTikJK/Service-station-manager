using System.ComponentModel.DataAnnotations.Schema;
using API.Modules.Archives.Core;
using API.Modules.Clinets.Core;
using API.Modules.Services.Core;
using API.Modules.Workers.Core;

namespace API.Modules.Repairs.Core
{
    public class Repair
    {
        public int Id { get; set; }
        public Worker Worker { get; set; }
        public Client Client { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public string Car { get; set; }
        public DateTime Start { get; set; }
        public IEnumerable<Archive> Archives { get; set; }

        public bool IsCorrect(out string message)
        {
            if (Worker == null)
            {
                message = "Неправильно указан рабочий";
                return false;
            }

            if (Client == null)
            {
                message = "Неправильно указан клиент";
                return false;
            }

            if (Services.Count() == 0)
            {
                message = "Неправильно указаны услуги";
                return false;
            }

            if (DateTime.Now < Start)
            {
                message = "Некорректное начало работ";
                return false;
            }

            message = "";
            return true;
        }
    }
}
