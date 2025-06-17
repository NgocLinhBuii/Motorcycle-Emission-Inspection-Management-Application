using System.Windows;
using Prn_Project.Models;

namespace Prn_Project.Views.Owner
{
    public partial class OwnerMainWindow : Window
    {
        private User _currentUser;

        public OwnerMainWindow(User user)
        {
            InitializeComponent();
            _currentUser = user;
            // có thể hiển thị tên user nếu muốn
        }
    }
}
