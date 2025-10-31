using System.ComponentModel;

namespace AIssist.Domain.Enums
{
    public enum TicketStatus
    {
        [Description("Aberto")]
        Aberto = 1,

        [Description("Atribuído")]
        Atribuido = 2,

        [Description("Em Atendimento")]
        EmAtendimento = 3,

        [Description("Em Validação")]
        EmValidacao = 4,

        [Description("Fechado")]
        Fechado = 5,

        [Description("Cancelado")]
        Cancelado = 6
    }
}

