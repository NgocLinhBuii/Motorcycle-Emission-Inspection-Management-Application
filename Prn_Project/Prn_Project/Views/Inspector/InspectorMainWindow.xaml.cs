using System.Windows;
using Prn_Project.Models;

namespace Prn_Project.Views.Inspector
{
    public partial class InspectorMainWindow : Window
    {
        private User _currentUser;

        public InspectorMainWindow(User user)
        {
            InitializeComponent();
            _currentUser = user;

            // Có thể hiển thị _currentUser.FullName nếu muốn
        }
    }
}
