using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BLL.WorkWithUser.MailSender
{
   public class Sender
    {

        WorkWithUserLog userWork = new WorkWithUserLog();
        MailAddress from = new MailAddress("bitpurseWPF@gmail.com", "ISitNester");
        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

        public void SendUserInfo(string mail, string pass, string userName)
        {
            MailMessage m = new MailMessage(from, new MailAddress(mail));
            m.Subject = "Информация о пользователе";
            m.Body = $"<h2>Ваш логин: {userName}</h2>" +
                $"</br>" +
                $"<h2>Ваш пароль: {pass}</h2>";
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("bitpurseWPF@gmail.com", "123456bitpurse");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
        public void UserCheckMail(int code, string mail)
        {
            MailMessage m = new MailMessage(from, new MailAddress(mail));
            m.Subject = "Проверка почты";
            m.Body = $"<h2>Ваш код подтверждения: {code}</h2>";
            m.IsBodyHtml = true;
            smtp.Credentials = new NetworkCredential("bitpurseWPF@gmail.com", "123456bitpurse");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
        public bool ForgotPass(string login, int key)
        {
            var u = userWork.GetUser(login);
            if (u != null)
            {

                MailMessage m = new MailMessage(from, new MailAddress(u.UserMail));
                m.Subject = "Восстановление пароля";
                m.Body = $"<h2>Ваш  код для восстановления {key}</h2>";
                m.IsBodyHtml = true;
                smtp.Credentials = new NetworkCredential("bitpurseWPF@gmail.com", "123456bitpurse");
                smtp.EnableSsl = true;
                smtp.Send(m);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void NewPassword(string login, string password)
        {
            var user = userWork.GetUser(login);
            if (user != null)
            {
                MailMessage m = new MailMessage(from, new MailAddress(user.UserMail));
                m.Subject = "Новый пароль";
                m.Body = $"<h2>Ваш новый пароль {password}</h2>";
                m.IsBodyHtml = true;
                smtp.Credentials = new NetworkCredential("bitpurseWPF@gmail.com", "123456bitpurse");
                smtp.EnableSsl = true;
                smtp.Send(m);
            }
            
        }

    }
}

