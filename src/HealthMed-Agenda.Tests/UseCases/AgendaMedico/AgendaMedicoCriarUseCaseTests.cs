using HealthMed_Agenda.Application.UseCases.AgendaMedico;
using HealthMed_Agenda.Application.UseCases.AgendaMedico.Dtos;
using HealthMed_Agenda.Domain.Adapters;
using Moq;
using Xunit;
using AgendaMedicoEntity = HealthMed_Agenda.Domain.Entities.AgendaMedico;
using CalendarioEntity = HealthMed_Agenda.Domain.Entities.Calendario;
using MedicoEntity = HealthMed_Agenda.Domain.Entities.Medico;

namespace HealthMed_Agenda.Tests.UseCases.AgendaMedico
{
    public class AgendaMedicoCriarUseCaseTests
    {
        private readonly Mock<IAgendaMedicoGateway> _agendaMedicoGatewayMock;
        private readonly Mock<IMedicoGateway> _medicoGatewayMock;

        public AgendaMedicoCriarUseCaseTests()
        {
            _agendaMedicoGatewayMock = new Mock<IAgendaMedicoGateway>();
            _medicoGatewayMock = new Mock<IMedicoGateway>();
        }

        [Fact]
        public async Task CriarAgendaMedico_WhenMedicoDoesNotExist_ShouldCreateMedicoAndAgendaMedico()
        {
            // Arrange
            var dto = new AgendaMedicoDto
            {
                MedicoNome = "John Doe",
                MedicoEspecialidade = "Cardiology",
                MedicoRegistro = "12345",
                ModalidadeAtendimentos = ["Presencial"],
                TipoAtendimentos = ["Consulta"],
                Convenios = ["Insurance A"],
                Ativo = true,
                Calendario = new CalendarioEntity
                {
                    DataHoraConsulta = Convert.ToDateTime("2024-07-22T 09:00:00"),
                    DuracaoConsulta = 50,
                    Status = "Aberta"
                }
            };

            var medico = new MedicoEntity
            {
                MedicoNome = "John Doe",
                MedicoRegistro = "12345",
                TipoAtendimentos = ["Consulta"],
                ModalidadeAtendimentos = ["Presencial"],
                Convenios = ["convenio"],
            };

            _medicoGatewayMock.Setup(g => g.GetValue("Medico.MedicoNome", dto.MedicoNome)).ReturnsAsync(medico);
            _medicoGatewayMock.Setup(g => g.GetValue("Medico.MedicoRegistro", dto.MedicoRegistro)).ReturnsAsync(new MedicoEntity());
            _medicoGatewayMock.Setup(g => g.GetValue("Medico.MedicoEspecialidade", dto.MedicoEspecialidade)).ReturnsAsync(new MedicoEntity());

            var useCase = new AgendaMedicoCriarUseCase(_agendaMedicoGatewayMock.Object, _medicoGatewayMock.Object);

            // Act
            var result = await useCase.CriarAgendaMedico(dto);

            // Assert
            Assert.True(result.IsSuccess);
            _agendaMedicoGatewayMock.Verify(g => g.Create(It.IsAny<AgendaMedicoEntity>()), Times.Once);
        }

        [Fact]
        public async Task CriarAgendaMedico_WhenMedicoExists_ShouldCreateAgendaMedicoOnly()
        {
            // Arrange
            var dto = new AgendaMedicoDto
            {
                MedicoNome = "John Doe",
                MedicoEspecialidade = "Cardiology",
                MedicoRegistro = "12345",
                ModalidadeAtendimentos = ["Presencial"],
                TipoAtendimentos = ["Consulta"],
                Convenios = ["Insurance A"],
                Ativo = true,
                Calendario = new CalendarioEntity()
            };

            var medico = new MedicoEntity
            {
                MedicoId = 1,
                MedicoNome = dto.MedicoNome,
                MedicoEspecialidade = dto.MedicoEspecialidade,
                MedicoRegistro = dto.MedicoRegistro,
                ModalidadeAtendimentos = dto.ModalidadeAtendimentos,
                TipoAtendimentos = dto.TipoAtendimentos,
                Convenios = dto.Convenios,
                Ativo = dto.Ativo
            };

            _medicoGatewayMock.Setup(g => g.GetValue("Medico.MedicoNome", dto.MedicoNome)).ReturnsAsync(medico);
            _medicoGatewayMock.Setup(g => g.GetValue("Medico.MedicoRegistro", dto.MedicoRegistro)).ReturnsAsync(medico);
            _medicoGatewayMock.Setup(g => g.GetValue("Medico.MedicoEspecialidade", dto.MedicoEspecialidade)).ReturnsAsync(medico);

            var useCase = new AgendaMedicoCriarUseCase(_agendaMedicoGatewayMock.Object, _medicoGatewayMock.Object);

            // Act
            var result = await useCase.CriarAgendaMedico(dto);

            // Assert
            Assert.True(result.IsSuccess);
            _medicoGatewayMock.Verify(g => g.Create(It.IsAny<MedicoEntity>()), Times.Never);
            _agendaMedicoGatewayMock.Verify(g => g.Create(It.IsAny<AgendaMedicoEntity>()), Times.Once);
        }
    }
}