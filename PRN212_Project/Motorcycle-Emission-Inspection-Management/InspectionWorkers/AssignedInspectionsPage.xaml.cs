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
    }
}
