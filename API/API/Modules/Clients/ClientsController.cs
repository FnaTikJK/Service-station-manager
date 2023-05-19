using API.Modules.Clients.DTO;
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
        private readonly IClientsService clientsService;

        public ClientsController(IClientsService clientsService)
        {
            this.clientsService = clientsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClientOutDTO>> GetAll()
        {
            return Ok(clientsService.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult GetById(int id)
        {
            var response = clientsService.GetById(id);

            return response == null
                ? NotFound()
                : Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<int>> PutAsync(ClientAddDTO clientAddDto)
        {
            await this.clientsService.AddOrUpdateAsync(clientAddDto);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await clientsService.RemoveAsync(id);

            return NoContent();
        }
    }
}
