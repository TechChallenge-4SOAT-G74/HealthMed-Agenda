namespace HealthMed_Agenda.Domain.Entities
{
    public class AgendaMedico : EntityMongoBase
    {
        public virtual Medico? Medico { get; set; }
        public virtual Calendario? Calendario { get; set; }
    }
}