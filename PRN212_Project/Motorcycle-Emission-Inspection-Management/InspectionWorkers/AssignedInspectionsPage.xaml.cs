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
using System.Windows.Shapes;
using Motorcycle_Emission_Inspection_Management.BLL.Services;
using Motorcycle_Emission_Inspection_Management.Dashboards;
namespace Motorcycle_Emission_Inspection_Management.InspectionFacility
{
    /// <summary>
    /// Interaction logic for AssignedInspectionsPage.xaml
    /// </summary>
    public partial class AssignedInspectionsPage : Window     
    {
        public InspectionRecordService _service = new();
        public AssignedInspectionsPage()
        {
            InitializeComponent();             
            FillDataGrid();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            new InspectorDashboard().Show();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            AssignedInspectionDataGrid.ItemsSource = null;
            AssignedInspectionDataGrid.ItemsSource = _service.GetAll();
        }

     


        private void txtPlateNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtPlateNumber.Text == "Biển số")
            {
                txtPlateNumber.Text = "";
                txtPlateNumber.Foreground = Brushes.Black;
            }
        }

        private void txtPlateNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlateNumber.Text))
            {
                txtPlateNumber.Text = "Biển số";
                txtPlateNumber.Foreground = Brushes.Gray;
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string? plate = txtPlateNumber.Text?.Trim();
            if (string.IsNullOrEmpty(plate) || plate.Equals("Biển số", StringComparison.OrdinalIgnoreCase))
                plate = null;                                    

            /* ----------- 2. TRẠNG THÁI ----------- */
            string? status = (cbStatus.SelectedItem as ComboBoxItem)?.Content?.ToString();
            if (string.IsNullOrWhiteSpace(status) || status.Equals("Tất cả", StringComparison.OrdinalIgnoreCase))
                status = null;                                   

            /* ----------- 3. NGÀY KIỂM ĐỊNH ----------- */
            DateTime? inspDate = dpDate.SelectedDate;           

            /* ----------- 4. LẤY DỮ LIỆU ----------- */
            var result = (plate == null && status == null && !inspDate.HasValue)
                         ? _service.GetAll()
                         : _service.SearchInspectionRecords(plate, status, inspDate);

            AssignedInspectionDataGrid.ItemsSource = null;
            AssignedInspectionDataGrid.ItemsSource = result;
        }
    }
}
