using HealthMed_Agenda.Ioc;
using System.Diagnostics.CodeAnalysis;

namespace HealthMed_Agenda.Api.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            RootBootstrapper.BootstrapperRegisterServices(services, typeof(RootBootstrapper).Assembly.GetNoAbstractTypes());
        }
    }
}
