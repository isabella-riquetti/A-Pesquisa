using APesquisa.Data.Models;
using APesquisa.Models;
using System.Collections.Generic;

namespace APesquisa.Service
{
    public interface IFormulaAnalysisService
    {
        FormulaAnalysisResult GetFormulaAnalysisResult(string components);
        IEnumerable<Component> GetComponentByPartialText(string searchText);
    }
}