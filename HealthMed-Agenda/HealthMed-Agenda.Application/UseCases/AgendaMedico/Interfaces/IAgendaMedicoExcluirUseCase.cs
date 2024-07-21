using HealthMed_Agenda.Application.Core;

namespace HealthMed_Agenda.Application.UseCases.AgendaMedico.Interfaces
{
    public interface IAgendaMedicoExcluirUseCase
    {
        Task<ServiceResult> CancelarAgendaMedico(string codigoAgendaMedico);
    }
}
