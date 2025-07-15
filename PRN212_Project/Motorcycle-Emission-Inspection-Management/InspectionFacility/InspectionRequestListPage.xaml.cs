using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Motorcycle_Emission_Inspection_Management.BLL.Services;
using Motorcycle_Emission_Inspection_Management.Dashboards;

namespace Motorcycle_Emission_Inspection_Management.InspectionFacility
{
    public partial class InspectionRequestListPage : Page
    {
        private readonly InspectionRecordService _recordService = new();

        public InspectionRequestListPage()
        {
            InitializeComponent();

            // gán mặc định: từ ngày = đầu tháng – đến ngày = hôm nay
            dpFrom.SelectedDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dpTo.SelectedDate = DateTime.Today;

            btnSearch.Click += BtnSearch_Click;

            _ = LoadGridAsync();   // nạp dữ liệu lần đầu
        }

        /* ------------ NẠP & LỌC GRID ------------ */
        private async Task LoadGridAsync()
        {
            try
            {
                DateTime? from = dpFrom.SelectedDate;
                DateTime? to = dpTo.SelectedDate;

                string result = null;                // Pass / Fail / null
                if (cbStatus.SelectedItem is ComboBoxItem item)
                {
                    string selected = item.Content.ToString();
                    if (selected != "Tất cả") result = selected;   // "Pass" hoặc "Fail"
                }

                /* ---- GỌI SERVICE LẤY DỮ LIỆU ---- */
                var data = await Task.Run(() =>
                   _recordService.GetRequests(from, to, result));

                /* ---- GẮN VÀO DATAGRID ---- */
                dgVehicles.ItemsSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}",
                                "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private async void BtnSearch_Click(object sender, RoutedEventArgs e) => await LoadGridAsync();

        /* ------------ NÚT THOÁT ------------ */
        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            new InspectionFacilityDashboardPage().Show();   // quay lại dashboard
        }
    }
}
