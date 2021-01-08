namespace APesquisa.Service
{
    public interface ISendMailService
    {
        void SendMail(string name, string email, string suggestion);
    }
}