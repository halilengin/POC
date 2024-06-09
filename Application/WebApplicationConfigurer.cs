using Data;
using Framework.Data.Repository;
using Framework.Data.UnitOfWork;
using Framework.Service.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class WebApplicationConfigurer
    {
        public static void AddConfiguration(this IServiceCollection services)
        {
            services.AddDbContext<POCContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
        }
    }
}
