using Motorcycle_Emission_Inspection_Management.Admin;
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
            MainContent.Content = new VehicleEmissionReportPage();
        }

        private void Vehicle_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new VehicleManagementPage();
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
            MainContent.Content = new Admin.UserManagementView();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new();
            login.Show();
            Close();
        }

        private void MainContent_Loaded(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Admin.StatisticsView();
        }
    }
}
