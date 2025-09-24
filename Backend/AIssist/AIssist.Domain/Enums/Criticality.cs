using System.ComponentModel;
using System.Reflection;

namespace AIssist.Domain.Enums
{
    public enum Criticality
    {
        [Description("Baixo")]
        Baixo = 1,

        [Description("Médio")]
        Medio = 2,

        [Description("Alto")]
        Alto = 3,

        [Description("Crítico")]
        Critico = 4
    }
}

