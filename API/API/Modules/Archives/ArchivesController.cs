using API.Modules.Archives.DTO;
using API.Modules.Archives.Ports;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Archives
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivesController : ControllerBase
    {
        private readonly IArchivesService archivesService;

        public ArchivesController(IArchivesService archivesService)
        {
            this.archivesService = archivesService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ArchiveDTO>> GetAll()
        {
            return Ok(archivesService.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult<ArchiveDTO> GetById(int id)
        {
            var response = archivesService.GetById(id);

            return response == null
                ? NotFound()
                : Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<int>> PutAsync(ArchiveAddOrUpdateDTO repairsAddDto)
        {
            var response = await this.archivesService.AddOrUpdateAsync(repairsAddDto);

            return response.IsSuccess ? NoContent()
                : BadRequest(response.Error);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await archivesService.RemoveAsync(id);

            return NoContent();
        }
    }
}
