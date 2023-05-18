using API.Infrastructure;
using API.Modules.Workers.Adapters;
using API.Modules.Workers.Mapper;
using API.Modules.Workers.Ports;

namespace API.Modules.Workers
{
    public class WorkersModule : IModule
    {
        public IServiceCollection RegisterModule(IServiceCollection services)
        {
            services.AddScoped<IWorkersRepository, WorkersRepository>();
            services.AddScoped<IWorkersService, WorkersService>();
            services.AddAutoMapper(typeof(WorkersMappingProfile));

            return services;
        }
    }
}
