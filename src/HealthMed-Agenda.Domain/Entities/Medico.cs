namespace HealthMed_Agenda.Domain.Entities
{
    public class Medico : EntityMongoBase
    {
        public virtual int? MedicoId { get; set; }
        public virtual string? MedicoNome { get; set; }
        public virtual string? MedicoEspecialidade { get; set; }
        public virtual string? MedicoRegistro { get; set; }
        public virtual List<string>? TipoAtendimentos { get; set; }
        public virtual List<string>? Convenios { get; set; }
        public virtual bool Ativo { get; set; }
    }
}
