using API.Modules.Services.Core;
using API.Modules.Services.Ports;
using API.Modules.Workers.DTO;
using API.Modules.Workers.Ports;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Workers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkersService workersService;

        public WorkersController(IWorkersService workersService)
        {
            this.workersService = workersService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Service>> GetServices()
        {
            return Ok(workersService.GetWorkers());
        }

        [HttpGet("{id:int}")]
        public ActionResult GetService(int id)
        {
            var response = workersService.GetWorkerById(id);

            return response == null
                ? NotFound()
                : Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<int>> PutServiceAsync(WorkerDTO workerDto)
        {
            await this.workersService.AddOrUpdateAsync(workerDto);

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
