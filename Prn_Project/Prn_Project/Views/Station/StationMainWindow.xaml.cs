using System.Windows;
using Prn_Project.Models;

namespace Prn_Project.Views.Station
{
    public partial class StationMainWindow : Window
    {
        private User _currentUser;

        public StationMainWindow(User user)
        {
            InitializeComponent();
            _currentUser = user;

            // Có thể dùng _currentUser.FullName để hiển thị người đang đăng nhập
        }
    }
}
