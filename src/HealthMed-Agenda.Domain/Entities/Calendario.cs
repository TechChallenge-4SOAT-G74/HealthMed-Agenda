namespace HealthMed_Agenda.Domain.Entities
{
    public class Calendario
    {
        public virtual DateTime DataHoraConsulta { get; set; }
        public virtual int? DuracaoConsulta { get; set; }
        public virtual string? Status { get; set; }
    }
}
