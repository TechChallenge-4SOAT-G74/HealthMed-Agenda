using HealthMed_Agenda.Api.Controllers;
using System.Diagnostics.CodeAnalysis;

namespace HealthMed_Agenda.Api.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class EndpointsConfig
    {
        public static void AddEndpointsConfiguration(this WebApplication app)
        {
            app.MapHealthChecks("/api/health");
            app.MapAgendaMedicoEndpoints("/api/agendamedico");
            app.MapAgendaEndpoints("/api/agenda");
        }
    }
}