using System.ComponentModel;

namespace APesquisa.Models.Enum
{
    public enum ComponentPooType
    {
        [Description("Componente Desconhecido")]
        Unknown = 0,
        [Description("Componente Liberado para No e Low Poo")]
        AllowedBoth = 1,
        [Description("Componente Poribido para No Poo e Liberado para Low Poo")]
        AllowedLowPooForbidenNoPoo = 2,
        [Description("Componente Proibido para ambas as técnicas")]
        ForbiddenBoth = 3
    }
}