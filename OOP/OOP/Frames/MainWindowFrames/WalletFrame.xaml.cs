using BLL.DTO;
using BLL.GetCourse;
using BLL.Validators;
using BLL.WorkWithUser;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OOP.Frames.MainWindowFrames
{
    /// <summary>
    /// Логика взаимодействия для WalletFrame.xaml
    /// </summary>
    public partial class WalletFrame : Page
    {
        BrushConverter brush;
        Users_InfoDTO user { get; set; }
        private bool isValid = true;
        private bool isCan = true;
        WorkWithCurreincies workCur;
        WorkWithUserTransact workUser;
        WorkWithUserInfo infoWork;
        private decimal CurrencyPrice = 0;
        public WalletFrame()
        {
            InitializeComponent();
        }
        public WalletFrame(Users_InfoDTO userName)
        {
            InitializeComponent();
            ChooseCrypto.ItemsSource = new string[] { "BTC", "ETH", "DASH", "XEM" };
            ChooseCrypto.SelectedItem = "BTC";
            user = userName;
            AllCost.Content = "Purchase price: " + 0 + " USD";
            brush = new BrushConverter();
            workCur = new WorkWithCurreincies();
            workUser = new WorkWithUserTransact();
            infoWork = new WorkWithUserInfo();
        }

        private void ChooseCrypto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                CurrencyPrice = GetCurInfo.GetExchangeInfo("USD", ChooseCrypto.SelectedItem.ToString()).Last;
            }
            catch
            {
                MessageBox.Show("Bad internet connection!");
                LoginScreen main = new LoginScreen();
                Application.Current.MainWindow.Close();
                main.Show();
            }
            try
            {
                AllCost.Content = "Purchase price: " + (decimal.Parse(CryptoAmmount.Text) * CurrencyPrice).ToString() + " USD";
            }
            catch
            {

            }
        }
        private void CloseFirstHalf()
        {
            ChooseCrypto.IsEnabled = false;
            CryptoAmmount.IsEnabled = false;
            ToUser.IsEnabled = false;

        }
        private void OpenSecondHalf()
        {

            UserCard.IsEnabled = true;
            CardMonth.IsEnabled = true;
            CardYear.IsEnabled = true;
            UserSecureCode.IsEnabled = true;
            PayAll.Visibility = Visibility.Visible;
            UserFirstName.IsEnabled = true;
            UserLastName.IsEnabled = true;
            CardOrUser.IsEnabled = true;
            ChangeCryptoAsset.Background = (Brush)brush.ConvertFromString("#117685");
            SendToUser.Background = (Brush)brush.ConvertFromString("#33B9CC");
            UserCardStack.Background = (Brush)brush.ConvertFromString("#33B9CC");

        }
        private bool CheckUser()
        {
            try
            {

                if (infoWork.GetUser(ToUser.Text) == null)
                    throw new Exception();
                ToUser.BorderBrush = Brushes.Black;
                return true;
            }
            catch
            {
                MessageBox.Show("Nonexistent user!");
                ToUser.BorderBrush = Brushes.Red;
                return false;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isValid && CheckUser())
            {
                OpenSecondHalf();
                CloseFirstHalf();
                if (ToUser.Text.Equals(user.UserName,StringComparison.InvariantCultureIgnoreCase))
                {

                    PayToUser.IsEnabled = false;
                }
            }
           
        }

        private void CryptoAmmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                isValid = true;
                AllCost.Content = "Purchase price: " + (decimal.Parse(CryptoAmmount.Text) * CurrencyPrice).ToString() + " USD";
                if (string.IsNullOrEmpty(CryptoAmmount.Text))
                    throw new Exception();
                CryptoAmmount.BorderBrush = Brushes.Black;
                CryptoAmmount.ToolTip = null;
            }
            catch
            {
                isValid = false;
                CryptoAmmount.BorderBrush = Brushes.Red;
                CryptoAmmount.ToolTip = "Wrong value!";
            }
        }

        private void PayAll_Click(object sender, RoutedEventArgs e)
        {
            InputValidator validator = new InputValidator();
            if (validator.MyValidate(UserCard, CardMonth, CardYear, UserSecureCode, UserFirstName, UserLastName))
            {

                var query = workCur.GetCur(ChooseCrypto.SelectedItem.ToString(), ToUser.Text);
                if (query == null)
                {
                    MessageBox.Show("Can`t find this user!");
                    NavigationService.Navigate(new WalletFrame(user));

                }
                else
                {


                    query.CurBalance += decimal.Parse(CryptoAmmount.Text);
                    workCur.SaveInfo(query);
                    MakeTransaction("+", query,"card");
                    MessageBox.Show("Excellent!");
                    NavigationService.Navigate(new WalletFrame(user));

                }

            }

        }
        private void MakeTransaction(string sign,CurreinciesDTO info,string username)
        {
            var trans = new Users_TransactionDTO();
            trans.FromUserName = username;
            trans.ToUserName = ToUser.Text;
            trans.SumOfTans = sign + " "+(decimal.Parse(CryptoAmmount.Text) * CurrencyPrice).ToString() + " $";
            trans.DateOfTrans = DateTime.Now;
            trans.UserID = (int)infoWork.GetUser(info.UserName).UserID;
            workUser.AddTransact(trans);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var FromQuery = workCur.GetCur(ChooseCrypto.SelectedItem.ToString(), user.UserName);
            var query = workCur.GetCur(ChooseCrypto.SelectedItem.ToString(), ToUser.Text);
            if (query == null)
            {
                MessageBox.Show("Can`t find this user!");
                NavigationService.Navigate(new WalletFrame(user));
            }
            else
            {

                if (FromQuery.CurBalance >= decimal.Parse(CryptoAmmount.Text))
                {
                    FromQuery.CurBalance -= decimal.Parse(CryptoAmmount.Text);
                    MakeTransaction("-", FromQuery, FromQuery.UserName);
                    workCur.SaveInfo(FromQuery);

                }
                else
                {
                    MessageBox.Show("Your balance less than send value!");
                    NavigationService.Navigate(new WalletFrame(user));
                    isCan = false;

                }
                if (isCan)
                {
                    query.CurBalance += decimal.Parse(CryptoAmmount.Text);
                    MakeTransaction("+", query, FromQuery.UserName);
                    workCur.SaveInfo(query);
                    MessageBox.Show("Excellent!");
                    NavigationService.Navigate(new WalletFrame(user));
                }
            }

        }

        private void ToUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                isValid = true;
                AllCost.Content = "Purchase price: " + (decimal.Parse(CryptoAmmount.Text) * CurrencyPrice).ToString() + " USD";
                if (string.IsNullOrEmpty(ToUser.Text))
                    throw new Exception();
                ToUser.BorderBrush = Brushes.Black;
                ToUser.ToolTip = null;
            }
            catch
            {
                isValid = false;
                ToUser.BorderBrush = Brushes.Red;
                ToUser.ToolTip = "Wrong value!";
            }
        }
    }
}
