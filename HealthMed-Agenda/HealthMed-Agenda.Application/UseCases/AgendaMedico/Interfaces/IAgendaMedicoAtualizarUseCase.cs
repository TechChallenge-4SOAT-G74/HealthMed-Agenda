using HealthMed_Agenda.Application.Core;
using HealthMed_Agenda.Domain.Entities;

namespace HealthMed_Agenda.Application.UseCases.AgendaMedico.Interfaces
{
    public interface IAgendaMedicoAtualizarUseCase
    {
        Task<ServiceResult> AtualizarCalendario(string id, Calendario calendario);
    }
}
