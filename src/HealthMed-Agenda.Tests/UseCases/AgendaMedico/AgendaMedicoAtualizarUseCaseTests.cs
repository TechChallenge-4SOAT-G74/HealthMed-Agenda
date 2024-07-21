using HealthMed_Agenda.Application.UseCases.AgendaMedico;
using HealthMed_Agenda.Domain.Adapters;
using MongoDB.Bson;
using Moq;
using Xunit;
using AgendaMedicoEntity = HealthMed_Agenda.Domain.Entities.AgendaMedico;
using CalendarioEntity = HealthMed_Agenda.Domain.Entities.Calendario;

namespace HealthMed_Agenda.Tests.UseCases.AgendaMedico
{
    public class AgendaMedicoAtualizarUseCaseTests
    {
        private readonly Mock<IAgendaMedicoGateway> _agendaMedicoGatewayMock;

        public AgendaMedicoAtualizarUseCaseTests()
        {
            _agendaMedicoGatewayMock = new Mock<IAgendaMedicoGateway>();
        }

        [Fact]
        public async Task AtualizarCalendario_WhenAgendaMedicoExists_ShouldUpdateCalendario()
        {
            // Arrange
            var id = ObjectId.GenerateNewId();
            var calendario = new CalendarioEntity
            {
                DataHoraConsulta = DateTime.Now,
                DuracaoConsulta = 50,
                Status = "Aberta"
            };

            var agendaMedico = new AgendaMedicoEntity
            {
                Id = id,
                Calendario = calendario
            }; // Provide a valid AgendaMedico object here

            _agendaMedicoGatewayMock.Setup(g => g.Get(id.ToString())).ReturnsAsync(agendaMedico);

            var useCase = new AgendaMedicoAtualizarUseCase(_agendaMedicoGatewayMock.Object);

            // Act
            var result = await useCase.AtualizarCalendario(id.ToString(), calendario);

            // Assert
            Assert.Empty(result.Errors);
            Assert.Equal(calendario, agendaMedico.Calendario);
            _agendaMedicoGatewayMock.Verify(g => g.Update(agendaMedico), Times.Once);
        }

        [Fact]
        public async Task AtualizarCalendario_WhenAgendaMedicoDoesNotExist_ShouldReturnError()
        {
            // Arrange
            var id = "agendaId";
            var calendario = new CalendarioEntity
            {
                DataHoraConsulta = Convert.ToDateTime("2024-07-22T 09:00:00"),
                DuracaoConsulta = 50,
                Status = "Aberta"
            };

            _agendaMedicoGatewayMock.Setup(g => g.Get(id)).ReturnsAsync(new AgendaMedicoEntity());

            var useCase = new AgendaMedicoAtualizarUseCase(_agendaMedicoGatewayMock.Object);

            // Act
            var result = await useCase.AtualizarCalendario(id, calendario);

            // Assert
            Assert.Single(result.Errors);
            Assert.Equal("Agenda não localizada.", result.Errors[0].Message);
            _agendaMedicoGatewayMock.Verify(g => g.Update(It.IsAny<AgendaMedicoEntity>()), Times.Never);
        }

    }
}