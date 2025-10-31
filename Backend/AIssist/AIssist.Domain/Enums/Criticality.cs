using System.ComponentModel;

namespace AIssist.Domain.Enums
{
    public enum TicketCriticality
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

