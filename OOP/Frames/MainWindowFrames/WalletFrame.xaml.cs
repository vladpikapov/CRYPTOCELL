using BLL.DTO;
using BLL.GetCourse;
using BLL.Validators;
using BLL.WorkWithUser;
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
        }

        private void ChooseCrypto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrencyPrice = GetCurInfo.GetExchangeInfo("USD", ChooseCrypto.SelectedItem.ToString()).Last;
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isValid && !string.IsNullOrEmpty(ToUser.Text) && !string.IsNullOrEmpty(CryptoAmmount.Text))
            {
                OpenSecondHalf();
                CloseFirstHalf();
                if (ToUser.Text.Equals(user.UserName))
                {
                    PayToUser.IsEnabled = false;
                }
            }
            else
            {
                CryptoAmmount.BorderBrush = Brushes.Red;
                CryptoAmmount.ToolTip = "Wrong value!";
            }
        }

        private void CryptoAmmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                isValid = true;
                AllCost.Content = "Purchase price: " + (decimal.Parse(CryptoAmmount.Text) * CurrencyPrice).ToString() + " USD";
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


                    var trans = new Users_TransactionDTO();
                    trans.FromUserName = UserFirstName.Text + " " + UserLastName.Text;
                    trans.ToUserName = ToUser.Text;
                    trans.SumOfTans = decimal.Parse(CryptoAmmount.Text) * CurrencyPrice;
                    workUser.AddTransact(trans);
                    MessageBox.Show("Excellent!");
                }

            }

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
                    workCur.SaveInfo(query);
                    var trans = new Users_TransactionDTO();
                    trans.FromUserName = user.UserName;
                    trans.ToUserName = ToUser.Text;
                    trans.SumOfTans = decimal.Parse(CryptoAmmount.Text) * CurrencyPrice;
                    workUser.AddTransact(trans);
                    MessageBox.Show("Excellent!");
                }
            }
        }
    }
}
