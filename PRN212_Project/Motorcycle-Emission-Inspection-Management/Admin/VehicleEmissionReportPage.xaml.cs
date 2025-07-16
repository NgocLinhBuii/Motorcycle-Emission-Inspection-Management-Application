using Motorcycle_Emission_Inspection_Management.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Motorcycle_Emission_Inspection_Management.Admin
{
    /// <summary>
    /// Interaction logic for VehicleEmissionReportPage.xaml
    /// </summary>
    public partial class VehicleEmissionReportPage : Page
    {
        private readonly InspectionRecordService _inspectionRecordService;
        public VehicleEmissionReportPage()
        {
            InitializeComponent();
            _inspectionRecordService = new InspectionRecordService(); // Khởi tạo service
            LoadEmissionReportData();
        }
        private void LoadEmissionReportData()
        {
            // Lấy danh sách bản ghi kiểm tra đạt tiêu chuẩn khí thải từ InspectionRecordService
            var emissionRecords = _inspectionRecordService.GetRequests(null, null, "Pass");

            // Chuyển dữ liệu từ InspectionRecordDto sang dữ liệu phù hợp cho DataGrid
            var emissionReport = emissionRecords.Select(ir => new
            {
                ir.PlateNumber,
                ir.Brand,
                ir.Model,
                InspectionDate = ir.InspectionDate.ToString("dd/MM/yyyy"),
                ir.StationName,
                ir.Result
            }).ToList();

            // Gán dữ liệu cho DataGrid
            VehicleEmissionDataGrid.ItemsSource = emissionReport;
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string plateNumber = PlateNumberSearchTextBox.Text.Trim();
            DateTime? fromDate = FromDatePicker.SelectedDate;
            DateTime? toDate = ToDatePicker.SelectedDate;
            string stationName = StationSearchTextBox.Text.Trim();

            // Call the service method to get the filtered results
            var filteredInspectionRecords = _inspectionRecordService.SearchInspectionRecords(plateNumber, fromDate, toDate, stationName);

            // Check if any records were found
            if (filteredInspectionRecords != null && filteredInspectionRecords.Any())
            {
                // Bind the filtered results to the DataGrid or UI elements
                VehicleEmissionDataGrid.ItemsSource = filteredInspectionRecords;
            }
            else
            {
                MessageBox.Show("No records found.");
                VehicleEmissionDataGrid.ItemsSource = null;  // Clear DataGrid if no records found
            }
        }

    }
}
