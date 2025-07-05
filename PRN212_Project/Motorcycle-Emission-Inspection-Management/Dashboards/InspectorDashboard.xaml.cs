using Motorcycle_Emission_Inspection_Management.InspectionFacility;
using Motorcycle_Emission_Inspection_Management.InspectionWorkers;
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

namespace Motorcycle_Emission_Inspection_Management.Dashboards
{
    /// <summary>
    /// Interaction logic for InspectorDashboard.xaml
    /// </summary>
    public partial class InspectorDashboard : Window
    {
        public InspectorDashboard()
        {
            InitializeComponent();
        }

        private void ViewAssignedBtn_Click(object sender, RoutedEventArgs e)
        {
            new AssignedInspectionsPage().Show();
        }

        private void EnterResultsBtn_Click(object sender, RoutedEventArgs e)
        {
            new InspectionResultPage().Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
        }
    }
}
