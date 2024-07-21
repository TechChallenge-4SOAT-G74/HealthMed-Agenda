using HealthMed_Agenda.Application.Core;
using HealthMed_Agenda.Application.UseCases.AgendaMedico.Dtos;

namespace HealthMed_Agenda.Application.UseCases.AgendaMedico.Interfaces
{
    public interface IAgendaMedicoCriarUseCase
    {
        Task<ServiceResult> CriarAgendaMedico(AgendaMedicoDto dto);
    }
}
