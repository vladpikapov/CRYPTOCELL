using BLL.DTO;
using BLL.GetCourse;
using BLL.WorkWithUser;
using OOP.Frames.MainWindowFrames;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace OOP
{
    /// <summary>
    /// Логика взаимодействия для MainFrame.xaml
    /// </summary>
    public partial class MainFrame : Page
    {

        Users_InfoDTO user { get; set; }
        
        WorkWithCurreincies work = new WorkWithCurreincies();

        public MainFrame()
        {
            InitializeComponent();
        }
        public MainFrame(Users_InfoDTO userinfo)
        {
            InitializeComponent();
            user = userinfo;
            ChangeValue.ItemsSource = new string[] { "USD", "EUR", "RUB","BYN" };
            ChangeValue.SelectedItem = "USD";
            GetCourse(ChangeValue.SelectedItem.ToString());
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            FillGrid();
        }
        void FillGrid()
        {
            InfoTable.ItemsSource = work.GetUserCurrency(user.UserName).Select(x => new { x.CurName, x.CurBalance, x.CurCourseNow });
        }
        private void GetCourse(string selectedItm)
        {
            decimal allSum = 0;
            decimal curCourse = 0;
            var cur = work.GetUserCurrency(user.UserName);
            foreach (var c in cur)
            {
                switch (c.CurName)
                {

                    case "BTC":
                        {
                            curCourse = GetCurInfo.GetExchangeInfo(selectedItm, "btc").Last;
                            c.CurCourseNow = curCourse;
                            allSum += curCourse * c.CurBalance;
                            work.SaveInfo(c);
                            break;
                        }

                    case "ETH":
                        {
                            curCourse = GetCurInfo.GetExchangeInfo(selectedItm, "eth").Last;
                            c.CurCourseNow = curCourse;
                            allSum += curCourse * c.CurBalance;
                            work.SaveInfo(c);
                            break;
                        }

                    case "XEM":
                        {
                            curCourse = GetCurInfo.GetExchangeInfo(selectedItm, "xem").Last;
                            c.CurCourseNow = curCourse;
                            allSum += curCourse * c.CurBalance;
                            work.SaveInfo(c);
                            break;

                        }
                    case "DASH":
                        {
                            curCourse = GetCurInfo.GetExchangeInfo(selectedItm, "dash").Last;
                            c.CurCourseNow = curCourse;//update in other value
                            allSum += curCourse * c.CurBalance;
                            work.SaveInfo(c);
                            break;
                        }
                        
                }
                            
            }

            AllBalance.Content = "Your balance: " + allSum.ToString() + " " + ChangeValue.SelectedItem.ToString();
          
        }

        private void ChangeValue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetCourse(ChangeValue.SelectedItem.ToString());
            FillGrid();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WalletFrame(user));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new History(user));
        }
    }
}
