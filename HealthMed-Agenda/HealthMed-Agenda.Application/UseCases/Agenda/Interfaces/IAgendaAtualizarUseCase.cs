using HealthMed_Agenda.Application.Core;
using HealthMed_Agenda.Application.UseCases.Agenda.Dtos;

namespace HealthMed_Agenda.Application.UseCases.Agenda.Interfaces
{
    public interface IAgendaAtualizarUseCase
    {
        Task<ServiceResult> AtualizarAgendamento(string id, AgendamentoDto dto);
    }
}
