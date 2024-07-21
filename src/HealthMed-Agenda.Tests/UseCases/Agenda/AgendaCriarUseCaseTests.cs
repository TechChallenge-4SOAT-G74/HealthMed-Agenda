using HealthMed_Agenda.Application.UseCases.Agenda;
using HealthMed_Agenda.Application.UseCases.Agenda.Dtos;
using HealthMed_Agenda.Application.UseCases.Agenda.Interfaces;
using HealthMed_Agenda.Domain.Adapters;
using HealthMed_Agenda.Domain.ValuesObjects;
using Moq;
using Xunit;
using AgendaEntity = HealthMed_Agenda.Domain.Entities.Agenda;
using AgendaMedicoEntity = HealthMed_Agenda.Domain.Entities.AgendaMedico;
using CalendarioEntity = HealthMed_Agenda.Domain.Entities.Calendario;
using MedicoEntity = HealthMed_Agenda.Domain.Entities.Medico;
using PacienteEntity = HealthMed_Agenda.Domain.Entities.Paciente;


namespace HealthMed_Agenda.Tests.UseCases.Agenda
{
    public class AgendaCriarUseCaseTests
    {
        private readonly Mock<IAgendaGateway> _agendaGatewayMock;
        private readonly Mock<IAgendaMedicoGateway> _agendamedicoGatewayMock;
        private readonly Mock<IAgendaNotificacaoUseCase> _agendaNotificacaoUseCaseMock;

        public AgendaCriarUseCaseTests()
        {
            _agendaGatewayMock = new Mock<IAgendaGateway>();
            _agendamedicoGatewayMock = new Mock<IAgendaMedicoGateway>();
            _agendaNotificacaoUseCaseMock = new Mock<IAgendaNotificacaoUseCase>();
        }

        [Fact]
        public async Task CriarAgendamento_WhenAgendaMedicoNotFound_ReturnsError()
        {
            // Arrange
            var dto = new AgendamentoDto
            {
                MedicoNome = "John Doe",
                MedicoRegistro = "12345",
                DataHoraConsulta = DateTime.Now,
                PacienteNome = "Jane Smith",
                Email = "jane@example.com",
                Telefone = "1234567890",
                DDD = "11",
                TipoAtendimento = "Consulta",
                Status = "Agendado",
                Observacao = "Please bring your medical records",
                LinkTeleAtendimento = "https://example.com/teleconsultation"
            };

            _agendamedicoGatewayMock.Setup(g => g.GetList("Medico.MedicoNome", dto.MedicoNome)).ReturnsAsync([]);
            _agendamedicoGatewayMock.Setup(g => g.GetList("Medico.MedicoRegistro", dto.MedicoRegistro)).ReturnsAsync([]);


            var useCase = new AgendaCriarUseCase(_agendaGatewayMock.Object, _agendamedicoGatewayMock.Object, _agendaNotificacaoUseCaseMock.Object);

            // Act
            var result = await useCase.CriarAgendamento(dto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Agenda do Médico não localizada", result.Errors[0].Message);
        }

        [Fact]
        public async Task CriarAgendamento_WhenAgendaMedicoFound_CreatesAgendaAndNotifiesPaciente()
        {
            var dto = new AgendamentoDto
            {
                MedicoNome = "John Doe",
                MedicoRegistro = "12345",
                DataHoraConsulta = Convert.ToDateTime("2024-07-22T 09:00:00"),
                PacienteNome = "Jane Smith",
                Email = "jane@example.com",
                Telefone = "999991234",
                DDD = "11",
                TipoAtendimento = "Consulta",
                Status = "Agendado",
                Observacao = "Please bring your medical records",
                LinkTeleAtendimento = "https://example.com/teleconsultation"
            };

            // Arrange
            var agendamedico = new AgendaMedicoEntity
            {
                Medico = new MedicoEntity
                {
                    MedicoNome = "John Doe",
                    MedicoRegistro = "12345",
                    TipoAtendimentos = ["Consulta"],
                    ModalidadeAtendimentos = ["Presencial"],
                    Convenios = ["convenio"],
                },
                Calendario = new CalendarioEntity
                {
                    DataHoraConsulta = Convert.ToDateTime("2024-07-22T 09:00:00"),
                    DuracaoConsulta = 50,
                    Status = "Aberta"
                }
            };


            var agenda = new AgendaEntity
            {
                AgendaMedico = agendamedico,
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

            _agendamedicoGatewayMock.Setup(g => g.GetList("Medico.MedicoNome", dto.MedicoNome)).ReturnsAsync([agendamedico]);
            _agendamedicoGatewayMock.Setup(g => g.GetList("Medico.MedicoRegistro", dto.MedicoRegistro)).ReturnsAsync([]);

            _agendaGatewayMock.Setup(g => g.Create(It.IsAny<AgendaEntity>())).Returns(Task.CompletedTask);

            _agendaNotificacaoUseCaseMock.Setup(u => u.NotificaPaciente(dto));

            var useCase = new AgendaCriarUseCase(_agendaGatewayMock.Object, _agendamedicoGatewayMock.Object, _agendaNotificacaoUseCaseMock.Object);

            // Act
            var result = await useCase.CriarAgendamento(dto);

            // Assert
            Assert.True(result.IsSuccess);
            // Add more assertions as needed
        }
    }
}