using HealthMed_Agenda.Application.UseCases.Agenda;
using HealthMed_Agenda.Domain.Adapters;
using MongoDB.Bson;
using Moq;
using Xunit;
using AgendaEntity = HealthMed_Agenda.Domain.Entities.Agenda;
namespace HealthMed_Agenda.Tests.UseCases.Agenda
{
    public class AgendaExcluirUseCaseTests
    {
        private readonly Mock<IAgendaGateway> _agendaGatewayMock;

        public AgendaExcluirUseCaseTests()
        {
            _agendaGatewayMock = new Mock<IAgendaGateway>();
        }


        [Fact]
        public async Task CancelarAgendamento_WhenAgendaExists_ShouldDeleteAgenda()
        {
            // Arrange
            var Id = ObjectId.GenerateNewId();
            var codigoAgendaMedico = Id.ToString();
            var agenda = new AgendaEntity { Id = Id };
            _agendaGatewayMock.Setup(g => g.Get(codigoAgendaMedico)).ReturnsAsync(agenda);
            var useCase = new AgendaExcluirUseCase(_agendaGatewayMock.Object);

            // Act
            var result = await useCase.CancelarAgendamento(codigoAgendaMedico);

            // Assert
            Assert.True(result.IsSuccess);
            _agendaGatewayMock.Verify(g => g.Delete(agenda.Id.ToString()), Times.Once);
        }

        [Fact]
        public async Task CancelarAgendamento_WhenAgendaDoesNotExist_ShouldReturnError()
        {
            // Arrange
            var codigoAgendaMedico = "123";
            _agendaGatewayMock.Setup(g => g.Get(codigoAgendaMedico)).ReturnsAsync(new AgendaEntity());
            var useCase = new AgendaExcluirUseCase(_agendaGatewayMock.Object);

            // Act
            var result = await useCase.CancelarAgendamento(codigoAgendaMedico);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Agendamento não encontrado.", result.Errors[0].Message);
            _agendaGatewayMock.Verify(g => g.Delete(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task CancelarAgendamento_WhenExceptionThrown_ShouldReturnError()
        {
            // Arrange
            var codigoAgendaMedico = "123";
            _agendaGatewayMock.Setup(g => g.Get(codigoAgendaMedico)).ThrowsAsync(new Exception("Some error"));
            var useCase = new AgendaExcluirUseCase(_agendaGatewayMock.Object);

            // Act
            var result = await useCase.CancelarAgendamento(codigoAgendaMedico);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Some error", result.Errors[0].Message);
            _agendaGatewayMock.Verify(g => g.Delete(It.IsAny<string>()), Times.Never);
        }
    }
}