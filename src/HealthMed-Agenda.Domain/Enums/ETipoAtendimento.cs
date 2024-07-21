using System.ComponentModel;

namespace HealthMed_Agenda.Domain.Enums
{
    public enum ETipoAtendimento
    {
        [Description("Particular")]
        Particular = 1,
        [Description("Convênio")]
        Concenio = 2,
    }

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
