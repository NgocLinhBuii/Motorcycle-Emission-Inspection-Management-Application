using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Motorcycle_Emission_Inspection_Management.BLL.Services;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;

namespace Motorcycle_Emission_Inspection_Management.Police
{
    public partial class VehicleLookupPage : Page
    {
        private readonly VehicleService _vehicleService = new();
        private readonly InspectionRecordService _recordService = new();

        public VehicleLookupPage()
        {
            InitializeComponent();
        }

        /* ===== Khi bấm nút Tra cứu ===== */
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string plate = tbPlateNumber.Text.Trim();

            if (string.IsNullOrWhiteSpace(plate))
            {
                MessageBox.Show("Vui lòng nhập biển số.", "Thông báo",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            try
            {
                /* ---- Lấy thông tin xe ---- */
                Vehicle? vehicle = _vehicleService.GetByPlate(plate);
                if (vehicle != null)
                    dgVehicle.ItemsSource = new List<Vehicle> { vehicle };
                else
                {
                    dgVehicle.ItemsSource = null;
                    MessageBox.Show("Không tìm thấy phương tiện.", "Thông báo",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                /* ---- Lấy lịch sử đăng kiểm ---- */
                var history = _recordService.SearchInspectionRecords(
                                  plateNumber: plate,
                                  status: null,
                                  inspectionDate: null);

                dgHistory.ItemsSource = history;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tra cứu: {ex.Message}", "Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            new Dashboards.PoliceDashboard().Show();
        }
    }
}
