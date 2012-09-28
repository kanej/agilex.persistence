using System;
using System.Diagnostics;
using System.Net.Mail;
using System.Text;

namespace agilex.persistence.nhibernate
{
    public static class NhibIntExtensions
    {
        public static bool GreaterThan(this string s, int d)
        {

            var mailMessage = new MailMessage
            {
                BodyEncoding = Encoding.UTF8,
                IsBodyHtml = true,
                Subject = "test",
                Body = string.Format("!!!!!!!!!!!!! {0} {1} {2}", s, d, int.Parse(s) > d),
                From = new MailAddress("ben.keeping@landmark.co.uk"),
            };

            mailMessage.To.Add("ben.keeping@landmark.co.uk");

            var client = new SmtpClient();
            client.Send(mailMessage);
            return int.Parse(s) > d;
        }
        public static bool GreaterThanEqualTo(this string s, int d)
        {
            return int.Parse(s) >= d;
        }
        public static bool LessThan(this string s, int d)
        {
            return int.Parse(s) < d;
        }
        public static bool LessThanEqualTo(this string s, int d)
        {
            return int.Parse(s) <= d;
        }
        public static bool EqualTo(this string s, int d)
        {
            return int.Parse(s) == d;
        }
        public static bool NotEqualTo(this string s, int d)
        {
            return int.Parse(s) != d;
        }
    }
}