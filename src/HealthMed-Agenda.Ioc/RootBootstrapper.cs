using HealthMed_Agenda.Application.UseCases.Agenda;
using HealthMed_Agenda.Application.UseCases.Agenda.Interfaces;
using HealthMed_Agenda.Application.UseCases.AgendaMedico;
using HealthMed_Agenda.Application.UseCases.AgendaMedico.Interfaces;
using HealthMed_Agenda.Domain.Adapters;
using HealthMed_Agenda.Infra.Gateway;
using HealthMed_Agenda.Infra.Gateway.Core;
using HealthMed_Agenda.Infra.MQ;
using HealthMed_Agenda.Infra.MQ.Events;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace HealthMed_Agenda.Ioc
{
    [ExcludeFromCodeCoverage]
    public static class RootBootstrapper
    {
        public static void BootstrapperRegisterServices(this IServiceCollection services, IEnumerable<Type> assemblyTypes)
        {
            if (assemblyTypes is null)
            {
                throw new ArgumentNullException(nameof(assemblyTypes));
            }

            services.AddSingleton(typeof(IRabbitMqPub<>), typeof(RabbitMqPub<>));
            services.AddScoped<IProcessaEvento, ProcessaEvento>();

            //Repositories postgresDB

            services.AddSingleton<IMondoDBContext, MondoDBContext>();
            services.AddScoped<IAgendaGateway, AgendaGateway>();
            services.AddScoped<IAgendaMedicoGateway, AgendaMedicoGateway>();
            services.AddScoped<IMedicoGateway, MedicoGateway>();

            //UseCases
            services.AddScoped<IAgendaMedicoAtualizarUseCase, AgendaMedicoAtualizarUseCase>();
            services.AddScoped<IAgendaMedicoCriarUseCase, AgendaMedicoCriarUseCase>();
            services.AddScoped<IAgendaMedicoExcluirUseCase, AgendaMedicoExcluirUseCase>();
            services.AddScoped<IAgendaMedicoObterUseCase, AgendaMedicoObterUseCase>();

            services.AddScoped<IAgendaAtualizarUseCase, AgendaAtualizarUseCase>();
            services.AddScoped<IAgendaCriarUseCase, AgendaCriarUseCase>();
            services.AddScoped<IAgendaExcluirUseCase, AgendaExcluirUseCase>();
            services.AddScoped<IAgendaObterUseCase, AgendaObterUseCase>();
            services.AddScoped<IAgendaNotificacaoUseCase, AgendaNotificacaoUseCase>();
        }
    }
}
