namespace HealthMed_Agenda.Application.UseCases.Agenda.Dtos
{
    public class AgendamentoDto
    {
        public string? IdAgendamento { get; set; }
        public string? MedicoNome { get; set; }
        public string? MedicoEspecialidade { get; set; }
        public string? MedicoRegistro { get; set; }
        public DateTime? DataHoraConsulta { get; set; }
        public string? PacienteNome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? DDD { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? ModalidadeAtendimento { get; set; }
        public string? Convenio { get; set; }
        public string? TipoAtendimento { get; set; }
        public string? Status { get; set; }
        public string? Observacao { get; set; }
        public string? LinkTeleAtendimento { get; set; }
    }
}
