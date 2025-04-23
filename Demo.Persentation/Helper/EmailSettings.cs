using System.Net;
using System.Net.Mail;

namespace Demo.Persentation.Helper
{
    public static class EmailSettings
    {
        public static bool SendEmail(Email email)
        {
            //Mail Server : Email

            //Protocol : Smtp

            //Host,
            //Port 587 

            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                //sender Data 

                client.Credentials = new NetworkCredential("MohamedKhaled","dfgh");
                client.Send(from: "MohamedKhaled",email.TO,email.Subject,email.Body);
            }
            catch
            {
                return false;

            }
             

            return false;
        }
    }
}
