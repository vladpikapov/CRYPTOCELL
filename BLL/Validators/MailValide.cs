using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Net.Mail;

namespace BLL.Validators
{
    class MailValide
    {
        public bool MyMailValid(TextBox mail)
        {
            try
            {
                var m = new MailAddress(mail.Text);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
