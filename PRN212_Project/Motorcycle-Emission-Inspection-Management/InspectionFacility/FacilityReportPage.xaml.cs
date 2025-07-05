using Motorcycle_Emission_Inspection_Management.Dashboards;
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

namespace Motorcycle_Emission_Inspection_Management.InspectionFacility
{
    /// <summary>
    /// Interaction logic for FacilityReportPage.xaml
    /// </summary>
    public partial class FacilityReportPage : Window
    {
        public FacilityReportPage()
        {
            InitializeComponent();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            new InspectionFacilityDashboardPage().Show();
        }
    }
}
