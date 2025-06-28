using Motorcycle_Emission_Inspection_Management.BLL;
using Motorcycle_Emission_Inspection_Management.BLL.Services;
using System;
using System.Linq;
using System.Windows;

namespace Motorcycle_Emission_Inspection_Management.Police
{
    public partial class PoliceWindow : Window
    {
        private readonly InspectionRecordService _inspectionService = new();
        private readonly VehicleService _vehicleService = new();

        public PoliceWindow()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string plate = txtPlate.Text.Trim();

            if (string.IsNullOrEmpty(plate))
            {
                MessageBox.Show("Vui lòng nhập biển số xe.");
                return;
            }

            // Tìm VehicleID từ biển số
            var vehicle = _vehicleService.GetAllVehicles()
                .FirstOrDefault(v => v.PlateNumber.Equals(plate, StringComparison.OrdinalIgnoreCase));

            if (vehicle == null)
            {
                MessageBox.Show("Không tìm thấy xe với biển số này.");
                return;
            }

            // Tìm các bản ghi đăng kiểm theo VehicleID
            var records = _inspectionService.GetAll()
                .Where(r => r.VehicleId == vehicle.VehicleId)
                .OrderByDescending(r => r.InspectionDate)
                .Select(r => $"Ngày: {r.InspectionDate:dd/MM/yyyy} - KQ: {r.Result} - CO2: {r.Co2emission} - HC: {r.Hcemission}")
                .ToList();

            lstResults.ItemsSource = records;
        }
    }
}
