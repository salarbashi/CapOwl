using API.Database;
using API.Helpers.Cache;

namespace API.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddALLInjections(this IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>();
            services.AddScoped<Helpers.Configuration>();
            services.AddScoped<Helpers.DbHelper>();
            services.AddMemoryCache();
            services.AddSingleton<ICacheHelper, InMemoryCacheHelper>();

            return services;
        }
    }
}
