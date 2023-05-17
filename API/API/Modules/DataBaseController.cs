using API.DAL;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataBaseController : ControllerBase
    {
        private readonly DataContext dataContext;

        public DataBaseController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpPost]
        public ActionResult RefreshDb()
        {
            dataContext.InitDb();

            return Ok();
        }
    }
}
