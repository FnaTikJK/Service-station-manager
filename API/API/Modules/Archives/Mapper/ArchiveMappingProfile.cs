using API.Modules.Archives.Core;
using API.Modules.Archives.DTO;
using AutoMapper;

namespace API.Modules.Archives.Mapper
{
    public class ArchiveMappingProfile : Profile
    {
        public ArchiveMappingProfile()
        {
            CreateMap<ArchiveAddOrUpdateDTO, Archive>()
                .ForMember(dest => dest.Repair, opt => opt.MapFrom(src => src.RepairId));
            CreateMap<Archive, ArchiveDTO>()
                .ForMember(dest => dest.Repair, opt => opt.MapFrom(src => src.Repair));
        }
    }
}
