using HealthMed_Agenda.Application.Core;
using HealthMed_Agenda.Application.UseCases.Agenda.Dtos;
using HealthMed_Agenda.Application.UseCases.Agenda.Interfaces;
using HealthMed_Agenda.Domain.Adapters;
using HealthMed_Agenda.Domain.ValuesObjects;

namespace HealthMed_Agenda.Application.UseCases.Agenda
{
    public class AgendaAtualizarUseCase(IAgendaGateway agendaGateway) : IAgendaAtualizarUseCase
    {
        private readonly IAgendaGateway _agendaGateway = agendaGateway;

        public async Task<ServiceResult> AtualizarAgendamento(string id, AgendamentoDto dto)
        {
            var result = new ServiceResult();
            try
            {
                var agenda = await _agendaGateway.Get(id);
                if (agenda == null)
                {
                    result.AddError("Agendamento não localizada");
                    return result;
                }

                agenda.Paciente.PacienteNome = new NomeVo(dto.PacienteNome);
                agenda.Paciente.DataNascimento = dto.DataNascimento;
                agenda.Paciente.Telefone = new TelefoneVo(dto.DDD, dto.Telefone);
                agenda.Paciente.Email = new EmailVo(dto.Email);
                agenda.ModalidadeAtendimento = dto.ModalidadeAtendimento;
                agenda.Convenio = dto.Convenio;
                agenda.TipoAtendimento = dto.TipoAtendimento;
                agenda.Observacao = dto.Observacao;
                agenda.Status = dto.Status;

                await _agendaGateway.Create(agenda);

            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }

    }
}
