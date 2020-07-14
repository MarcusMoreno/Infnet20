namespace AvaliacaoInfnet.Domain.Mailer
{
    public interface IMailer
    {
        void SendEmail(string to, string content, string subject);
    }
}
