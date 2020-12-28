using InfoPortal.BLL.Services.Implementations;
using InfoPortal.BLL.Services.Interfaces;
using InfoPortal.DAL.Repositories.Implementations;
using InfoPortal.DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace InfoPortal.DI
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection IoCRegistry(this IServiceCollection services)
        {      
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IArticleService, ArticleService>();

            services.AddScoped<IFileRepository, FileRepository>();

            services.AddScoped<IThemeRepository, ThemeRepository>();
            services.AddScoped<IThemeService, ThemeService>();

            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ILanguageService, LanguageService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
