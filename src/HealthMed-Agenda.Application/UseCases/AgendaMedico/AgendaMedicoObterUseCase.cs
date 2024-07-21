using HealthMed_Agenda.Application.Core;
using HealthMed_Agenda.Application.UseCases.AgendaMedico.Dtos;
using HealthMed_Agenda.Application.UseCases.AgendaMedico.Interfaces;
using HealthMed_Agenda.Domain.Adapters;
using System.Diagnostics.CodeAnalysis;

namespace HealthMed_Agenda.Application.UseCases.AgendaMedico
{
    [ExcludeFromCodeCoverage]
    public class AgendaMedicoObterUseCase : IAgendaMedicoObterUseCase
    {
        private readonly IAgendaMedicoGateway _agendaMedicoGateway;

        public AgendaMedicoObterUseCase(IAgendaMedicoGateway agendaMedicoGateway)
        {
            _agendaMedicoGateway = agendaMedicoGateway;
        }

        public async Task<ServiceResult<List<AgendaMedicoDto>>> ConsultarAgendaMedico(string nomeOrCrmOrEspecialidade)
        {
            var result = new ServiceResult<List<AgendaMedicoDto>>();
            try
            {
                var agendaMedico = await _agendaMedicoGateway.GetList("Medico.MedicoNome", nomeOrCrmOrEspecialidade);

                if (agendaMedico == null || !agendaMedico.Any())
                    agendaMedico = await _agendaMedicoGateway.GetList("Medico.MedicoRegistro", nomeOrCrmOrEspecialidade);
                if (agendaMedico == null || !agendaMedico.Any())
                    agendaMedico = await _agendaMedicoGateway.GetList("Medico.MedicoEspecialidade", nomeOrCrmOrEspecialidade);


                if (agendaMedico == null || !agendaMedico.Any())
                {
                    result.AddError("Agenda do Médico não localizada");
                    return result;
                }

                List<AgendaMedicoDto> listaAgendaMedico = GerarDto(agendaMedico);
                result.Data = listaAgendaMedico;

            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }

        public async Task<ServiceResult<List<AgendaMedicoDto>>> ConsultarListaAgendaMedicos()
        {
            var result = new ServiceResult<List<AgendaMedicoDto>>();
            try
            {
                var agendaMedico = await _agendaMedicoGateway.GetAll();


                if (agendaMedico == null || !agendaMedico.Any())
                {
                    result.AddError("Agendas dos Médicos não localizada");
                    return result;
                }

                List<AgendaMedicoDto> listaAgendaMedico = GerarDto(agendaMedico);
                result.Data = listaAgendaMedico;
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }

        private static List<AgendaMedicoDto> GerarDto(IEnumerable<Domain.Entities.AgendaMedico> agendaMedico)
        {
            var listaAgendaMedico = new List<AgendaMedicoDto>();

            foreach (var item in agendaMedico)
            {
                var agendaMedicoDto = new AgendaMedicoDto
                {
                    IdAgendaMedico = item.Id.ToString(),
                    MedicoNome = item.Medico?.MedicoNome,
                    MedicoEspecialidade = item.Medico?.MedicoEspecialidade,
                    MedicoRegistro = item.Medico?.MedicoRegistro,
                    ModalidadeAtendimentos = item.Medico?.ModalidadeAtendimentos,
                    TipoAtendimentos = item.Medico?.TipoAtendimentos,
                    Convenios = item.Medico?.Convenios,
                    Calendario = item.Calendario
                };

                listaAgendaMedico.Add(agendaMedicoDto);
            }

            return listaAgendaMedico;
        }
    }
}
