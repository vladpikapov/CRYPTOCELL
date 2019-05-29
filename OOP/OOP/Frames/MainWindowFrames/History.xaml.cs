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
        WorkWithUserTransact work = new WorkWithUserTransact();
        public History()
        {
            InitializeComponent();
        }
        public History(Users_InfoDTO userInfo)
        {
            InitializeComponent();
            user = userInfo;
            UserHistory.ItemsSource = UserHistory.ItemsSource = work.GetTransaction(user).Select(x => new { x.FromUserName, x.ToUserName, x.SumOfTans,x.DateOfTrans });
        }
        
       
    }
}
