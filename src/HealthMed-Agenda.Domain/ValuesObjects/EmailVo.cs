using System.Text.RegularExpressions;

namespace HealthMed_Agenda.Domain.ValuesObjects
{
    public class EmailVo
    {
        public string Endereco { get; private set; }

        public EmailVo(string endereco)
        {
            Endereco = endereco;
            Validar();
        }

        private void Validar()
        {
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            if (!Regex.IsMatch(Endereco, pattern, RegexOptions.IgnoreCase))
                throw new Exception("E-mail Inválido!");

        }
    }
}
