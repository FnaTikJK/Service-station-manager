using API.Modules.Repairs.DTO;
using API.Modules.Repairs.Ports;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Repairs
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairsController : ControllerBase
    {
        private readonly IRepairsService repairsService;

        public RepairsController(IRepairsService repairsService)
        {
            this.repairsService = repairsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RepairOutDTO>> GetAll()
        {
            return Ok(repairsService.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult<RepairOutDTO> GetById(int id)
        {
            var response = repairsService.GetById(id);

            return response == null
                ? NotFound()
                : Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<int>> PutAsync(RepairAddOrUpdateDTO repairsAddDto)
        {
            var response = await this.repairsService.AddOrUpdateAsync(repairsAddDto);

            return response.IsSuccess ? NoContent()
                    : BadRequest(response.Error);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await repairsService.RemoveAsync(id);

            return NoContent();
        }
    }
}
