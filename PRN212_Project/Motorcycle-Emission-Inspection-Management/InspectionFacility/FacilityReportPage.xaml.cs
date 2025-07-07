using Motorcycle_Emission_Inspection_Management.BLL.Services;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using Motorcycle_Emission_Inspection_Management.Dashboards;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Motorcycle_Emission_Inspection_Management.InspectionFacility
{
    public partial class FacilityReportPage : Window
    {
        private readonly InspectionRecordService _service = new();
        private InspectionStationService _stationService = new();

        public FacilityReportPage()
        {
            InitializeComponent();
            LoadStations();
            _ = LoadReportsAsync();      // nạp dữ liệu ban đầu
        }

        /* ============ LOAD / FILTER DỮ LIỆU ============ */

        /// <summary>
        /// Lấy báo cáo (FacilityReportDto) theo bộ lọc và bind vào DataGrid.
        /// </summary>
        private async Task LoadReportsAsync(
            DateTime? from = null,
            DateTime? to = null,
            int? stationId = null,
            string? phone = null)
        {
            try
            {
                var reports = await _service.GetFacilityReportsAsync(
                                    from, to, stationId, phone ?? string.Empty);

                dgReports.ItemsSource = reports;   // bind thẳng DTO
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải báo cáo: {ex.Message}",
                                "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /* ================ SỰ KIỆN NÚT ================ */

        private async void BtnFilter_Click_1(object sender, RoutedEventArgs e)
        {
            int? stationId = (cbStationAddress.SelectedValue as int?) == 0
                  ? null            // Giá trị “Tất cả” => không lọc
                  : cbStationAddress.SelectedValue as int?;

            string? phone = string.IsNullOrWhiteSpace(tbPhone.Text)
                               ? null
                               : tbPhone.Text.Trim();

            await LoadReportsAsync(
                    dpFrom.SelectedDate,
                    dpTo.SelectedDate,
                    stationId,
                    phone);
        }

        private void LoadStations()
        {
            // Lấy tất cả trạm
            var stations = _stationService.GetAll();     // List<InspectionStation>

            // Thêm mục “Tất cả” ở đầu (tuỳ chọn)
            stations.Insert(0, new InspectionStation
            {
                StationId = 0,           // giá trị 0 tượng trưng “Tất cả”
                Address = "Tất cả"
            });

            cbStationAddress.ItemsSource = stations;
            cbStationAddress.DisplayMemberPath = "Address";     // hiển thị địa chỉ
            cbStationAddress.SelectedValuePath = "StationId";   // giá trị chọn
            cbStationAddress.SelectedIndex = 0;             // mặc định “Tất cả”
        }


        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            new InspectionFacilityDashboardPage().Show();
            Close();
        }

        /* ------------ Không reload khi chọn dòng ------------ */
        private void dgReports_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

       
    }
}
