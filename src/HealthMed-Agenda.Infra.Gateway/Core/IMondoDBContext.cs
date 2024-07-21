using MongoDB.Driver;

namespace HealthMed_Agenda.Infra.Gateway.Core
{
    public interface IMondoDBContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
