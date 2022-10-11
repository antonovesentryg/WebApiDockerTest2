using MediatR;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace WebApiDockerTest2.DependencyInjection
{
    public static class Dependencies
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
