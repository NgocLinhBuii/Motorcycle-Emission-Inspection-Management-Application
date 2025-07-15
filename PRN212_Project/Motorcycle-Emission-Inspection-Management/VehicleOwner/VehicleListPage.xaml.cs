using Motorcycle_Emission_Inspection_Management.BLL.Services;
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

        private void dgVehicles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillDataGrid();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
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
    }
}
