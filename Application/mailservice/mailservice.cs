using System;
using System.Linq;
using System.Net.Mail;
using Domain;

namespace Application.mailservice
{
    public class mailservice
    {
        public void SendMail(Owner owner)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("wesleysonvan@gmail.com");
                mail.To.Add(owner.Email);
                mail.Subject = "Confirmatie mail registratienummer vakantieverhuur";
                mail.Body = "Uw registratie nummer is : " + owner.Registrations.FirstOrDefault().RegistrationNumber;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("wesleysonvan@gmail.com", "Welkom123!");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                Console.WriteLine(mail);
            }
            catch
            {
                Console.WriteLine("Mail niet verzonden");
            }
        }

    }
}