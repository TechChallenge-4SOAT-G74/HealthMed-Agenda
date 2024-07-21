using HealthMed_Agenda.Application.Core;
using HealthMed_Agenda.Application.UseCases.AgendaMedico.Dtos;

namespace HealthMed_Agenda.Application.UseCases.AgendaMedico.Interfaces
{
    public interface IAgendaMedicoObterUseCase
    {
        Task<ServiceResult<List<AgendaMedicoDto>>> ConsultarAgendaMedico(string nomeOrCrmOrEspecialidade);
        Task<ServiceResult<List<AgendaMedicoDto>>> ConsultarListaAgendaMedicos();
    }
}
