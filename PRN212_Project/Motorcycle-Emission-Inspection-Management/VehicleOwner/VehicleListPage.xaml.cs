using Motorcycle_Emission_Inspection_Management.BLL.DTOs;
using Motorcycle_Emission_Inspection_Management.BLL.Services;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using Motorcycle_Emission_Inspection_Management.Dashboards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Motorcycle_Emission_Inspection_Management.VehicleOwner
{
    /// <summary>
    /// Interaction logic for VehicleListPage.xaml
    /// </summary>
    public partial class VehicleListPage : Page
    {

        public VehicleService _service = new();
        public VehicleListPage()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            dgVehicles.ItemsSource = null;
            dgVehicles.ItemsSource = _service.GetAllVehicles();
        }



        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

            // Lấy giá trị bộ lọc
            string plate = txtPlateFilter.Text.Trim();
            string model = txtModelFilter.Text.Trim();

            // Nếu cả hai đều trống → lấy toàn bộ
            var result = string.IsNullOrWhiteSpace(plate) && string.IsNullOrWhiteSpace(model)
                         ? _service.GetAllVehicles()                     // lấy toàn bộ xe
                         : _service.SearchVehicle(plate, model);  // tìm theo filter

            // Hiển thị lên DataGrid
            dgVehicles.ItemsSource = null;
            dgVehicles.ItemsSource = result;
        }
        private void dgVehicles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = dgVehicles.SelectedItem as Vehicle;
            if (selected != null)
            {
                Console.WriteLine("Đã chọn: " + selected.PlateNumber);
            }
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedVehicle = dgVehicles.SelectedItem as Vehicle; // ✅ sửa lại ở đây
            if (selectedVehicle == null)
            {
                MessageBox.Show("Vui lòng chọn một phương tiện để xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa xe có biển số: {selectedVehicle.PlateNumber}?",
                "Xác nhận xóa",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (confirm == MessageBoxResult.Yes)
            {
                bool success = _service.DeleteVehicleById(selectedVehicle.VehicleId, out string errorMsg);

                if (success)
                {
                    MessageBox.Show("Đã xóa phương tiện thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                    FillDataGrid(); // Refresh lại danh sách
                }
                else
                {
                    MessageBox.Show($"Lỗi khi xóa: {errorMsg}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }




    }
}
