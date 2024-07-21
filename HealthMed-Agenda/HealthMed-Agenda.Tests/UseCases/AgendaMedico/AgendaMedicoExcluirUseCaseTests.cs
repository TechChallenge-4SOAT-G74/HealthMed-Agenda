using HealthMed_Agenda.Application.UseCases.AgendaMedico;
using HealthMed_Agenda.Domain.Adapters;
using MongoDB.Bson;
using Moq;
using Xunit;
using AgendaMedicoEntity = HealthMed_Agenda.Domain.Entities.AgendaMedico;

namespace HealthMed_Agenda.Tests.UseCases.AgendaMedico
{
    public class AgendaMedicoExcluirUseCaseTests
    {
        private readonly Mock<IAgendaMedicoGateway> _agendaMedicoGatewayMock;

        public AgendaMedicoExcluirUseCaseTests()
        {
            _agendaMedicoGatewayMock = new Mock<IAgendaMedicoGateway>();
        }

        [Fact]
        public async Task CancelarAgendaMedico_WhenAgendaMedicoExists_ShouldDeleteAgendaMedico()
        {
            // Arrange
            var Id = ObjectId.GenerateNewId();
            var codigoAgendaMedico = Id.ToString();
            var agendaMedico = new AgendaMedicoEntity { Id = Id };
            _agendaMedicoGatewayMock.Setup(g => g.Get(codigoAgendaMedico)).ReturnsAsync(agendaMedico);
            var useCase = new AgendaMedicoExcluirUseCase(_agendaMedicoGatewayMock.Object);

            // Act
            var result = await useCase.CancelarAgendaMedico(codigoAgendaMedico);

            // Assert
            Assert.True(result.IsSuccess);
            _agendaMedicoGatewayMock.Verify(g => g.Delete(agendaMedico.Id.ToString()), Times.Once);
        }

        [Fact]
        public async Task CancelarAgendaMedico_WhenAgendaMedicoDoesNotExist_ShouldReturnError()
        {
            // Arrange
            var codigoAgendaMedico = "123";
            _agendaMedicoGatewayMock.Setup(g => g.Get(codigoAgendaMedico)).ReturnsAsync(new AgendaMedicoEntity());
            var useCase = new AgendaMedicoExcluirUseCase(_agendaMedicoGatewayMock.Object);

            // Act
            var result = await useCase.CancelarAgendaMedico(codigoAgendaMedico);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Agenda Médico não encontrada.", result.Errors.First().Message);
            _agendaMedicoGatewayMock.Verify(g => g.Delete(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task CancelarAgendaMedico_WhenExceptionThrown_ShouldReturnError()
        {
            // Arrange
            var codigoAgendaMedico = "123";
            _agendaMedicoGatewayMock.Setup(g => g.Get(codigoAgendaMedico)).ThrowsAsync(new Exception("Some error"));
            var useCase = new AgendaMedicoExcluirUseCase(_agendaMedicoGatewayMock.Object);

            // Act
            var result = await useCase.CancelarAgendaMedico(codigoAgendaMedico);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Some error", result.Errors.First().Message);
            _agendaMedicoGatewayMock.Verify(g => g.Delete(It.IsAny<string>()), Times.Never);
        }
    }
}