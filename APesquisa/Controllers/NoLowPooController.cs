using APesquisa.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APesquisa.Controllers
{
    public class NoLowPooController : Controller
    {
        private readonly IFormulaAnalysisService _formulaAnalysisService;

        public NoLowPooController(IFormulaAnalysisService formulaAnalysisService)
        {
            _formulaAnalysisService = formulaAnalysisService;
        }

        // GET: LowNoPoo
        public ActionResult Index(string components)
        {
            return View();
        }

        public ActionResult Analyse(string components)
        {
            var result = _formulaAnalysisService.GetFormulaAnalysisResult(components);
            return PartialView("_ResultadoNoLowPoo", result);
        }

        public ActionResult ListaDeComponentes(string component)
        {
            var result = _formulaAnalysisService.GetComponentByPartialText(component);
            return View(result);
        }
        public ActionResult OQueE()
        {
            return View();
        }
    }
}