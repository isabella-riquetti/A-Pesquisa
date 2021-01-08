using APesquisa.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APesquisa.Controllers
{
    public class AjudaController : Controller
    {
        private readonly ISendMailService _sendMailService;

        public AjudaController(ISendMailService sendMailService)
        {
            _sendMailService = sendMailService;
        }

        public ActionResult Index(string message, string messageDetail)
        {
            ViewBag.Message = message;
            ViewBag.MessageDetail = messageDetail;
            return View();
        }

        [HttpPost]
        public ActionResult SendSuggestion(string name, string email, string suggestion)
        {
            _sendMailService.SendMail(name, email, suggestion);
            return RedirectToAction("Index", new { message = "Sucesso!", messageDetail = "Sua mensagem foi enviada com sucesso. Caso tenha nos informao seu e-mail iremos lhe informar quando sua sugestão for implementada!"});
        }
    }
}