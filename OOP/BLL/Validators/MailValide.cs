using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Net.Mail;
using System.Net;

namespace BLL.Validators
{
  public  class MailValide
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
        public bool CheckInternet()
        {
            WebClient client = new WebClient();
            try
            {
                using (client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
