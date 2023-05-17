using API.Modules.Services.Core;
using API.Modules.Services.Ports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesService servicesService;

        public ServicesController(IServicesService servicesService)
        {
            this.servicesService = servicesService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Service>> GetServices()
        {
            return Ok(servicesService.GetServices());
        }

        [HttpGet("{id:int}")]
        public ActionResult GetService(int id)
        {
            var response = servicesService.GetServiceById(id);

            return response == null
                ? NotFound()
                : Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<int>> PutServiceAsync(Service service)
        {
            var response = await this.servicesService.AddOrUpdateAsync(service);

            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await servicesService.RemoveAsync(id);

            return NoContent();
        }
    }
}
