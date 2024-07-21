using HealthMed_Agenda.Domain.Entities;

namespace HealthMed_Agenda.Application.UseCases.AgendaMedico.Dtos
{
    public class AgendaMedicoDto
    {
        public string? IdAgendaMedico { get; set; }
        public string? MedicoNome { get; set; }
        public string? MedicoEspecialidade { get; set; }
        public string? MedicoRegistro { get; set; }
        public List<string>? ModalidadeAtendimentos { get; set; }
        public List<string>? TipoAtendimentos { get; set; }
        public List<string>? Convenios { get; set; }
        public bool Ativo { get; set; }
        public Calendario? Calendario { get; set; }
    }
}
