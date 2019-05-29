using BLL.DTO;
using BLL.GetCourse;
using BLL.Validators;
using BLL.WorkWithUser;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OOP.Frames.MainWindowFrames
{
    /// <summary>
    /// Логика взаимодействия для Convert.xaml
    /// </summary>
    public partial class Convert : Page
    {
        private Users_InfoDTO User { get; set; }
        private WorkWithCurreincies workCurreincies = new WorkWithCurreincies();
        private MailValide mailValide = new MailValide();

        public Convert()
        {
            InitializeComponent();

        }
        public Convert(Users_InfoDTO userInfo)
        {
            InitializeComponent();
            var source = new string[] { "BTC", "ETH", "DASH", "XEM" };
            User = userInfo;
           
            FirstCrypto.ItemsSource = source;
            SecondCrypto.ItemsSource = source;
            SecondCrypto.SelectedItem = "ETH";
            FirstCrypto.SelectedItem = "BTC";
            GetInfo(SecondCrypto.SelectedItem.ToString(), FirstCrypto.SelectedItem.ToString());
            FirstEnter.Text = "0";

        }
        private void GetInfo(string firstValue, string secondValue)
        {
            if (mailValide.CheckInternet())
            {
                SecondCost.Content = Math.Round(GetCurInfo.GetExchangeInfo(firstValue, secondValue).Last, 3);
                SecondValue.Content = $" {SecondCrypto.SelectedItem}";

            }
            else
            {
                LoginScreen main = new LoginScreen();
                
                main.Show();
                Application.Current.MainWindow.Close();

            }

        }
        private void FirstCrypto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(mailValide.CheckInternet())
            {
                GetInfo(SecondCrypto.SelectedItem.ToString(), FirstCrypto.SelectedItem.ToString());
            }
            else
            {
                
                LoginScreen main = new LoginScreen();
              
                Application.Current.MainWindow.Close();
                main.Show();

            }
            FirstImage.Source = new BitmapImage(new Uri($@" C:\Users\vladnstr\source\repos\OOP\OOP\SomeIcons\{FirstCrypto.SelectedItem.ToString()}.png"));
            UserBalance.Content = "Your balance " + workCurreincies.GetCur(FirstCrypto.SelectedItem.ToString(), User.UserName).CurBalance;
            UserBalanceMoney.Content = $"Your balance in {MainFrame.selectedCourse}: " + Math.Round(workCurreincies.GetCur(FirstCrypto.SelectedItem.ToString(), User.UserName).CurBalance * workCurreincies.GetCur(FirstCrypto.SelectedItem.ToString(), User.UserName).CurCourseNow, 3).ToString();

        }

        private void SecondCrypto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FirstCrypto.SelectedItem != null)
            {
                if (mailValide.CheckInternet())
                    GetInfo(SecondCrypto.SelectedItem.ToString(), FirstCrypto.SelectedItem.ToString());
                else
                {

                    LoginScreen main = new LoginScreen();
                    
                    Application.Current.MainWindow.Close();
                    main.Show();

                }
                SecondImage.Source = new BitmapImage(new Uri($@"C:\Users\vladnstr\source\repos\OOP\OOP\SomeIcons\{SecondCrypto.SelectedItem.ToString()}.png"));
            }
        }


        private void FirstEnter_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                FirstEnter.ToolTip = "";
                FirstEnter.BorderBrush = Brushes.Black;
                SecondCost.Content = Math.Round((GetCurInfo.GetExchangeInfo(SecondCrypto.SelectedItem.ToString(), FirstCrypto.SelectedItem.ToString()).Last * decimal.Parse(FirstEnter.Text)),3);
                SecondValue.Content = $" {SecondCrypto.SelectedItem}";
            }
            catch
            {

                FirstEnter.BorderBrush = Brushes.Red;
                FirstEnter.ToolTip = "Wrong value!";
            }

        }
        private bool isValid()
        {
            FirstEnter.ToolTip = "";
            FirstEnter.BorderBrush = Brushes.Black;
            if (FirstCrypto.SelectedItem.Equals(SecondCrypto.SelectedItem))
                return false;
            if (decimal.Parse(FirstEnter.Text) > workCurreincies.GetCur(FirstCrypto.SelectedItem.ToString(), User.UserName).CurBalance)
            {

                FirstEnter.ToolTip = "Your balance less than this value!";
                FirstEnter.BorderBrush = Brushes.Red;
                    return false;
            }
            return true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WorkWithCurreincies curreincies = new WorkWithCurreincies();
            if (isValid())
            {
                var was = workCurreincies.GetCur(FirstCrypto.SelectedItem.ToString(), User.UserName);
                var were = workCurreincies.GetCur(SecondCrypto.SelectedItem.ToString(), User.UserName);
                was.CurBalance -= decimal.Parse(FirstEnter.Text);
                were.CurBalance += decimal.Parse(SecondCost.Content.ToString());
                workCurreincies.SaveInfo(was);
                workCurreincies.SaveInfo(were);
                UserBalance.Content = "Your balance " + workCurreincies.GetCur(FirstCrypto.SelectedItem.ToString(), User.UserName).CurBalance;
                UserBalanceMoney.Content = $"Your balance in {MainFrame.selectedCourse}: " + Math.Round(workCurreincies.GetCur(FirstCrypto.SelectedItem.ToString(), User.UserName).CurBalance * workCurreincies.GetCur(FirstCrypto.SelectedItem.ToString(), User.UserName).CurCourseNow, 3).ToString();
                
            }

        }
    }

}
