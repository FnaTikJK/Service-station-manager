using API.Modules.Workers.Core;
using API.Modules.Workers.DTO;
using AutoMapper;

namespace API.Modules.Workers.Mapper
{
    public class WorkersMappingProfile : Profile
    {
        public WorkersMappingProfile()
        {
            CreateMap<Worker, WorkerDTO>().ForMember(dest => dest.BirthDate, 
                opt => opt.MapFrom(src => DateOnly.FromDateTime(src.BirthDate)));
            CreateMap<WorkerDTO, Worker>().ForMember(dest => dest.BirthDate,
                opt => opt.MapFrom(src => src.BirthDate.ToDateTime(new TimeOnly())));
        }
    }
}
