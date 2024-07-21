using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace HealthMed_Agenda.Domain.Enums
{
    [ExcludeFromCodeCoverage]
    public enum EModalidadeAtendimento
    {
        [Description("Presencial")]
        Presencial = 1,
        [Description("Teleatendimento")]
        Teleatendimento = 2,
    }

    [ExcludeFromCodeCoverage]
    public static class EModalidadeAtendimentoExtensions
    {
        public static string ToDescriptionString(this EModalidadeAtendimento val)
        {
            var type = val.GetType();
            var attributes = type.GetField(val.ToString())?.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            return attributes?.Length > 0 ? attributes[0].Description : string.Empty;
        }

        public static string ToDescriptionString(Enum val)
        {
            var type = val.GetType();
            var attributes = type.GetField(val.ToString())?.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            return attributes?.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
