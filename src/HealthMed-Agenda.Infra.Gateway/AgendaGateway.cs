using HealthMed_Agenda.Domain.Adapters;
using HealthMed_Agenda.Domain.Entities;
using HealthMed_Agenda.Infra.Gateway.Core;

namespace HealthMed_Agenda.Infra.Gateway
{
    public class AgendaGateway : BaseMongoDBRepository<Agenda>, IAgendaGateway
    {
        public AgendaGateway(IMondoDBContext mondoDBContext) : base(mondoDBContext)
        {
        }
    }
}
