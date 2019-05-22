using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BLL.DTO;
using OOP.Frames.MainWindowFrames;

namespace OOP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Users_InfoDTO user { get; set; }
        public MainWindow(string name)
        {
            InitializeComponent();
            user = new Users_InfoDTO { UserName = name };
            Frame.Navigate(new MainFrame(user));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();   
        }

        private void Profile_Selected(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new MainFrame(user));
        }

        private void UserWallet_Selected(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new WalletFrame(user));
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new WalletFrame(user));
        }

        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new History(user));
        }

        private void ListViewItem_Selected_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new Convert(user));
        }

        private void ListViewItem_Selected_3(object sender, RoutedEventArgs e)
        {
            LoginScreen login = new LoginScreen();
            login.Show();
            Close();
        }
    }
}