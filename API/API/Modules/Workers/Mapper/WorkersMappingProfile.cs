using API.Modules.Workers.Core;
using API.Modules.Workers.DTO;
using API.Modules.Workers.Ports;
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
            CreateMap<Worker, WorkerShortDTO>()
                .ForMember(dest => dest.SecondNameWithInitials,
                    opt => opt.MapFrom(src => $"{src.SecondName} {src.FirstName.First()}.{src.ThirdName.First()}."));
        }

        public class WorkersConverter : IValueConverter<int, Worker>
        {
            private readonly IWorkersRepository workersRepository;

            public WorkersConverter(IWorkersRepository workersRepository)
            {
                this.workersRepository = workersRepository;
            }

            public Worker? Convert(int sourceMember, ResolutionContext context)
            {
                return workersRepository.GetWorkerById(sourceMember);
            }
        }
    }
}
