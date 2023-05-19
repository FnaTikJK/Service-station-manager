using API.Infrastructure;
using API.Modules.Archives.DTO;

namespace API.Modules.Archives.Ports
{
    public interface IArchivesService
    {
        public IEnumerable<ArchiveDTO> GetAll();
        public ArchiveDTO? GetById(int id);
        public Task<Result<bool>> AddOrUpdateAsync(ArchiveAddOrUpdateDTO archiveAddDto);
        public Task RemoveAsync(int id);
    }
}
