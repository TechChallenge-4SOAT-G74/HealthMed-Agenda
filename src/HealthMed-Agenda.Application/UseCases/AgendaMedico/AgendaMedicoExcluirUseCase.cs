using HealthMed_Agenda.Application.Core;
using HealthMed_Agenda.Application.UseCases.AgendaMedico.Interfaces;
using HealthMed_Agenda.Domain.Adapters;

namespace HealthMed_Agenda.Application.UseCases.AgendaMedico
{
    public class AgendaMedicoExcluirUseCase(IAgendaMedicoGateway agendaMedicoGateway) : IAgendaMedicoExcluirUseCase
    {
        private readonly IAgendaMedicoGateway _agendaMedicoGateway = agendaMedicoGateway;

        public async Task<ServiceResult> CancelarAgendaMedico(string codigoAgendaMedico)
        {
            var result = new ServiceResult();
            try
            {
                var agendaMedico = await _agendaMedicoGateway.Get(codigoAgendaMedico);

                if (agendaMedico == null || agendaMedico.Id.ToString() != codigoAgendaMedico)
                {
                    result.AddError("Agenda Médico não encontrada.");
                    return result;
                }
                _agendaMedicoGateway.Delete(agendaMedico.Id.ToString());
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }
    }
}
