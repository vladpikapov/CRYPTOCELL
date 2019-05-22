
using BLL.Secure;
using BLL.WorkWithUser;
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
        public LogInFrame()
        {
            InitializeComponent();
            userLog = new WorkWithUserLog();
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
            if (isTrue())
            {
                MainWindow main = new MainWindow(UserLogin.Text);
                Application.Current.MainWindow.Close();
                main.Show();

            }
        }
    }
}
