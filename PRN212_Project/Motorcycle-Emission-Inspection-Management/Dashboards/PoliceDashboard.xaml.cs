using System.Windows;
using Motorcycle_Emission_Inspection_Management.Police;   // chứa 3 trang con

namespace Motorcycle_Emission_Inspection_Management.Dashboards
{
    public partial class PoliceDashboard : Window
    {
        public PoliceDashboard()
        {
            InitializeComponent();
        }

        /* ==== Mở trang Tra cứu phương tiện ==== */
        private void BtnLookup_Click(object sender, RoutedEventArgs e)
        {
            new VehicleLookupPage().Show();
            Close();    // đóng dashboard nếu muốn
        }

        /* ==== Mở trang Ghi nhận vi phạm ==== */
        private void BtnViolation_Click(object sender, RoutedEventArgs e)
        {
            new ViolationRecordPage().Show();
            Close();
        }

        /* ==== Mở trang Báo cáo thống kê ==== */
        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            new StatisticsReportPage().Show();
            Close();
        }

        /* ==== Đăng xuất – quay về màn hình đăng nhập ==== */
        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            // new LoginWindow().Show();  // nếu có LoginWindow
            Close();
        }
    }
}
