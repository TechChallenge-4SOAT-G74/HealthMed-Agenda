namespace HealthMed_Agenda.Domain.Entities
{
    public class Agenda : EntityMongoBase
    {
        public virtual AgendaMedico? AgendaMedico { get; set; }
        public virtual Paciente? Paciente { get; set; }
        public string? Convenio { get; set; }
        public string? TipoAtendimento { get; set; }
        public virtual string? Status { get; set; }
        public virtual string? Observacao { get; set; }
        public virtual string? LinkTeleAtendimento { get; set; }
        public virtual DateTime DataHoraAgendamento { get; set; } = DateTime.Now;

    }
}
