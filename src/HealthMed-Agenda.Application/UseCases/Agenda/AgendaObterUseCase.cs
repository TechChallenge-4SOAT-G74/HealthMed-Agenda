using HealthMed_Agenda.Application.Core;
using HealthMed_Agenda.Application.UseCases.Agenda.Dtos;
using HealthMed_Agenda.Application.UseCases.Agenda.Interfaces;
using HealthMed_Agenda.Domain.Adapters;
using System.Diagnostics.CodeAnalysis;
using AgendaEntity = HealthMed_Agenda.Domain.Entities.Agenda;

namespace HealthMed_Agenda.Application.UseCases.Agenda
{
    [ExcludeFromCodeCoverage]
    public class AgendaObterUseCase(IAgendaGateway agendaGateway) : IAgendaObterUseCase
    {
        private readonly IAgendaGateway _agendaGateway = agendaGateway;

        public async Task<ServiceResult<List<AgendamentoDto>>> ConsultarAgendamentoCliente(string nomeOrEmail)
        {
            var result = new ServiceResult<List<AgendamentoDto>>();
            try
            {
                var agenda = await _agendaGateway.GetList("Paciente.PacienteNome.Nome", nomeOrEmail);
                if (agenda == null || !agenda.Any()) agenda = await _agendaGateway.GetList("Paciente.Email.Endereco", nomeOrEmail);

                if (agenda == null || !agenda.Any())
                {
                    result.AddError("Agendamento não localizada");
                    return result;
                }

                List<AgendamentoDto> listaAgenda = GeraAgendaDto(agenda);
                result.Data = listaAgenda;

            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;


        }

        public async Task<ServiceResult<List<AgendamentoDto>>> ConsultarAgendamentos()
        {
            var result = new ServiceResult<List<AgendamentoDto>>();
            try
            {
                var agenda = await _agendaGateway.GetAll();

                if (agenda == null || !agenda.Any())
                {
                    result.AddError("Agendamento não localizada");
                    return result;
                }

                List<AgendamentoDto> listaAgenda = GeraAgendaDto(agenda);
                result.Data = listaAgenda;

            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }

        public async Task<ServiceResult<List<AgendamentoDto>>> ConsultarAgendaMedico(string nomeOrCrmOrEspecialidade)
        {
            var result = new ServiceResult<List<AgendamentoDto>>();
            try
            {
                var agenda = await _agendaGateway.GetList("AgendaMedico.Medico.MedicoNome", nomeOrCrmOrEspecialidade);
                if (agenda == null || !agenda.Any()) agenda = await _agendaGateway.GetList("AgendaMedico.Medico.MedicoRegistro", nomeOrCrmOrEspecialidade);
                if (agenda == null || !agenda.Any()) agenda = await _agendaGateway.GetList("AgendaMedico.Medico.MedicoEspecialidade", nomeOrCrmOrEspecialidade);

                if (agenda == null || !agenda.Any())
                {
                    result.AddError("Agendamento não localizada");
                    return result;
                }

                List<AgendamentoDto> listaAgenda = GeraAgendaDto(agenda);
                result.Data = listaAgenda;

            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }

        public async Task<ServiceResult<List<AgendamentoDto>>> ConsultarAgendaMedicoPorDistancia(string localidadePaciente)
        {
            var result = new ServiceResult<List<AgendamentoDto>>();
            try
            {
                var agenda = await _agendaGateway.GetList("AgendaMedico.Geolocallizacao", localidadePaciente);

                if (agenda == null || !agenda.Any())
                {
                    result.AddError("Agendamento não localizada");
                    return result;
                }

                List<AgendamentoDto> listaAgenda = GeraAgendaDto(agenda);
                result.Data = listaAgenda;

            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }
        private static List<AgendamentoDto> GeraAgendaDto(IEnumerable<AgendaEntity> agenda)
        {
            var listaAgenda = new List<AgendamentoDto>();


            foreach (var item in agenda)
            {
                var agendaDto = new AgendamentoDto
                {
                    IdAgendamento = item.Id.ToString(),
                    MedicoNome = item.AgendaMedico?.Medico?.MedicoNome,
                    MedicoEspecialidade = item.AgendaMedico?.Medico?.MedicoEspecialidade,
                    MedicoRegistro = item.AgendaMedico?.Medico?.MedicoRegistro,
                    DataHoraConsulta = item.AgendaMedico?.Calendario?.DataHoraConsulta,
                    PacienteNome = item.Paciente?.PacienteNome?.Nome,
                    DataNascimento = item.Paciente?.DataNascimento,
                    Telefone = $"({item.Paciente?.Telefone?.DDD}) {item.Paciente?.Telefone?.Numero}",
                    Email = item.Paciente?.Email?.Endereco,
                    Convenio = item.Convenio,
                    Status = item.Status,
                    Observacao = item.Observacao,
                    LinkTeleAtendimento = item.LinkTeleAtendimento,
                    TipoAtendimento = item.TipoAtendimento
                };

                listaAgenda.Add(agendaDto);

            }

            return listaAgenda;
        }

    }
}
