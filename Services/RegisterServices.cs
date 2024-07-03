using Practica2.Interfaces;
using System.Runtime.CompilerServices;

namespace Practica2.Services
{
    public static class RegisterServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            var assembly= typeof(IRepository<>).Assembly;
            services.Scan((x) => x.FromAssemblies(assembly).AddClasses((c) => c.AssignableTo(typeof(IRepository<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
            return services;
        }
    }
}
