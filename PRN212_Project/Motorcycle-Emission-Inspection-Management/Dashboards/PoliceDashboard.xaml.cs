using Motorcycle_Emission_Inspection_Management.Police;   // chứa 3 trang con
using System.Windows;
using System.Windows.Controls;

namespace Motorcycle_Emission_Inspection_Management.Dashboards
{
    public partial class PoliceDashboard : Window
    {
        public PoliceDashboard()
        {
            InitializeComponent();
            MainContent.Content = new TextBlock
            {
                Text = "Chào mừng Cảnh sát!",
                FontSize = 24,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
        }

        /* ==== Mở trang Tra cứu phương tiện ==== */
        private void BtnLookup_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Police.VehicleLookupPage();
            //new VehicleLookupPage().Show();
            //Close();    // đóng dashboard nếu muốn
        }

        /* ==== Mở trang Ghi nhận vi phạm ==== */
        private void BtnViolation_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Police.ViolationRecordPage();
        }

        /* ==== Mở trang Báo cáo thống kê ==== */
        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Police.StatisticsReportPage();
        }

        /* ==== Đăng xuất – quay về màn hình đăng nhập ==== */
        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new();
            login.Show();
            Close();
        }

        private void MainContent_Loaded(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Police.StatisticsReportPage();
        }
    }
}
