using System.Net.Mail;
using System.Web.Configuration;

namespace APesquisa.Service
{
    public class SendMailService : ISendMailService
    {
        public void SendMail(string name, string email, string suggestion)
        {
            //cria uma mensagem
            MailMessage mail = new MailMessage();

            //define os endereços
            var fromEmail = WebConfigurationManager.AppSettings["Email"];
            var emailPassword = WebConfigurationManager.AppSettings["EmailPassword"];
            mail.From = new MailAddress(fromEmail);
            mail.To.Add(fromEmail);

            //define o conteúdo
            mail.Subject = "Sugestão - A Pesquisa";
            mail.Body = "Nome: " + name + "\nE-mail: " + email + "\nSugestão: " + suggestion;

            //envia a mensagem
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");

            smtp.Credentials = new System.Net.NetworkCredential(fromEmail, emailPassword);
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}