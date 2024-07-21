using HealthMed_Agenda.Domain.Adapters;
using HealthMed_Agenda.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace HealthMed_Agenda.Infra.MQ.Events
{
    [ExcludeFromCodeCoverage]
    public class ProcessaEvento(IMedicoGateway medicoGateway, IServiceScopeFactory scopeFactory) : IProcessaEvento
    {
        private readonly IMedicoGateway _medicoGateway = medicoGateway;
        private readonly IServiceScopeFactory _scopeFactory = scopeFactory;

        public void Processa(string mensagem)
        {

            using var scope = _scopeFactory.CreateScope();

            var medicoRead = JsonSerializer.Deserialize<Medico>(mensagem);

            var medico = new Medico
            {
                MedicoId = medicoRead?.MedicoId,
                MedicoNome = medicoRead?.MedicoNome,
                MedicoRegistro = medicoRead?.MedicoRegistro,
                MedicoEspecialidade = medicoRead?.MedicoEspecialidade,
                ModalidadeAtendimentos = medicoRead?.ModalidadeAtendimentos,
                TipoAtendimentos = medicoRead?.TipoAtendimentos,
                Convenios = medicoRead?.Convenios,
                Ativo = medicoRead.Ativo
            };

            if (_medicoGateway.GetValue("MedicoId", medico.MedicoId.Value) == null)
            {
                _medicoGateway.Create(medico);
            }
        }
    }
}
