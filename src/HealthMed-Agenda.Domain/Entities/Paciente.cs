using HealthMed_Agenda.Domain.ValuesObjects;

namespace HealthMed_Agenda.Domain.Entities
{
    public class Paciente
    {
        public virtual NomeVo? PacienteNome { get; set; }
        public virtual DateTime? DataNascimento { get; set; }
        public virtual TelefoneVo? Telefone { get; set; }
        public virtual EmailVo? Email { get; set; }
    }
}
