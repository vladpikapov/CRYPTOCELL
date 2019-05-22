using BLL.DTO;
using BLL.GetCourse;
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
        Users_InfoDTO user { get; set; }
        WorkWithCurreincies work { get; set; }
        private bool isValid = true;
        public Convert()
        {
            InitializeComponent();

        }
        public Convert(Users_InfoDTO userInfo)
        {
            InitializeComponent();
            var source = new string[] { "BTC", "ETH", "DASH", "XEM" };
            user = userInfo;
            work = new WorkWithCurreincies();
            FirstCrypto.ItemsSource = source;
            SecondCrypto.ItemsSource = source;
            SecondCrypto.SelectedItem = "ETH";
            FirstCrypto.SelectedItem = "BTC";
            GetInfo(SecondCrypto.SelectedItem.ToString(), FirstCrypto.SelectedItem.ToString());
            FirstEnter.Text = "1";
        }
        private void GetInfo(string firstValue, string secondValue)
        {
            SecondCost.Content = GetCurInfo.GetExchangeInfo(firstValue, secondValue).Last;
            SecondValue.Content = $" {SecondCrypto.SelectedItem}";
        }
        private void FirstCrypto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetInfo(SecondCrypto.SelectedItem.ToString(), FirstCrypto.SelectedItem.ToString());
            FirstImage.Source = new BitmapImage(new Uri($"C:/Users/vladnstr/source/repos/OOP/OOP/SomeIcons/{FirstCrypto.SelectedItem.ToString()}.png"));
            UserBalance.Content = "Your balance " + work.GetCur(FirstCrypto.SelectedItem.ToString(), user.UserName).CurBalance;
        }

        private void SecondCrypto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FirstCrypto.SelectedItem != null)
            {
                GetInfo(SecondCrypto.SelectedItem.ToString(), FirstCrypto.SelectedItem.ToString());
                SecondImage.Source = new BitmapImage(new Uri($"C:/Users/vladnstr/source/repos/OOP/OOP/SomeIcons/{SecondCrypto.SelectedItem.ToString()}.png"));
            }
        }

        private void FirstEnter_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                isValid = true;
                FirstEnter.BorderBrush = Brushes.Black;
                SecondCost.Content = (GetCurInfo.GetExchangeInfo(SecondCrypto.SelectedItem.ToString(), FirstCrypto.SelectedItem.ToString()).Last * decimal.Parse(FirstEnter.Text));
                SecondValue.Content = $" {SecondCrypto.SelectedItem}";
            }
            catch
            {
                isValid = false;
                FirstEnter.BorderBrush = Brushes.Red;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isValid)
            {
                var was = work.GetCur(FirstCrypto.SelectedItem.ToString(), user.UserName);
                var were = work.GetCur(SecondCrypto.SelectedItem.ToString(), user.UserName);
                was.CurBalance -= decimal.Parse(FirstEnter.Text);
                were.CurBalance +=  decimal.Parse(SecondCost.Content.ToString());
                work.SaveInfo(was);
                work.SaveInfo(were);
                UserBalance.Content = "Your balance " + work.GetCur(FirstCrypto.SelectedItem.ToString(), user.UserName).CurBalance;
            }

        }
    }

}
