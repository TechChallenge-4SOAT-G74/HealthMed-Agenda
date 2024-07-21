using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace HealthMed_Agenda.Domain.Enums
{
    [ExcludeFromCodeCoverage]
    public enum EStatusAgenda
    {
        [Description("Aberta")]
        Aberta = 1,
        [Description("Fechada")]
        Fechada = 2,
        [Description("Agendado")]
        Agendado = 3,
        [Description("Confirmado")]
        Confirmado = 4,
    }

    [ExcludeFromCodeCoverage]
    public static class EStatusAgendaExtensions
    {
        public static string ToDescriptionString(this EStatusAgenda val)
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
