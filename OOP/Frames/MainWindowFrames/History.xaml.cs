using BLL.DTO;
using BLL.WorkWithUser;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OOP.Frames.MainWindowFrames
{
    /// <summary>
    /// Логика взаимодействия для History.xaml
    /// </summary>
    public partial class History : Page
    {
        private Users_InfoDTO user { get; set; }
        public History()
        {
            InitializeComponent();
        }
        public History(Users_InfoDTO userInfo)
        {
            InitializeComponent();
            user = userInfo;
        }
        WorkWithUserTransact work = new WorkWithUserTransact();
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UserHistory.ItemsSource = UserHistory.ItemsSource = work.GetTransaction(user).Select(x=>new {x.FromUserName,x.ToUserName,x.SumOfTans});
        }
    }
}
