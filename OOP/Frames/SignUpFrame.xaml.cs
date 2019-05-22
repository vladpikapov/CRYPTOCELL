using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using BLL.Secure;
using BLL.WorkWithUser.MailSender;
using BLL.WorkWithUser;
using BLL.DTO;
using BLL.Validators;

namespace OOP.Frames
{
    /// <summary>
    /// Логика взаимодействия для SignUpFrame.xaml
    /// </summary>
    public partial class SignUpFrame : Page
    {
        Sender mailsend = new Sender();
        WorkWithUserLog logWork = new WorkWithUserLog();
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
            if (validator.MyValidate(LoginUser, UserMail, UserFirstPass, UserSecondPass))
            {
                ChangeVisible();
                userCode = key.Next(1000, 10000);
                mailsend.UserCheckMail(userCode, UserMail.Text);
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
                if (userCode == result)
                {
                    mailsend.SendUserInfo(UserMail.Text, UserFirstPass.Password, LoginUser.Text);
                    SuccessMessage.Visibility = Visibility.Visible;
                    CheckBlock.Visibility = Visibility.Collapsed;
                    CheckCode.Visibility = Visibility.Collapsed;
                    SubmitBut.Visibility = Visibility.Collapsed;
                    HashAndCheck check = new HashAndCheck();
                    try
                    {
                        logWork.AddUser(new Users_LogDTO { UserLogName = LoginUser.Text, UserLogPassword = check.HashPassword(UserFirstPass.Password), UserMail = UserMail.Text });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                CheckCode.BorderBrush = Brushes.Red;
            }
        }
    }
}
