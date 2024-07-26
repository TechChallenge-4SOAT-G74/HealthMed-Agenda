using HealthMed_Agenda.Application.Core;
using HealthMed_Agenda.Application.UseCases.Agenda.Dtos;

namespace HealthMed_Agenda.Application.UseCases.Agenda.Interfaces
{
    public interface IAgendaObterUseCase
    {
        Task<ServiceResult<List<AgendamentoDto>>> ConsultarAgendamentoCliente(string nomeOrEmail);
        Task<ServiceResult<List<AgendamentoDto>>> ConsultarAgendaMedico(string nomeOrCrmOrEspecialidade);
        Task<ServiceResult<List<AgendamentoDto>>> ConsultarAgendaMedicoPorDistancia(string localidadePaciente);
        Task<ServiceResult<List<AgendamentoDto>>> ConsultarAgendamentos();
    }
}
