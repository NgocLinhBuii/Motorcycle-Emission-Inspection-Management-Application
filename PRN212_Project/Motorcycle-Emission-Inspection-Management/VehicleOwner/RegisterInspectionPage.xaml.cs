using System;
using System.Collections.Generic;
using System.Windows;
using Motorcycle_Emission_Inspection_Management.BLL.Services;
using Motorcycle_Emission_Inspection_Management.Common;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;

namespace Motorcycle_Emission_Inspection_Management.VehicleOwner
{
    public partial class RegisterInspectionPage : Window
    {
        /* ---- Services ---- */
        private readonly InspectionStationService _stationService = new();
        private readonly VehicleService _vehicleService = new();
        private readonly InspectionRecordService _recordService = new();

        public RegisterInspectionPage()
        {
            InitializeComponent();

            dpInspectionDate.SelectedDate = DateTime.Today;  // mặc định hôm nay
            LoadStations();
            LoadVehicles();
        }

        /* ===== Nạp trạm ===== */
        private void LoadStations()
        {
            List<InspectionStation> stations = _stationService.GetAll();
            cbStations.ItemsSource = stations;
            cbStations.DisplayMemberPath = "Name";
            cbStations.SelectedValuePath = "StationId";
        }

        /* ===== Nạp xe theo chủ hiện tại ===== */
        private void LoadVehicles()
        {
            int ownerId = UserSession.UserId;
            List<Vehicle> vehicles = _vehicleService.GetMyVehicles(ownerId);

            cbPlateNumbers.ItemsSource = vehicles;
            cbPlateNumbers.DisplayMemberPath = "PlateNumber";
            cbPlateNumbers.SelectedValuePath = "VehicleId";
        }

        /* ===== Đăng ký ===== */
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            /* --- Lấy & kiểm tra dữ liệu chọn --- */
            if (cbPlateNumbers.SelectedValue is not int vehicleId)
            {
                MessageBox.Show("Vui lòng chọn xe.", "Thiếu thông tin",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (cbStations.SelectedValue is not int stationId)
            {
                MessageBox.Show("Vui lòng chọn trạm kiểm định.", "Thiếu thông tin",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (dpInspectionDate.SelectedDate is not DateTime date)
            {
                MessageBox.Show("Vui lòng chọn ngày kiểm định.", "Thiếu thông tin",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (date.Date <= DateTime.Today)
            {
                MessageBox.Show("Ngày kiểm định phải sau hôm nay.",
                                "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

          

            /* --- Gọi service lưu DB --- */
            try
            {
                string result = "Fail";  // hoặc "Pass" nếu có kết quả kiểm định
                int? inspectorId = UserSession.RoleName == "Inspector" ? UserSession.UserId : null;

                _recordService.RegisterInspection(vehicleId, stationId, date, result, inspectorId);


                MessageBox.Show("Đăng ký kiểm định thành công!",
                                "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException;
                while (inner?.InnerException != null)
                    inner = inner.InnerException;

                MessageBox.Show($"Chi tiết lỗi:\n{inner?.Message ?? ex.Message}",
                                "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        /* ===== Thoát ===== */
        private void btnExit_Click(object sender, RoutedEventArgs e) => Close();
    }
}
