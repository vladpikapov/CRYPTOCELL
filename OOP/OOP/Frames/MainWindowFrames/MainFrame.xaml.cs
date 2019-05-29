using BLL.DTO;
using BLL.GetCourse;
using BLL.WorkWithUser;
using OOP.Frames.MainWindowFrames;
using System;
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
        public static string selectedCourse;
        Users_InfoDTO User { get; set; }
        WorkWithUserInfo userWork = new WorkWithUserInfo();
        WorkWithCurreincies work = new WorkWithCurreincies();

        public MainFrame()
        {
            InitializeComponent();
        }
        public MainFrame(Users_InfoDTO userinfo)
        {
            InitializeComponent();
            User = userinfo;
            ChangeValue.ItemsSource = new string[] { "USD", "EUR", "RUB", "BYN" };
            ChangeValue.SelectedItem = "USD";
            GetCourse(ChangeValue.SelectedItem.ToString());
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            FillGrid();
        }
        void FillGrid()
        {
            InfoTable.ItemsSource = work.GetUserCurrency(User.UserName).Select(x => new { x.CurName, x.CurBalance, x.CurCourseNow });
        }
        private void GetCourse(string selectedItm)
        {
            decimal allSum = 0;
            decimal curCourse = 0;
            var cur = work.GetUserCurrency(User.UserName);
            try
            {
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

                AllBalance.Content = "Your balance: " + Math.Round(allSum, 3) + " " + ChangeValue.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("Bad internet connection!");
                LoginScreen main = new LoginScreen();
                Application.Current.MainWindow.Close();
                main.Show();
            }


        }


    

        private void ChangeValue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCourse = ChangeValue.SelectedItem.ToString();
            GetCourse(ChangeValue.SelectedItem.ToString());
            FillGrid();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WalletFrame(User));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new History(User));
        }
    }
}
