using HealthMed_Agenda.Application.UseCases.Agenda;
using HealthMed_Agenda.Application.UseCases.Agenda.Dtos;
using HealthMed_Agenda.Domain.Adapters;
using HealthMed_Agenda.Domain.ValuesObjects;
using Moq;
using Xunit;
using AgendaEntity = HealthMed_Agenda.Domain.Entities.Agenda;
using AgendaMedicoEntity = HealthMed_Agenda.Domain.Entities.AgendaMedico;
using PacienteEntity = HealthMed_Agenda.Domain.Entities.Paciente;

namespace HealthMed_Agenda.Tests.UseCases.Agenda
{
    public class AgendaAtualizarUseCaseTests
    {
        private readonly Mock<IAgendaGateway> _agendaGatewayMock;

        public AgendaAtualizarUseCaseTests()
        {
            _agendaGatewayMock = new Mock<IAgendaGateway>();
        }

        [Fact]
        public async Task AtualizarAgendamento_WhenAgendaExists_ShouldUpdateAgenda()
        {
            // Arrange
            var id = "agendaId";
            var dto = new AgendamentoDto
            {
                PacienteNome = "John Doe",
                DataNascimento = new DateTime(1990, 1, 1),
                DDD = "11",
                Telefone = "999991234",
                Email = "john.doe@example.com",
                ModalidadeAtendimento = "Modalidade",
                Convenio = "Convenio",
                TipoAtendimento = "Tipo",
                Observacao = "Observacao",
                Status = "Status"
            };

            var agenda = new AgendaEntity
            {
                AgendaMedico = new AgendaMedicoEntity(),
                Paciente = new PacienteEntity
                {
                    PacienteNome = new NomeVo("John Doe"),
                    DataNascimento = new DateTime(1990, 1, 1),
                    Telefone = new TelefoneVo("11", "999991234"),
                    Email = new EmailVo("john.doe@example.com")
                },
                Convenio = "Convenio",
                TipoAtendimento = "Tipo",
                Observacao = "Observacao",
                Status = "Status"
            };

            _agendaGatewayMock.Setup(g => g.Get(id)).ReturnsAsync(agenda);

            var useCase = new AgendaAtualizarUseCase(_agendaGatewayMock.Object);

            // Act
            var result = await useCase.AtualizarAgendamento(id, dto);

            // Assert
            Assert.True(result.IsSuccess);
            _agendaGatewayMock.Verify(g => g.Create(agenda), Times.Once);
        }

        [Fact]
        public async Task AtualizarAgendamento_WhenAgendaDoesNotExist_ShouldReturnError()
        {
            // Arrange
            var id = "agendaId";
            var dto = new AgendamentoDto();

            _agendaGatewayMock.Setup(g => g.Get(id)).ReturnsAsync(new AgendaEntity());

            var useCase = new AgendaAtualizarUseCase(_agendaGatewayMock.Object);

            // Act
            var result = await useCase.AtualizarAgendamento(id, dto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Nome não informado!", result.Errors[0].Message);
        }
    }
}