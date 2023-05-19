using API.DAL;
using API.Modules.Archives.Core;
using API.Modules.Archives.Ports;
using Microsoft.EntityFrameworkCore;

namespace API.Modules.Archives.Adapters
{
    public class ArchiveRepository : Repository<Archive>, IArchiveRepository
    {
        public ArchiveRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public IEnumerable<Archive> GetAll()
        {
            return Set
                .Include(e => e.Repair)
                    .ThenInclude(r => r.Worker)
                .Include(e => e.Repair)
                    .ThenInclude(r => r.Client)
                .Include(e => e.Repair)
                    .ThenInclude(r => r.Services);
        }

        public Archive? GetById(int id)
        {
            return Set
                .Include(e => e.Repair)
                .ThenInclude(r => r.Worker)
                .Include(e => e.Repair)
                .ThenInclude(r => r.Client)
                .Include(e => e.Repair)
                .ThenInclude(r => r.Services)
                .FirstOrDefault(e => e.Id == id);
        }

        public async Task AddAsync(Archive archive)
        {
            await Set.AddAsync(archive);
        }

        public void Remove(Archive archive)
        {
            Set.Remove(archive);
        }
    }
}
