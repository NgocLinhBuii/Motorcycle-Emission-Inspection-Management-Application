using Motorcycle_Emission_Inspection_Management.BLL.Services;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Motorcycle_Emission_Inspection_Management
{
    public partial class VehicleManagementPage : Page
    {
        private readonly VehicleService _vehicleService;

        public VehicleManagementPage()
        {
            InitializeComponent();
            _vehicleService = new VehicleService(); // Khởi tạo service
            LoadVehicleData();
        }

        // Hàm để tải dữ liệu xe vào DataGrid
        private void LoadVehicleData()
        {
            // Lấy danh sách xe từ VehicleService
            List<Vehicle> vehicles = _vehicleService.GetAllVehicles();

            // Gán dữ liệu cho DataGrid
            VehicleDataGrid.ItemsSource = vehicles;
        }

        // Sự kiện khi nhấn nút "Thêm"
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Mở cửa sổ hoặc dialog để thêm xe mới
            MessageBox.Show("Chức năng thêm xe sẽ được triển khai!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Sự kiện khi nhấn nút "Sửa"
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (VehicleDataGrid.SelectedItem != null)
            {
                Vehicle selectedVehicle = VehicleDataGrid.SelectedItem as Vehicle;

                // Mở cửa sổ hoặc dialog để sửa thông tin của xe được chọn
                MessageBox.Show($"Chỉnh sửa xe {selectedVehicle.PlateNumber}", "Sửa xe", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn xe để sửa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Sự kiện khi nhấn nút "Xóa"
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (VehicleDataGrid.SelectedItem != null)
            {
                Vehicle selectedVehicle = VehicleDataGrid.SelectedItem as Vehicle;

                // Xác nhận xóa
                var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa xe {selectedVehicle.PlateNumber}?", "Xóa xe", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    // Gọi phương thức xóa xe từ VehicleService
                    _vehicleService.DeleteVehicle(selectedVehicle);

                    // Tải lại danh sách xe sau khi xóa
                    LoadVehicleData();

                    MessageBox.Show($"Đã xóa xe {selectedVehicle.PlateNumber}", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn xe để xóa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
