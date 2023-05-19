using API.Infrastructure;
using API.Modules.Archives.Adapters;
using API.Modules.Archives.Mapper;
using API.Modules.Archives.Ports;

namespace API.Modules.Archives
{
    public class ArchivesModule : IModule
    {
        public IServiceCollection RegisterModule(IServiceCollection services)
        {
            services.AddScoped<IArchiveRepository, ArchiveRepository>();
            services.AddScoped<IArchivesService, ArchiveService>();
            services.AddAutoMapper(typeof(ArchiveMappingProfile));

            return services;
        }
    }
}
