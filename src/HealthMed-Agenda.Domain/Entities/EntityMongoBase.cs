using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Diagnostics.CodeAnalysis;

namespace HealthMed_Agenda.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class EntityMongoBase
    {
        public EntityMongoBase()
        {
            Id = ObjectId.GenerateNewId();
        }

        [BsonId]
        public ObjectId Id { get; set; }
    }
}
