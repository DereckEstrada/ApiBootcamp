using Practica2.Interfaces;
using System.Runtime.CompilerServices;

namespace Practica2.Services
{
    public static class RegisterServices
    {
        //Llamando este metodo en el program cargara todas las clases que implementen IAssembly 
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            var assembly = typeof(IAssembly<>).Assembly;
            services.Scan((x) => x.FromAssemblies(assembly).AddClasses((c) => c.AssignableTo(typeof(IAssembly<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
            return services;
        }
    }
}
