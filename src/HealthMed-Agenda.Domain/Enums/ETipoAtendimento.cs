using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace HealthMed_Agenda.Domain.Enums
{
    [ExcludeFromCodeCoverage]
    public enum ETipoAtendimento
    {
        [Description("Particular")]
        Particular = 1,
        [Description("Convênio")]
        Concenio = 2,
    }

    [ExcludeFromCodeCoverage]
    public static class ETipoAtendimentoExtensions
    {
        public static string ToDescriptionString(this ETipoAtendimento val)
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
