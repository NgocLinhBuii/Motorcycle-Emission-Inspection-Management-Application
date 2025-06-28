using Motorcycle_Emission_Inspection_Management.BLL;
using Motorcycle_Emission_Inspection_Management.BLL.Services;
using Motorcycle_Emission_Inspection_Management.DAL;
using System;
using System.Linq;
using System.Windows;

namespace Motorcycle_Emission_Inspection_Management.EmissionTestingFacility
{
    public partial class StationWindow : Window
    {
        private readonly VehicleService _vehicleService = new();
        private readonly UserService _userService = new();
        private readonly InspectionRecordService _inspectionRecordService = new();

        private readonly int _stationId = 1; // Giả định trạm ID cố định

        public StationWindow()
        {
            InitializeComponent();
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            var allRecords = _inspectionRecordService.GetAll();
            var allVehicles = _vehicleService.GetAllVehicles();
            var allUsers = _userService.GetAllUser;

            // Lấy danh sách xe đã được kiểm định tại trạm hiện tại
            var data = allRecords
                .Where(r => r.StationId == _stationId)
                .Select(r => new
                {
                    r.InspectionDate,
                    r.Result,
                    PlateNumber = allVehicles.FirstOrDefault(v => v.VehicleId == r.VehicleId)?.PlateNumber ?? "N/A",
                    OwnerName = allUsers.FirstOrDefault(u => u.UserId == allVehicles.FirstOrDefault(v => v.VehicleId == r.VehicleId)?.OwnerId)?.FullName ?? "N/A"
                }).ToList();

            lstAppointments.ItemsSource = data;
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadAppointments();
        }
    }
}
