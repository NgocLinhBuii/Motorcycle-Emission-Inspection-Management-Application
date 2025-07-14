using System.Windows;
using System.Windows.Controls;

namespace Motorcycle_Emission_Inspection_Management
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContent.Content = new TextBlock
            {
                Text = "Chào mừng Admin!",
                FontSize = 24,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Admin.SystemConfigView();
        }

        private void Vehicle_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new TextBlock { Text = "Quản lý xe", FontSize = 24 };
        }

        private void Inspection_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new TextBlock { Text = "Kiểm định", FontSize = 24 };
        }

        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Admin.StatisticsView();
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new TextBlock { Text = "Tài khoản", FontSize = 24 };
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
