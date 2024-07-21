using HealthMed_Agenda.Application.UseCases.Agenda.Dtos;
using HealthMed_Agenda.Application.UseCases.Agenda.Interfaces;
using HealthMed_Agenda.Infra.MQ;

namespace HealthMed_Agenda.Application.UseCases.Agenda
{
    public class AgendaNotificacaoUseCase(IRabbitMqPub<AgendamentoDto> rabbitMqPub) : IAgendaNotificacaoUseCase
    {
        private readonly IRabbitMqPub<AgendamentoDto> _rabbitMqPub = rabbitMqPub;

        public void NotificaPaciente(AgendamentoDto dto)
        {

            var agendamento = new AgendamentoDto
            {
                MedicoNome = dto.MedicoNome,
                MedicoRegistro = dto.MedicoRegistro,
                DataHoraConsulta = dto.DataHoraConsulta,
                PacienteNome = dto.PacienteNome,
                Email = dto.Email,
                Telefone = $"({dto.DDD}) {dto.Telefone}",
                TipoAtendimento = dto.TipoAtendimento,
                Status = dto.Status,
                Observacao = dto.Observacao,
                LinkTeleAtendimento = dto.LinkTeleAtendimento,
            };

            _rabbitMqPub.Publicar(agendamento, "Agendamento", "Agendamento_Consulta");
        }
    }
}
