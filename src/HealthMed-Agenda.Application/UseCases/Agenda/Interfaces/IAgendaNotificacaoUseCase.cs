using HealthMed_Agenda.Application.UseCases.Agenda.Dtos;

namespace HealthMed_Agenda.Application.UseCases.Agenda.Interfaces
{
    public interface IAgendaNotificacaoUseCase
    {
        void NotificaPaciente(AgendamentoDto dto);
    }
}
