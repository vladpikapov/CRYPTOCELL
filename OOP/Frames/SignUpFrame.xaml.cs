using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes;
using OOP.MailSends;
using OOP.Validators;

namespace OOP.Frames
{
    /// <summary>
    /// Логика взаимодействия для SignUpFrame.xaml
    /// </summary>
    public partial class SignUpFrame : Page
    {
        MailSender mailsend = new MailSender();
        private Random key = new Random();
        private int userCode = 0;
        
        InputValidator validator;
        public SignUpFrame()
        {
            InitializeComponent();
            validator = new InputValidator();
        }
        private void ChangeVisible()
        {

            LoginUser.Visibility = Visibility.Collapsed;
            UserMail.Visibility = Visibility.Collapsed;
            UserFirstPass.Visibility = Visibility.Collapsed;
            UserSecondPass.Visibility = Visibility.Collapsed;
            EnterLogin.Visibility = Visibility.Collapsed;
            EnterMail.Visibility = Visibility.Collapsed;
            EnterPassword.Visibility = Visibility.Collapsed;
            RepeatPassword.Visibility = Visibility.Collapsed;
            SignUpBut.Visibility = Visibility.Collapsed;
            CheckCode.Visibility = Visibility.Visible;
            SubmitBut.Visibility = Visibility.Visible;
            CheckBlock.Visibility = Visibility.Visible;

        }        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(validator.MyValidate(LoginUser,UserMail,UserFirstPass,UserSecondPass))
            {        
                    ChangeVisible();
                   userCode = key.Next(1000, 10000);
                    mailsend.UserCheckMail(userCode, UserMail);          
            }
          
        }

        private void LoginUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginUser.Text))
            {
                LoginUser.BorderBrush = Brushes.Red;
                LoginUser.ToolTip = "Login can`t be empty!";
            }
            else
            {
                LoginUser.BorderBrush = Brushes.Black;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int result = 0;
            if (!string.IsNullOrEmpty(CheckCode.Text))
            {
                int.TryParse(CheckCode.Text, out result);
                MessageBox.Show(result.ToString());
                if (userCode == result)
                {
                    mailsend.SendUserInfo(UserMail, UserFirstPass, LoginUser);
                    SuccessMessage.Visibility = Visibility.Visible;
                    CheckBlock.Visibility = Visibility.Collapsed;
                    CheckCode.Visibility = Visibility.Collapsed;
                    SubmitBut.Visibility = Visibility.Collapsed;
                }
                else
                {
                    CheckCode.BorderBrush = Brushes.Red;
                }
                    
            }
        }
    }
}
