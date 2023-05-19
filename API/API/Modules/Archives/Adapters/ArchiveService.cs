using API.Infrastructure;
using API.Modules.Archives.Core;
using API.Modules.Archives.DTO;
using API.Modules.Archives.Ports;
using AutoMapper;

namespace API.Modules.Archives.Adapters
{
    public class ArchiveService : IArchivesService
    {
        private readonly IArchiveRepository archiveRepository;
        private readonly IMapper mapper;

        public ArchiveService(IMapper mapper, IArchiveRepository archiveRepository)
        {
            this.mapper = mapper;
            this.archiveRepository = archiveRepository;
        }

        public IEnumerable<ArchiveDTO> GetAll()
        {
            return mapper.Map<IEnumerable<ArchiveDTO>>(archiveRepository.GetAll());
        }

        public ArchiveDTO? GetById(int id)
        {
            return mapper.Map<ArchiveDTO>(archiveRepository.GetById(id));
        }

        public async Task<Result<bool>> AddOrUpdateAsync(ArchiveAddOrUpdateDTO archiveAddDto)
        {
            var mapped = mapper.Map<Archive>(archiveAddDto);
            if (mapped.Repair == null)
                return Result.Fail<bool>("Некорректный repair id");

            var existed = archiveRepository.GetById(archiveAddDto.Id);
            if (existed != null)
            {
                mapper.Map(archiveAddDto, existed);
                await archiveRepository.SaveChangesAsync();
            }
            else
            {
                mapped.Id = 0;
                await archiveRepository.AddAsync(mapped);
                await archiveRepository.SaveChangesAsync();
            }

            return Result.Ok(true);
        }

        public async Task RemoveAsync(int id)
        {
            var existed = archiveRepository.GetById(id);
            if (existed != null)
            {
                archiveRepository.Remove(existed);
                await archiveRepository.SaveChangesAsync();
            }
        }
    }
}
