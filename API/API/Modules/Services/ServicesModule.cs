using API.Infrastructure;
using API.Modules.Services.Adapters;
using API.Modules.Services.Mapper;
using API.Modules.Services.Ports;

namespace API.Modules.Services
{
    public class ServicesModule : IModule
    {
        public IServiceCollection RegisterModule(IServiceCollection services)
        {
            services.AddScoped<IServicesRepository, ServicesRepository>();
            services.AddScoped<IServicesService, ServicesService>();
            services.AddAutoMapper(typeof(ServicesMappingProfile));

            return services;
        }
    }
}
