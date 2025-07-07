using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Motorcycle_Emission_Inspection_Management.BLL.Services;
using Motorcycle_Emission_Inspection_Management.Common;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;

// NOTE: Đổi namespace cho khớp dự án của bạn.
namespace Motorcycle_Emission_Inspection_Management
{
    /// <summary>
    /// Màn hình Cảnh sát giao thông: tra cứu & lập biên bản vi phạm.
    /// </summary>
    public partial class ViolationPage : Window
    {
        // ---------- Services ----------
        private readonly VehicleService _vehicleService = new();
        private readonly InspectionRecordService _recordService = new();
        private readonly ViolationReportService _violationService = new();

        // Kết quả tra cứu hiện thời
        private List<InspectionRecordDTO> _currentSearchResults = new();

        public ViolationPage()
        {
            InitializeComponent();
            LoadViolationTypes();
        }

        #region Load data helpers
        private void LoadViolationTypes()
        {
            cbViolationType.ItemsSource = new[]
            {
                "Quá hạn kiểm định",
                "Không đạt kiểm định",
                "Chưa đăng ký kiểm định",
                "Giả mạo kết quả kiểm định"
            };
            cbViolationType.SelectedIndex = -1;
        }
        #endregion

        #region Tra cứu
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string plate = txtPlateNumber.Text.Trim().ToUpperInvariant();
            if (string.IsNullOrEmpty(plate))
            {
                MessageBox.Show("Vui lòng nhập biển số xe.", "Cảnh báo",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var vehicle = _vehicleService.GetByPlateNumber(plate);
                if (vehicle == null)
                {
                    MessageBox.Show("Không tìm thấy phương tiện.", "Thông báo",
                                    MessageBoxButton.OK, MessageBoxImage.Information);
                    dgVehicleInfo.ItemsSource = null;
                    return;
                }

                _currentSearchResults = _recordService
                    .GetInspectionInfoForTrafficPolice(vehicle.VehicleId);

                dgVehicleInfo.ItemsSource = _currentSearchResults;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tra cứu: {ex.Message}", "Lỗi",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region Lập biên bản
        private void RecordViolation_Click(object sender, RoutedEventArgs e)
        {
            var selected = dgVehicleInfo.SelectedItem as InspectionRecordDTO;
            if (selected == null)
            {
                MessageBox.Show("Vui lòng chọn một phương tiện trong bảng.",
                                "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string? violationType = cbViolationType.SelectedItem as string;
            if (string.IsNullOrWhiteSpace(violationType))
            {
                MessageBox.Show("Vui lòng chọn loại lỗi vi phạm.",
                                "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var report = new ViolationReport
                {
                    InspectionRecordId = selected.RecordId,
                    ViolationType = violationType,
                    OfficerId = UserSession.UserId,
                    ReportedAt = DateTime.Now,
                    Note = string.Empty
                };

                _violationService.Create(report);

                MessageBox.Show("Đã lập biên bản vi phạm thành công!",
                                "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);

                cbViolationType.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể lưu biên bản: {ex.Message}", "Lỗi",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }

    // ---------------- DTO ----------------
    public class InspectionRecordDTO
    {
        public int RecordId { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public DateTime InspectionDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public double Co2Emission { get; set; }
        public string StationName { get; set; } = string.Empty;
    }
}

/* =================================================================
 *  STUBS – chỉ để mã biên dịch được ngay. Nếu đã có các lớp này
 *  trong project, hãy xóa toàn bộ phần dưới.
 * ================================================================= */
namespace Motorcycle_Emission_Inspection_Management.DAL.Entities
{
    public class ViolationReport
    {
        public int ViolationReportId { get; set; }
        public int InspectionRecordId { get; set; }
        public string ViolationType { get; set; } = string.Empty;
        public int OfficerId { get; set; }
        public DateTime ReportedAt { get; set; }
        public string? Note { get; set; }
    }
}
namespace Motorcycle_Emission_Inspection_Management.BLL.Services
{
    public class VehicleService
    {
        public object? GetByPlateNumber(string plate) => null; // TODO: thay bằng EF
    }
    public class InspectionRecordService
    {
        public List<Motorcycle_Emission_Inspection_Management.TrafficPolice.InspectionRecordDTO>
            GetInspectionInfoForTrafficPolice(int vehicleId) => new();
    }
    public class ViolationReportService
    {
        public void Create(
            Motorcycle_Emission_Inspection_Management.DAL.Entities.ViolationReport report)
        { /* TODO */ }
    }
}
