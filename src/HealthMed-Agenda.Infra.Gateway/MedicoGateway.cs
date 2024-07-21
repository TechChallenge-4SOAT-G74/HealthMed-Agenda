using HealthMed_Agenda.Domain.Adapters;
using HealthMed_Agenda.Domain.Entities;
using HealthMed_Agenda.Infra.Gateway.Core;

namespace HealthMed_Agenda.Infra.Gateway
{
    public class MedicoGateway : BaseMongoDBRepository<Medico>, IMedicoGateway
    {
        public MedicoGateway(IMondoDBContext mondoDBContext) : base(mondoDBContext)
        {
        }
    }
}
