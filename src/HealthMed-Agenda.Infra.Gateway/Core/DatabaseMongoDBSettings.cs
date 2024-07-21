using System.Diagnostics.CodeAnalysis;

namespace HealthMed_Agenda.Infra.Gateway.Core
{
    [ExcludeFromCodeCoverage]
    public class DatabaseMongoDBSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string SecretManagerKey { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;

    }
}
