using API.Infrastructure;
using API.Modules.Clinets.Adapters;
using API.Modules.Clinets.Mapper;
using API.Modules.Clinets.Ports;

namespace API.Modules.Clinets
{
    public class ClientsModule : IModule
    {
        public IServiceCollection RegisterModule(IServiceCollection services)
        {
            services.AddScoped<IClientsRepository, ClientsRepository>();
            services.AddScoped<IClientsService, ClientsService>();
            services.AddAutoMapper(typeof(ClientsMappingProfile));

            return services;
        }
    }
}
