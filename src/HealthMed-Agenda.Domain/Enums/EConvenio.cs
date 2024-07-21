﻿using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace HealthMed_Agenda.Domain.Enums
{
    [ExcludeFromCodeCoverage]
    public enum EConvenio
    {
        [Description("Amil")]
        Amil = 1,
        [Description("Sulamerica")]
        Sulamerica = 2,
        [Description("Unimed")]
        Unimed = 2,
        [Description("Intermédica")]
        Intermédica = 2,
    }

    [ExcludeFromCodeCoverage]
    public static class EConvenioExtensions
    {
        public static string ToDescriptionString(this EConvenio val)
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
