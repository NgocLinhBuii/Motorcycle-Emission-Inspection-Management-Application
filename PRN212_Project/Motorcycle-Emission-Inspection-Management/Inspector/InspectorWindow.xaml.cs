using Motorcycle_Emission_Inspection_Management.BLL;
using Motorcycle_Emission_Inspection_Management.BLL.Services;
using Motorcycle_Emission_Inspection_Management.DAL;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Motorcycle_Emission_Inspection_Management.Inspector
{
    public partial class InspectorWindow : Window
    {
        private readonly VehicleService _vehicleService = new();
        private readonly InspectionRecordService _inspectionService = new();
        private readonly int _inspectorId;

        public InspectorWindow(int inspectorId)
        {
            InitializeComponent();
            _inspectorId = inspectorId;
            LoadVehicles();
        }

        private void LoadVehicles()
        {
            List<Vehicle> vehicles = _vehicleService.GetAllVehicles();
            cbVehicle.ItemsSource = vehicles;
            cbVehicle.DisplayMemberPath = "PlateNumber";
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (cbVehicle.SelectedItem is not Vehicle selectedVehicle)
            {
                txtNotify.Text = "Vui lòng chọn xe.";
                return;
            }

            if (!decimal.TryParse(txtCO2.Text, out decimal co2) ||
                !decimal.TryParse(txtHC.Text, out decimal hc))
            {
                txtNotify.Text = "CO2 hoặc HC không hợp lệ.";
                return;
            }

            string result = (cbResult.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Fail";

            var record = new InspectionRecord
            {
                VehicleId = selectedVehicle.VehicleId,
                StationId = 1, // có thể cho chọn trạm sau
                InspectorId = _inspectorId,
                InspectionDate = DateTime.Now,
                Co2emission = co2,
                Hcemission = hc,
                Result = result,
                Comments = txtComment.Text
            };

            _inspectionService.Create(record);

            txtNotify.Text = $"✅ Đã lưu kết quả cho xe {selectedVehicle.PlateNumber}.";
        }
    }
}
