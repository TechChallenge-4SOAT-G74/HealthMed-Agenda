﻿
using HealthMed_Agenda.Domain.Entities;

namespace HealthMed_Agenda.Domain.Adapters
{
    public interface IAgendaGateway : IBaseMongoDBRepository<Agenda>
    {
    }
}
