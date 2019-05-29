using BLL.DTO;
using OOP.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OOP
{
    /// <summary>
    /// Логика взаимодействия для LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
       BrushConverter brush;
        int count = 0;
        

        public LoginScreen()
        {
            InitializeComponent();
            brush = new BrushConverter();
            Sign_in.Background = (Brush)brush.ConvertFromString("#33B9CC");
            logFrame.Navigate(new LogInFrame());

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Sign_in_Click(object sender, RoutedEventArgs e)
        {
            if (ForgotPass.Visibility == Visibility.Hidden)
                ForgotPass.Visibility = Visibility.Visible;
            if (Sign_up.Background != (Brush)brush.ConvertFromString("#005763"))
                Sign_up.Background = (Brush)brush.ConvertFromString("#005763");
            Sign_in.Background = (Brush)brush.ConvertFromString("#33B9CC");
            logFrame.Navigate(new LogInFrame());
            if (count > 0)
            {
                logFrame.Height -= 250;
                Height -= 250;
                count = 0;
            }
        }

        private void Sign_up_Click(object sender, RoutedEventArgs e)
        {
            ForgotPass.Visibility = Visibility.Hidden;
            if (Sign_in.Background != (Brush)brush.ConvertFromString("#005763"))
                Sign_in.Background = (Brush)brush.ConvertFromString("#005763");
            Sign_up.Background = (Brush)brush.ConvertFromString("#33B9CC");
            logFrame.Navigate(new SignUpFrame());
            if (count == 0)
            {
                logFrame.Height += 250;
                Height += 250;
                count++;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            logFrame.Navigate(new ForgotFrame());
            ForgotPass.Visibility = Visibility.Hidden;
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            logFrame.Visibility = Visibility.Hidden;
            ProgressBarS.Visibility = Visibility.Visible;
        }
    }
}
