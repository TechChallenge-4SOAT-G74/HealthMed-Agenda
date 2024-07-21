using HealthMed_Agenda.Application.Core;
using HealthMed_Agenda.Application.UseCases.Agenda.Interfaces;
using HealthMed_Agenda.Domain.Adapters;

namespace HealthMed_Agenda.Application.UseCases.Agenda
{
    public class AgendaExcluirUseCase(IAgendaGateway agendaGateway) : IAgendaExcluirUseCase
    {
        private readonly IAgendaGateway _agendaGateway = agendaGateway;

        public async Task<ServiceResult> CancelarAgendamento(string codigoAgendaMedico)
        {
            var result = new ServiceResult();
            try
            {
                var agenda = await _agendaGateway.Get(codigoAgendaMedico);

                if (agenda == null || agenda.Id.ToString() != codigoAgendaMedico)
                {
                    result.AddError("Agendamento não encontrado.");
                    return result;
                }
                _agendaGateway.Delete(agenda.Id.ToString());
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }
    }
}
