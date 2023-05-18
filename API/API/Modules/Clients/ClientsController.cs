using API.Modules.Services.Core;
using API.Modules.Clinets.DTO;
using API.Modules.Clinets.Ports;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Clinets
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService workersService;

        public ClientsController(IClientsService workersService)
        {
            this.workersService = workersService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Service>> GetAll()
        {
            return Ok(workersService.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult GetById(int id)
        {
            var response = workersService.GetById(id);

            return response == null
                ? NotFound()
                : Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<int>> PutAsync(ClientDTO clientDto)
        {
            await this.workersService.AddOrUpdateAsync(clientDto);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await workersService.RemoveAsync(id);

            return NoContent();
        }
    }
}
