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
        }

        private void VehicleListBtn_Click(object sender, RoutedEventArgs e)
        {
            var win = new VehicleListPage();
            win.ShowDialog();
        }

        /* ---------- Thêm xe ---------- */
        private void AddVehicleBtn_Click(object sender, RoutedEventArgs e)
        {
            var win = new AddVehiclePage();
            win.ShowDialog();
        }

        /* ---------- Đăng ký kiểm định ---------- */
        private void RegisterInspectionBtn_Click(object sender, RoutedEventArgs e)
        {
            var win = new RegisterInspectionPage();
            win.ShowDialog();
        }

        /* ---------- Lịch sử kiểm định ---------- */
        private void InspectionHistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            var win = new InspectionHistoryPage();
            win.ShowDialog();
        }

        /* ---------- Thông báo ---------- */
        private void NotificationBtn_Click(object sender, RoutedEventArgs e)
        {
            var win = new NotificationPage();
            win.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
        }
    }
}
