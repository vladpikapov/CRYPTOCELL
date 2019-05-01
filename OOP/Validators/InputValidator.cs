using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace OOP.Validators
{
    public class InputValidator
    {
        MailValide valide = new MailValide();
        public bool MyValidate(TextBox textBox,TextBox userMail,PasswordBox passwordBox, PasswordBox password)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.BorderBrush = Brushes.Red;
                textBox.ToolTip = "Login can`t be empty!";
                return false;
            }
            if (!valide.MyMailValid(userMail))
            {
                userMail.BorderBrush = Brushes.Red;
                userMail.ToolTip = "Mail is not true!";
                return false;
            }
            if(passwordBox.Password.Length < 5)
            {
                passwordBox.ToolTip = "Password must be longer than 6 symbols!";
                passwordBox.BorderBrush = Brushes.Red;
                return false;
            }
            if (passwordBox.Password != password.Password)
            {

                password.ToolTip = "Passwords must be equals!";
                password.BorderBrush = Brushes.Red;
                return false;
            }
            else
            {
                textBox.BorderBrush = Brushes.Black;
                userMail.BorderBrush = Brushes.Black;
                passwordBox.BorderBrush = Brushes.Black;
                password.BorderBrush = Brushes.Black;
                return true;
            }
        }
    }
}
