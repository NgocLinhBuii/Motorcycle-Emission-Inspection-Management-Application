using System;
using System.Globalization;
using System.Linq;                          // thêm
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using Motorcycle_Emission_Inspection_Management.BLL.Services;
using Motorcycle_Emission_Inspection_Management.Common;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using Motorcycle_Emission_Inspection_Management.Dashboards;

namespace Motorcycle_Emission_Inspection_Management.InspectionWorkers
{
    public partial class InspectionResultPage : Window
    {
        private readonly VehicleService _vehicleService = new();
        private readonly InspectionRecordService _recordService = new();
        private readonly InspectionStationService _stationService = new();

        private readonly int _inspectorId = UserSession.UserId;   // lấy 1 lần từ session
  

        public InspectionResultPage()
        {
            InitializeComponent();
            LoadPlateNumbers();
            LoadStations();
            dpInspectDate.SelectedDate = DateTime.Today;
        }

        /* ---------- Nạp biển số ---------- */
        private void LoadPlateNumbers()
        {
            var vehicles = _vehicleService.GetAll();
            cbPlateNumber.ItemsSource = vehicles;
            cbPlateNumber.DisplayMemberPath = "PlateNumber"; // hiển thị biển số
            cbPlateNumber.SelectedValuePath = "VehicleId";   // giá trị thực khi chọn
        }


        /* ---------- Nạp trạm kiểm định ---------- */
        private void LoadStations()
        {
            var list = _stationService.GetAll();
            if (list == null || !list.Any())
                MessageBox.Show("Chưa có dữ liệu trạm kiểm định trong DB!");
            cbStation.ItemsSource = list;          // Display/SelectedValuePath khai báo trong XAML
        }

        /* ---------- Thoát ---------- */
        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            new InspectorDashboard().Show();
            Close();
        }

        /* ---------- Lưu kết quả ---------- */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /* 1. VALIDATION */
            if (cbPlateNumber.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn biển số xe!",
                                "Thiếu thông tin", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (cbStation.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn trạm kiểm định!",
                                "Thiếu thông tin", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string coText = COTextBox.Text.Replace(',', '.');
            string hcText = HCTextBox.Text.Replace(',', '.');

            if (!decimal.TryParse(coText, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal co) ||
                !decimal.TryParse(hcText, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal hc))
            {
                MessageBox.Show("CO / HC phải là số!",
                                "Sai định dạng", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (ResultComboBox.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn trạng thái!",
                                "Thiếu thông tin", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            /* 2. LẤY DỮ LIỆU */
            int vehicleId = (int)cbPlateNumber.SelectedValue;
            int stationId = (int)cbStation.SelectedValue;
            DateTime inspectDate = dpInspectDate.SelectedDate ?? DateTime.Today;
            string status = ((ComboBoxItem)ResultComboBox.SelectedItem).Content.ToString();

            /* 3. TẠO & LƯU */
            var record = new InspectionRecord
            {
                VehicleId = vehicleId,
                StationId = stationId,
                InspectorId = _inspectorId,
                InspectionDate = inspectDate,
                Co2emission = co,
                Hcemission = hc,
                Result = status,
                Comments = CommentsTextBox.Text
            };

            try
            {
                _recordService.Create(record);
                MessageBox.Show("Đã lưu kết quả!",
                                "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                new InspectorDashboard().Show();
                Close();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"Không lưu được! {ex.InnerException?.Message}",
                                "DB Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
