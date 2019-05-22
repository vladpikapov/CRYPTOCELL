using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace BLL.Validators
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
       
        public bool MyValidate(TextBox UserCard, TextBox CardMonth,TextBox CardYear, TextBox UserSecureCode, TextBox UserFirstName, TextBox UserLastName)
        {
          Regex regex = new Regex("^[0-9]");
            if (UserCard.Text.Length != 16 || !regex.IsMatch(UserCard.Text))
            {
                UserCard.BorderBrush = Brushes.Red;
                UserCard.ToolTip = "Wrong card number!";
                return false;
            }
            try
            {
                if (!regex.IsMatch(CardMonth.Text) || int.Parse(CardMonth.Text) > 12 || CardMonth.Text.Length < 2 || int.Parse(CardMonth.Text) == 0)
                {
                    CardMonth.BorderBrush = Brushes.Red;
                    CardMonth.ToolTip = "Wrong month!";
                    return false;
                }
                if (!regex.IsMatch(CardYear.Text) && CardYear.Text.Length < 2)
                {
                    CardYear.BorderBrush = Brushes.Red;
                    CardYear.ToolTip = "Wrong year!";
                    return false;
                }
            }
            catch
            {
                CardMonth.BorderBrush = Brushes.Red;
                CardMonth.ToolTip = "Wrong month!";
                CardYear.BorderBrush = Brushes.Red;
                CardYear.ToolTip = "Wrong year!";
                return false;
            }
            if (!regex.IsMatch(UserSecureCode.Text))
            {
                UserSecureCode.BorderBrush = Brushes.Red;
                UserSecureCode.ToolTip = "Wrong secure code!";
                return false;
            }
            regex = new Regex("^[A-z]");
            if (!regex.IsMatch(UserFirstName.Text))
            {
                UserFirstName.BorderBrush = Brushes.Red;
                UserFirstName.ToolTip = "Wrong name!";
                return false;
            }
            if (!regex.IsMatch(UserLastName.Text))
            {
                UserLastName.BorderBrush = Brushes.Red;
                UserLastName.ToolTip = "Wrong surname!";
                return false;
            }
            return true;
        }
        public virtual bool MyValidate(TextBox passwordBox, TextBox password)
        {


            if (passwordBox.Text.Length < 5)
            {
                passwordBox.ToolTip = "Password must be longer than 5 symbols!";
                passwordBox.BorderBrush = Brushes.Red;
                return false;
            }
            if (passwordBox.Text != password.Text)
            {

                password.ToolTip = "Passwords must be equals!";
                password.BorderBrush = Brushes.Red;
                return false;
            }
            else
            {
                passwordBox.BorderBrush = Brushes.Black;
                password.BorderBrush = Brushes.Black;
                return true;
            }

        }
    }
}
