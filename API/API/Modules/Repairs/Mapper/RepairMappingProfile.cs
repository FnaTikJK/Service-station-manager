using API.Modules.Clinets.Mapper;
using API.Modules.Repairs.Core;
using API.Modules.Repairs.DTO;
using API.Modules.Repairs.Ports;
using API.Modules.Workers.Mapper;
using AutoMapper;

namespace API.Modules.Repairs.Mapper
{
    public class RepairMappingProfile : Profile
    {
        public RepairMappingProfile()
        {
            CreateMap<RepairAddOrUpdateDTO, Repair>()
                .ForMember(dest => dest.Worker,
                    opt => opt.ConvertUsing<WorkersMappingProfile.WorkersConverter, int>(src => src.WorkerId))
                .ForMember(dest => dest.Client,
                    opt => opt.ConvertUsing<ClientsMappingProfile.ClientsConverter, int>(src => src.ClientId))
                .ForMember(dest => dest.Services, 
                    opt => opt.MapFrom(src => src.ServiceIds))
                .ForMember(dest => dest.Start, opt => opt.MapFrom(src => src.Start));
            CreateMap<Repair, RepairOutDTO>()
                .ForMember(dest => dest.Worker, opt => opt.MapFrom(src => src.Worker))
                .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client))
                .ForMember(dest => dest.Services, opt => opt.MapFrom(src => src.Services))
                .ForMember(dest => dest.Start, opt => opt.MapFrom(src => src.Start));
            CreateMap<int, Repair>().ConvertUsing(typeof(RepairMappingConverter));
        }

        private class RepairMappingConverter : ITypeConverter<int, Repair>
        {
            private readonly IRepairsRepository repairsRepository;

            public RepairMappingConverter(IRepairsRepository repairsRepository)
            {
                this.repairsRepository = repairsRepository;
            }

            public Repair? Convert(int source, Repair destination, ResolutionContext context)
            {
                return repairsRepository.GetById(source);
            }
        }
    }
}
