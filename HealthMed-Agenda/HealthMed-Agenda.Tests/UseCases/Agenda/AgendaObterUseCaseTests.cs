//using HealthMed_Agenda.Application.UseCases;
//using HealthMed_Agenda.Domain.Adapters;
//using Moq;
//using Xunit;
//using AgendaEntity = HealthMed_Agenda.Domain.Entities.Agenda;

//namespace HealthMed.Agenda.Application.Tests.UseCases.Agenda
//{
//    public class AgendaObterUseCaseTests
//    {
//        private readonly Mock<IAgendaGateway> _agendaGatewayMock;
//        private readonly AgendaObterUseCase _agendaObterUseCase;

//        public AgendaObterUseCaseTests()
//        {
//            _agendaGatewayMock = new Mock<IAgendaGateway>();
//            _agendaObterUseCase = new AgendaObterUseCase(_agendaGatewayMock.Object);
//        }

//        [Fact]
//        public async Task ConsultarAgendamentoCliente_ShouldReturnAgendamentoDtoList_WhenAgendaExistsForNomeOrEmail()
//        {
//            // Arrange
//            var nomeOrEmail = "John Doe";
//            var agenda = new List<AgendaEntity> { new AgendaEntity() };
//            _agendaGatewayMock.Setup(x => x.GetList("Paciente.PacienteNome.Nome", nomeOrEmail)).ReturnsAsync(agenda);

//            // Act
//            var result = await _agendaObterUseCase.ConsultarAgendamentoCliente(nomeOrEmail);

//            // Assert
//            Assert.NotNull(result);
//            Assert.True(result.IsSuccess);
//            Assert.Equal(agenda.Count, result.Data.Count);
//        }

//        [Fact]
//        public async Task ConsultarAgendamentoCliente_ShouldReturnError_WhenAgendaDoesNotExistForNomeOrEmail()
//        {
//            // Arrange
//            var nomeOrEmail = "John Doe";
//            _agendaGatewayMock.Setup(x => x.GetList("Paciente.PacienteNome.Nome", nomeOrEmail)).ReturnsAsync(new List<AgendaEntity>());

//            // Act
//            var result = await _agendaObterUseCase.ConsultarAgendamentoCliente(nomeOrEmail);

//            // Assert
//            Assert.NotNull(result);
//            Assert.False(result.IsSuccess);
//            Assert.NotEmpty(result.Errors);
//        }

//        // Write similar tests for other methods (ConsultarAgendamentos and ConsultarAgendaMedico)

//        [Fact]
//        public void GeraAgendaDto_ShouldReturnAgendamentoDtoList_WhenAgendaIsProvided()
//        {
//            // Arrange
//            var agenda = new List<AgendaEntity> { new AgendaEntity() };

//            // Act
//            var result = AgendaObterUseCase.GeraAgendaDto(agenda);

//            // Assert
//            Assert.NotNull(result);
//            Assert.Equal(agenda.Count, result.Count);
//        }

//        [Fact]
//        public void GeraAgendaDto_ShouldReturnEmptyList_WhenAgendaIsNull()
//        {
//            // Arrange
//            List<AgendaEntity> agenda = null;

//            // Act
//            var result = AgendaObterUseCase.GeraAgendaDto(agenda);

//            // Assert
//            Assert.NotNull(result);
//            Assert.Empty(result);
//        }

//    }
//}