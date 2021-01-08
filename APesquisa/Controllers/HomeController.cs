using System.Web.Mvc;

namespace APesquisa.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Robots()
        {
            Response.ContentType = "text/plain";
            return View();
        }

        public ActionResult SiteMap()
        {
            Response.ContentType = "text/xml";
            return View();
        }
    }
}