using HealthMed_Agenda.Application.Core;

namespace HealthMed_Agenda.Application.UseCases.Agenda.Interfaces
{
    public interface IAgendaExcluirUseCase
    {
        Task<ServiceResult> CancelarAgendamento(string codigoAgendaMedico);
    }
}
