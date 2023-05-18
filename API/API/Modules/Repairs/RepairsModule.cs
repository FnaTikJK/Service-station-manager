using API.Infrastructure;
using API.Modules.Repairs.Adapters;
using API.Modules.Repairs.Mapper;
using API.Modules.Repairs.Ports;

namespace API.Modules.Repairs
{
    public class RepairsModule : IModule
    {
        public IServiceCollection RegisterModule(IServiceCollection services)
        {
            services.AddScoped<IRepairsRepository, RepairsRepository>();
            services.AddScoped<IRepairsService, RepairsService>();
            services.AddAutoMapper(typeof(RepairMappingProfile));

            return services;
        }
    }
}
