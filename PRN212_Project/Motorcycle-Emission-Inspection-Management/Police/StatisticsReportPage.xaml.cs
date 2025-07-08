using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Motorcycle_Emission_Inspection_Management.BLL.DTOs;
using Motorcycle_Emission_Inspection_Management.BLL.Services;

namespace Motorcycle_Emission_Inspection_Management.Police
{
    public partial class StatisticsReportPage : Window
    {
        // service lấy thống kê (đã chuyển sang đồng bộ)
        private readonly InspectionRecordService _recordService = new();

        public StatisticsReportPage()
        {
            InitializeComponent();

            // giá trị mặc định: đầu tháng → hôm nay
            dpFrom.SelectedDate = new DateTime(DateTime.Today.Year,
                                               DateTime.Today.Month, 1);
            dpTo.SelectedDate = DateTime.Today;

            LoadReport();   // nạp dữ liệu lần đầu
        }

        /* ======== NÚT “Xem báo cáo” ======== */
        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            LoadReport();   // gọi hàm đồng bộ
        }

        /* ======== HÀM NẠP DỮ LIỆU ======== */
        private void LoadReport()
        {
            try
            {
                DateTime? from = dpFrom.SelectedDate;
                DateTime? to = dpTo.SelectedDate;

                // Lấy bộ lọc Pass / Fail / null
                string? resultFilter = null;                 // null = Tất cả
                if (cbResult.SelectedItem is ComboBoxItem item &&
                    item.Content?.ToString() != "Tất cả")
                {
                    resultFilter = item.Content.ToString();  // "Pass" hoặc "Fail"
                }

                /* ---- GỌI SERVICE ĐỒNG BỘ ---- */
                IList<FacilityReportDto> data =
                    _recordService.GetFacilityReports(from, to,
                                                      stationId: null,
                                                      phone: string.Empty);

                /* ---- LỌC THEO KẾT QUẢ (nếu cần) ---- */
                if (resultFilter == "Pass")
                    data = data.Where(r => r.PassedCount > 0).ToList();
                else if (resultFilter == "Fail")
                    data = data.Where(r => r.FailedCount > 0).ToList();



                /* ---- GẮN VÀO GRID ---- */
                dgReport.ItemsSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải báo cáo: {ex.Message}",
                                "Error", MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            new Dashboards.PoliceDashboard().Show();
            this.Close();
        }
    }
}
