using CreditCardValidationBL.Services;
using CreditCardValidationBL.Services.Types;

namespace CreditCardValidationApi.Extensions
{
    public static class DependencyInjectionExtension
    {
        /// <summary>
        /// Use this static function to add dependencies. Extension to register dependenices without editing the program.cs
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection InjectDependencies(this IServiceCollection services)
        {
            services.AddTransient<ICreditCardValidationService, AmexCardValidationService>();
            services.AddTransient<ICreditCardValidationService, MasterCardValidationService>();
            services.AddTransient<ICreditCardValidationService, DiscoverCardValidationService>();
            services.AddTransient<ICreditCardValidationService, VisaCardValidationService>();
            return services;
        }
    }
}
