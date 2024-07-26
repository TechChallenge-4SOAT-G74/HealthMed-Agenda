using HealthMed_Agenda.Application.Core;
using HealthMed_Agenda.Application.UseCases.AgendaMedico.Dtos;
using HealthMed_Agenda.Application.UseCases.AgendaMedico.Interfaces;
using HealthMed_Agenda.Domain.Adapters;
using AgendaMedicoEntity = HealthMed_Agenda.Domain.Entities.AgendaMedico;
using MedicoEntity = HealthMed_Agenda.Domain.Entities.Medico;

namespace HealthMed_Agenda.Application.UseCases.AgendaMedico
{
    public class AgendaMedicoCriarUseCase(IAgendaMedicoGateway agendaMedicoGateway, IMedicoGateway medicoGateway) : IAgendaMedicoCriarUseCase
    {
        private readonly IAgendaMedicoGateway _agendaMedicoGateway = agendaMedicoGateway;
        private readonly IMedicoGateway _medicoGateway = medicoGateway;

        public async Task<ServiceResult> CriarAgendaMedico(AgendaMedicoDto dto)
        {
            var result = new ServiceResult();
            try
            {
                var medico = await _medicoGateway.GetValue("Medico.MedicoNome", dto.MedicoNome);

                medico ??= await _medicoGateway.GetValue("Medico.MedicoRegistro", dto.MedicoRegistro);
                medico ??= await _medicoGateway.GetValue("Medico.MedicoEspecialidade", dto.MedicoEspecialidade);

                if (medico == null)
                {
                    var rand = new Random();

                    medico = new MedicoEntity
                    {
                        MedicoId = rand.Next(100, 200),
                        MedicoNome = dto.MedicoNome,
                        MedicoEspecialidade = dto.MedicoEspecialidade,
                        MedicoRegistro = dto.MedicoRegistro,
                        TipoAtendimentos = dto.TipoAtendimentos,
                        Convenios = dto.Convenios,
                        Ativo = dto.Ativo,
                    };
                    await _medicoGateway.Create(medico);
                }


                var agendaMedico = new AgendaMedicoEntity
                {
                    Medico = medico,
                    Calendario = dto.Calendario
                };

                await _agendaMedicoGateway.Create(agendaMedico);

            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }

    }
}
