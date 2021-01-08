using System.ComponentModel;

namespace APesquisa.Models.Enum
{
    public enum PooType
    {
        [Description("Liberado para No e Low Poo")]
        AllowedForBoth = 0,
        [Description("Liberado somente para Low Poo")]
        AllowedForLowPoo = 1,
        [Description("Proibido para ambas as técnicas")]
        Forbidden = 2
    }
}