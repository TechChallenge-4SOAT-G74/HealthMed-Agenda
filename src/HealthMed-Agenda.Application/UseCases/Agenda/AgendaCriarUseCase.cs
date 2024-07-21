using HealthMed_Agenda.Application.Core;
using HealthMed_Agenda.Application.UseCases.Agenda.Dtos;
using HealthMed_Agenda.Application.UseCases.Agenda.Interfaces;
using HealthMed_Agenda.Domain.Adapters;
using HealthMed_Agenda.Domain.Enums;
using HealthMed_Agenda.Domain.ValuesObjects;
using System.Security.Cryptography;
using AgendaEntity = HealthMed_Agenda.Domain.Entities.Agenda;
using PacienteEntity = HealthMed_Agenda.Domain.Entities.Paciente;

namespace HealthMed_Agenda.Application.UseCases.Agenda
{
    public class AgendaCriarUseCase(IAgendaGateway agendaGateway, IAgendaMedicoGateway agendamedicoGateway, IAgendaNotificacaoUseCase agendaNotificacaoUseCase) : IAgendaCriarUseCase
    {
        private readonly IAgendaGateway _agendaGateway = agendaGateway;
        private readonly IAgendaMedicoGateway _agendamedicoGateway = agendamedicoGateway;
        private readonly IAgendaNotificacaoUseCase _agendaNotificacaoUseCase = agendaNotificacaoUseCase;

        public async Task<ServiceResult> CriarAgendamento(AgendamentoDto dto)
        {
            var result = new ServiceResult();
            try
            {
                var agendaMedico = await _agendamedicoGateway.GetList("Medico.MedicoNome", dto.MedicoNome);
                agendaMedico ??= await _agendamedicoGateway.GetList("Medico.MedicoRegistro", dto.MedicoRegistro);

                agendaMedico = agendaMedico.Where(x => x.Calendario?.DataHoraConsulta == dto.DataHoraConsulta);

                if (!agendaMedico.Any())
                {
                    result.AddError("Agenda do Médico não localizada");
                    return result;
                }

                var agenda = new AgendaEntity
                {
                    AgendaMedico = agendaMedico.FirstOrDefault(),
                    Paciente = new PacienteEntity
                    {
                        PacienteNome = new NomeVo(dto.PacienteNome),
                        DataNascimento = dto.DataNascimento,
                        Telefone = new TelefoneVo(dto.DDD, dto.Telefone),
                        Email = new EmailVo(dto.Email)
                    },
                    ModalidadeAtendimento = dto.ModalidadeAtendimento,
                    Convenio = dto.Convenio,
                    TipoAtendimento = dto.TipoAtendimento,
                    Observacao = dto.Observacao,
                    Status = dto.Status
                };

                if (dto.ModalidadeAtendimento == EModalidadeAtendimento.Teleatendimento.ToDescriptionString())
                    agenda.LinkTeleAtendimento = GerarLinkTeleAtendimento;


                await _agendaGateway.Create(agenda);

                _agendaNotificacaoUseCase.NotificaPaciente(dto);
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }

        private string GerarLinkTeleAtendimento
        {
            get
            {
                var salaFake = RandomNumberGenerator.GetString("ldu-ldjd-hdg", 12);
                return $"https://meet.google.com/{salaFake}?authuser=0&pli=1";
            }
        }
    }
}
