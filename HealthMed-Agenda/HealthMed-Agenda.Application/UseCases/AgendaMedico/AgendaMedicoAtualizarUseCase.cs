using HealthMed_Agenda.Application.Core;
using HealthMed_Agenda.Application.UseCases.AgendaMedico.Interfaces;
using HealthMed_Agenda.Domain.Adapters;
using HealthMed_Agenda.Domain.Entities;

namespace HealthMed_Agenda.Application.UseCases.AgendaMedico
{
    public class AgendaMedicoAtualizarUseCase(IAgendaMedicoGateway agendaMedicoGateway) : IAgendaMedicoAtualizarUseCase
    {
        private readonly IAgendaMedicoGateway _agendaMedicoGateway = agendaMedicoGateway;

        public async Task<ServiceResult> AtualizarCalendario(string id, Calendario calendario)
        {
            var result = new ServiceResult();
            try
            {
                var agendaMedico = await _agendaMedicoGateway.Get(id);

                if (agendaMedico == null || agendaMedico.Id.ToString() != id)
                {
                    result.AddError("Agenda não localizada.");
                    return result;
                }

                agendaMedico.Calendario = calendario;

                _agendaMedicoGateway.Update(agendaMedico);
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }

    }
}
