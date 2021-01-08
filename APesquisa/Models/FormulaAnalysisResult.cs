using APesquisa.Models.Enum;
using System.Collections.Generic;

namespace APesquisa.Models
{
    public class FormulaAnalysisResult
    {
        public string OriginalFormula { get; set; }
        public IEnumerable<ComponentData> ComponentsData { get; set; }
        public PooType Type { get; set; }
    }

    public class ComponentData
    {
        public string Name { get; set; }
        public string ComponentType { get; set; }
        public ComponentPooType PooType { get; set; }
    }
}