using BLL.Secure;
using BLL.Validators;
using BLL.WorkWithUser;
using BLL.WorkWithUser.MailSender;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OOP.Frames
{
    /// <summary>
    /// Логика взаимодействия для ForgotFrame.xaml
    /// </summary>
    public partial class ForgotFrame : Page
    {
        Random rand;
        HashAndCheck check;
        WorkWithUserLog log = new WorkWithUserLog();
        Sender mail;
        int key = 0;
        InputValidator valid;
        public ForgotFrame()
        {
            InitializeComponent();
            mail = new Sender();
            check = new HashAndCheck();
            rand = new Random();
            valid = new InputValidator();
        }
        private void VisibleStepTwo()
        {
            EnterLog.Visibility = Visibility.Collapsed;
            LoginUser.Visibility = Visibility.Collapsed;
            SendButton.Visibility = Visibility.Collapsed;
            CodeSend.Visibility = Visibility.Visible;
            EnterCode.Visibility = Visibility.Visible;
            SubmitButton.Visibility = Visibility.Visible;
        }
        private void VisibleStepThree()
        {
            CodeSend.Visibility = Visibility.Collapsed;
            EnterCode.Visibility = Visibility.Collapsed;
            SubmitButton.Visibility = Visibility.Collapsed;
            PasswordF.Visibility = Visibility.Visible;
            PasswordS.Visibility = Visibility.Visible;
            FirstPassword.Visibility = Visibility.Visible;
            SecondPassword.Visibility = Visibility.Visible;
            SubmitPassButton.Visibility = Visibility.Visible;
        }
        private void VisibleStepForth()
        {
            PasswordF.Visibility = Visibility.Collapsed;
            PasswordS.Visibility = Visibility.Collapsed;
            FirstPassword.Visibility = Visibility.Collapsed;
            SecondPassword.Visibility = Visibility.Collapsed;
            SubmitPassButton.Visibility = Visibility.Collapsed;
            SuccessMessage.Visibility = Visibility.Visible;
        }
    
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            key = rand.Next();
            try
            {
                if (!string.IsNullOrEmpty(LoginUser.Text))
                {
                    mail.ForgotPass(LoginUser.Text, key);
                    VisibleStepTwo();
                }
                else
                {
                    LoginUser.BorderBrush = Brushes.Red;
                    LoginUser.ToolTip = "Login can`t be empty!";
                }
            }
            catch
            {
                EnterCode.BorderBrush = Brushes.Red;
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            int userKey;
            if (!int.TryParse(EnterCode.Text, out userKey))
            {
                EnterCode.BorderBrush = Brushes.Red;
                EnterCode.ToolTip = "Enter the number!";
            }
            if (key == userKey)
                VisibleStepThree();
            else
            {
                EnterCode.ToolTip = "Wrong entered code!";
                EnterCode.BorderBrush = Brushes.Red;
            }

        }

        private void SubmitPassButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (valid.MyValidate(FirstPassword, SecondPassword))
            {

                var user = log.GetUser(LoginUser.Text);
                user.UserLogPassword = check.HashPassword(FirstPassword.Text);
                VisibleStepForth();
                mail.NewPassword(LoginUser.Text, FirstPassword.Text);
                log.SaveInfo(user);

            }
        }
    }
}
