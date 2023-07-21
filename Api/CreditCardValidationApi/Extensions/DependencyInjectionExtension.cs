using CreditCardValidationBL.Services;

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
            services.AddTransient<ICreditCartValidationService, CreditCartValidationService>();
            return services;
        }
    }
}
