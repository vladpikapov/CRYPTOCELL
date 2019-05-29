
using BLL.DTO;
using BLL.Secure;
using BLL.Validators;
using BLL.WorkWithUser;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OOP.Frames
{
    /// <summary>
    /// Логика взаимодействия для LogInFrame.xaml
    /// </summary>
    public partial class LogInFrame : Page
    {
        WorkWithUserLog userLog;
        WorkWithUserInfo user { get; set; }
        MailValide mail; 
        public LogInFrame()
        {
            InitializeComponent();
            userLog = new WorkWithUserLog();
            user = new WorkWithUserInfo();
            mail = new MailValide();
        }
       
        private bool isTrue()
        {      
                var check = new HashAndCheck();
                var log = userLog.GetUser(UserLogin.Text);
                if(log == null)
                {
                    UserLogin.BorderBrush = Brushes.Red;
                    UserLogin.ToolTip = "Invalid login!";
                    return false;
                }
                else
                {
                    UserLogin.BorderBrush = Brushes.Black;
                }     
                    if (check.VerifyHashedPassword(log.UserLogPassword, UserPassword.Password))
                        return true;
                UserPassword.ToolTip = "Wrong password";
                UserPassword.BorderBrush = Brushes.Red;
                return false;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mail.CheckInternet())
            {
                if (isTrue())
                {
                    MainWindow main = new MainWindow(user.GetUser(UserLogin.Text));
                    Application.Current.MainWindow.Close();
                    main.Show();
                }
                

            }
            else
            {
                MessageBox.Show("Bad internet connection!");
            }
        }
    }
}
