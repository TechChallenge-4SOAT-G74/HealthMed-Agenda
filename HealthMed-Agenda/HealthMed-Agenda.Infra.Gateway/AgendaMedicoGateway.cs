using HealthMed_Agenda.Domain.Adapters;
using HealthMed_Agenda.Domain.Entities;
using HealthMed_Agenda.Infra.Gateway.Core;

namespace HealthMed_Agenda.Infra.Gateway
{
    public class AgendaMedicoGateway : BaseMongoDBRepository<AgendaMedico>, IAgendaMedicoGateway
    {
        public AgendaMedicoGateway(IMondoDBContext mondoDBContext) : base(mondoDBContext)
        {
        }
    }
}
