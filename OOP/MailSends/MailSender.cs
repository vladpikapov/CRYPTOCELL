using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OOP.MailSends
{
    class MailSender
    {
        MailAddress from = new MailAddress("bitpurseWPF@gmail.com", "ISitNester");
        public void SendUserInfo(TextBox mail,PasswordBox pass,TextBox userName)
        {
            // кому отправляем
            MailAddress to = new MailAddress(mail.Text);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Информация о пользователе";
            // текст письма
            m.Body = $"<h2>Ваш логин: {userName.Text}</h2>" +
                $"</br>" +
                $"<h2>Ваш пароль: {pass.Password}</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("bitpurseWPF@gmail.com", "123456bitpurse");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
        public void UserCheckMail(int code, TextBox mail)
        {
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, new MailAddress(mail.Text));
            // тема письма
            m.Subject = "Проверка почты";
            // текст письма
            m.Body =$"<h2>Ваш код подтверждения: {code}</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("bitpurseWPF@gmail.com", "123456bitpurse");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
