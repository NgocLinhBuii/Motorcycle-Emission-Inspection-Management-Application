using Motorcycle_Emission_Inspection_Management.BLL.Services;
using Motorcycle_Emission_Inspection_Management.Common;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Motorcycle_Emission_Inspection_Management.Police
{
    public partial class ViolationRecordPage : Page
    {
        private readonly VehicleService _vehicleService = new();
        private readonly InspectionRecordService _recordService = new();
        private readonly NotificationService _notificationService = new();
        private readonly InspectionStationService _stationService = new();

        public ViolationRecordPage()
        {
            InitializeComponent();
            LoadPlateNumbers();
            LoadStations();
        }

        private void LoadPlateNumbers()
        {
            var vehicles = _vehicleService.GetAllVehicles(); // gọi đúng tên hàm
            cbPlateNumber.ItemsSource = vehicles;
            cbPlateNumber.DisplayMemberPath = "PlateNumber";
            cbPlateNumber.SelectedIndex = 0;
        }

        private void LoadStations()
        {
            var stations = _stationService.GetAll();
            cbStation.ItemsSource = stations;
            cbStation.DisplayMemberPath = "Name";
            cbStation.SelectedValuePath = "StationId";
            cbStation.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (cbPlateNumber.SelectedItem is not Vehicle vehicle)
            {
                MessageBox.Show("Vui lòng chọn phương tiện.", "Thông báo",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (cbStation.SelectedValue is not int stationId)
            {
                MessageBox.Show("Vui lòng chọn trạm kiểm định.", "Thông báo",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            DateTime date = dpDate.SelectedDate ?? DateTime.Today;
            string comment = GetViolationSummary();

            var record = new InspectionRecord
            {
                VehicleId = vehicle.VehicleId,
                StationId = stationId,
                InspectorId = UserSession.UserId,
                InspectionDate = date,
                Result = "Fail",
                Comments = comment
            };

            if (_recordService.AddSafe(record, out string msg))
            {
                var noti = new Notification
                {
                    UserId = vehicle.OwnerId,
                    Message = $"Phương tiện {vehicle.PlateNumber} đã bị ghi nhận vi phạm: {comment}",
                    SentDate = DateTime.Now,
                    IsRead = false
                };
                _notificationService.Create(noti);

                MessageBox.Show("Đã ghi nhận vi phạm và gửi thông báo.",
                                "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"Không lưu được: {msg}",
                                "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string GetViolationSummary()
        {
            List<string> violations = new();

            if (chkEmission.IsChecked == true)
                violations.Add("Khí thải vượt mức");
            if (chkExpired.IsChecked == true)
                violations.Add("Quá hạn đăng kiểm");
            if (chkNoPapers.IsChecked == true)
                violations.Add("Không mang giấy tờ xe");
            if (chkOther.IsChecked == true && !string.IsNullOrWhiteSpace(tbOther.Text))
                violations.Add(tbOther.Text.Trim());

            return string.Join(", ", violations);
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
        }

        private void chkOther_Checked(object sender, RoutedEventArgs e)
        {
            tbOther.Visibility = Visibility.Visible;
        }

        private void chkOther_Unchecked(object sender, RoutedEventArgs e)
        {
            tbOther.Visibility = Visibility.Collapsed;
        }
    }
}
