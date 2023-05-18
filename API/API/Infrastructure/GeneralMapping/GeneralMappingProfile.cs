using AutoMapper;

namespace API.Infrastructure.GeneralMapping
{
    public class GeneralMappingProfile : Profile
    {
        public GeneralMappingProfile()
        {
            CreateMap<DateTime, DateOnly>().ConvertUsing(src => DateOnly.FromDateTime(src));
            CreateMap<DateOnly, DateTime>().ConvertUsing(src => src.ToDateTime(new TimeOnly()));
        }
    }
}
