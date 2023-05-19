using API.Modules.Archives.Core;

namespace API.Modules.Archives.Ports
{
    public interface IArchiveRepository
    {
        public IEnumerable<Archive> GetAll();
        public Archive? GetById(int id);
        public Task AddAsync(Archive archive);
        public void Remove(Archive archive);
        public Task SaveChangesAsync();
    }
}
