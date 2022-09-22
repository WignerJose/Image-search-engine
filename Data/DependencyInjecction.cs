using ImageFinder.Data.ConfigService;

namespace ImageFinder.Data
{
    public static class DependencyInjecction
    {
        public static IServiceCollection AddDependencyInjecction(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IImageFinderService, ImageFinderService>();
            services.AddSingleton<WeatherForecastService>();
            services.Configure<ConfigurationService>(configuration.GetSection("ConnectionStrings"));
            return services;
        }
    }
}
