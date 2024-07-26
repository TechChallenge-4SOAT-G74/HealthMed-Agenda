using HealthMed_Agenda.Application.Core;
using HealthMed_Agenda.Application.UseCases.AgendaMedico.Interfaces;
using HealthMed_Agenda.Domain.Adapters;
using HealthMed_Agenda.Domain.Entities;
using HealthMed_Agenda.Domain.Enums;

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

        public async Task<ServiceResult> ConfirmaCancelaAgendamento(string id)
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

                agendaMedico.Calendario.Status = agendaMedico.Calendario.Status == EStatusAgenda.Confirmado.ToString() ? EStatusAgenda.Cancelado.ToString() : EStatusAgenda.Confirmado.ToString();

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
