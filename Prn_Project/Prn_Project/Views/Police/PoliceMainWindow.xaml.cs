using System.Windows;
using Prn_Project.Models;

namespace Prn_Project.Views.Police
{
    public partial class PoliceMainWindow : Window
    {
        private User _currentUser;

        public PoliceMainWindow(User user)
        {
            InitializeComponent();
            _currentUser = user;

            // Có thể hiển thị _currentUser.FullName nếu cần
        }
    }
}
