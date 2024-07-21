using HealthMed_Agenda.Application.Core;
using HealthMed_Agenda.Application.UseCases.Agenda.Dtos;

namespace HealthMed_Agenda.Application.UseCases.Agenda.Interfaces
{
    public interface IAgendaCriarUseCase
    {
        Task<ServiceResult> CriarAgendamento(AgendamentoDto dto);
    }
}
