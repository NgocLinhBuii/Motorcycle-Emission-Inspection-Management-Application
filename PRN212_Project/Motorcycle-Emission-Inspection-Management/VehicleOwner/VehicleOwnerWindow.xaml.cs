using Motorcycle_Emission_Inspection_Management.BLL;
using Motorcycle_Emission_Inspection_Management.BLL.Services;
using Motorcycle_Emission_Inspection_Management.DAL;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Motorcycle_Emission_Inspection_Management.VehicleOwner
{
    public partial class VehicleOwnerWindow : Window
    {
        private readonly VehicleService _vehicleService = new();
        private readonly InspectionRecordService _inspectionService = new();
        private readonly int _userId;

        public VehicleOwnerWindow(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadMyVehicles();
        }

        private void LoadMyVehicles()
        {
            var list = _vehicleService.GetAllVehicles()
                .Where(v => v.OwnerId == _userId)
                .ToList();

            lstVehicles.ItemsSource = list;
            lstVehicles.DisplayMemberPath = "PlateNumber";
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (lstVehicles.SelectedItem is not Vehicle selected)
            {
                txtStatus.Text = "Vui lòng chọn một xe để đăng ký.";
                return;
            }

            // Tạo bản ghi kiểm định với trạng thái Pending (coi như đăng ký trước)
            var record = new InspectionRecord
            {
                VehicleId = selected.VehicleId,
                StationId = 1, // Có thể cho người dùng chọn
                InspectorId = 2, // Chưa kiểm định
                Co2emission = 0,
                Hcemission = 0,
                Result = "Fail",
                Comments = "Chờ kiểm định",
                InspectionDate = DateTime.Now.AddDays(1) // lịch hẹn tạm thời
            };

            _inspectionService.Create(record);
            txtStatus.Text = $"✅ Xe {selected.PlateNumber} đã đăng ký kiểm định.";
        }

        private void BtnHistory_Click(object sender, RoutedEventArgs e)
        {
            if (lstVehicles.SelectedItem is not Vehicle selected)
            {
                MessageBox.Show("Vui lòng chọn một xe để xem lịch sử.");
                return;
            }

            var records = _inspectionService.GetAll()
                .Where(r => r.VehicleId == selected.VehicleId && r.Result != "Pending")
                .OrderByDescending(r => r.InspectionDate)
                .Select(r => $"Ngày: {r.InspectionDate:dd/MM/yyyy} - KQ: {r.Result} - CO2: {r.Co2emission} - HC: {r.Hcemission}")
                .ToList();

            if (records.Count == 0)
                MessageBox.Show("Chưa có lịch sử kiểm định.");
            else
                MessageBox.Show(string.Join("\n", records), "Lịch sử kiểm định");
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
