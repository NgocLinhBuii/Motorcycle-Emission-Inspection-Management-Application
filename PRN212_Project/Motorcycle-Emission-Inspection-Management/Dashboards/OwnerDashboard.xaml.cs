using Motorcycle_Emission_Inspection_Management.VehicleOwner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Motorcycle_Emission_Inspection_Management.Dashboards
{
    /// <summary>
    /// Interaction logic for OwnerDashboard.xaml
    /// </summary>
    public partial class OwnerDashboard : Window
    {
        public OwnerDashboard()
        {
            InitializeComponent();
            MainContent.Content = new TextBlock
            {
                Text = "Chào mừng Chủ phương tiện!",
                FontSize = 24,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
        }

        private void VehicleListBtn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new VehicleOwner.VehicleListPage();
        }

        /* ---------- Thêm xe ---------- */
        private void AddVehicleBtn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new VehicleOwner.AddVehiclePage();
        }

        /* ---------- Đăng ký kiểm định ---------- */
        private void RegisterInspectionBtn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new VehicleOwner.RegisterInspectionPage();
        }

        /* ---------- Lịch sử kiểm định ---------- */
        private void InspectionHistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new VehicleOwner.InspectionHistoryPage();
        }

        /* ---------- Thông báo ---------- */
        private void NotificationBtn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new VehicleOwner.NotificationPage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new();
            login.Show();
            Close();
        }

        private void MainContent_Loaded(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new VehicleOwner.VehicleListPage();
        }
    }
}
