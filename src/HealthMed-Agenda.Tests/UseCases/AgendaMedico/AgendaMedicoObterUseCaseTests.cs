//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Xunit;

//namespace HealthMed_Agenda.Tests.UseCases.AgendaMedico
//{
//    public class AgendaMedicoObterUseCaseTests
//    {
//        [Fact]
//        public async Task ConsultarAgendaMedico_WithValidInput_ReturnsAgendaMedicoDtoList()
//        {
//            // Arrange
//            var useCase = new AgendaMedicoObterUseCase(/* inject dependencies here */);
//            var nomeOrCrmOrEspecialidade = "John Doe";

//            // Act
//            var result = await useCase.ConsultarAgendaMedico(nomeOrCrmOrEspecialidade);

//            // Assert
//            Assert.NotNull(result);
//            Assert.IsType<ServiceResult<List<AgendaMedicoDto>>>(result);
//            Assert.NotNull(result.Data);
//            Assert.NotEmpty(result.Data);
//        }

//        [Fact]
//        public async Task ConsultarAgendaMedico_WithInvalidInput_ReturnsError()
//        {
//            // Arrange
//            var useCase = new AgendaMedicoObterUseCase(/* inject dependencies here */);
//            var nomeOrCrmOrEspecialidade = "Non-existing doctor";

//            // Act
//            var result = await useCase.ConsultarAgendaMedico(nomeOrCrmOrEspecialidade);

//            // Assert
//            Assert.NotNull(result);
//            Assert.IsType<ServiceResult<List<AgendaMedicoDto>>>(result);
//            Assert.Null(result.Data);
//            Assert.NotEmpty(result.Errors);
//        }

//        // Add more test cases as needed
//    }
//}