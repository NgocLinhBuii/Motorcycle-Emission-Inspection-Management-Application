using Motorcycle_Emission_Inspection_Management.BLL.Services;
using Motorcycle_Emission_Inspection_Management.Common;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using System;
using System.Windows;

namespace Motorcycle_Emission_Inspection_Management.VehicleOwner
{
    public partial class AddVehiclePage : Window
    {
        private readonly VehicleService _vehicleService = new();

        public AddVehiclePage()
        {
            InitializeComponent();
        }

   
        private void btnCancel_Click(object sender, RoutedEventArgs e) => Close();

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var vehicle = new Vehicle
            {
                PlateNumber = tbPlate.Text,
                Brand = tbBrand.Text,
                Model = tbModel.Text,
                ManufactureYear = int.Parse(tbYear.Text),
                EngineNumber = tbEngine.Text,
                OwnerId = UserSession.UserId
            };

            var service = new VehicleService();
            await service.AddVehicleAsync(vehicle);

            MessageBox.Show("Thêm xe thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // 1. Đọc & kiểm tra dữ liệu
            string plate = tbPlate.Text.Trim();
            string brand = tbBrand.Text.Trim();
            string model = tbModel.Text.Trim();
            string yearStr = tbYear.Text.Trim();
            string engine = tbEngine.Text.Trim();

            if (string.IsNullOrWhiteSpace(plate) ||
                string.IsNullOrWhiteSpace(brand) ||
                string.IsNullOrWhiteSpace(model) ||
                string.IsNullOrWhiteSpace(yearStr))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường bắt buộc (Biển số, Hãng, Dòng xe, Năm SX).",
                                "Thiếu thông tin", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(yearStr, out int year) ||
                year < 1950 || year > DateTime.Now.Year)
            {
                MessageBox.Show("Năm sản xuất không hợp lệ.",
                                "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // 2. Tạo entity
            var vehicle = new Vehicle
            {
                PlateNumber = plate,
                Brand = brand,
                Model = model,
                ManufactureYear = year,
                EngineNumber = engine,
                OwnerId = UserSession.Current.UserId   // ID chủ xe đang đăng nhập
            };

            try
            {
                await _vehicleService.AddVehicleAsync(vehicle);
                MessageBox.Show("Đã thêm xe thành công!",
                                "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}",
                                "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
