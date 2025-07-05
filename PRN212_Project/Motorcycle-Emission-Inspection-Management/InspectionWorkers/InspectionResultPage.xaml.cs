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
using Motorcycle_Emission_Inspection_Management.Dashboards;
namespace Motorcycle_Emission_Inspection_Management.InspectionWorkers
{
    /// <summary>
    /// Interaction logic for InspectionResultPage.xaml
    /// </summary>
    public partial class InspectionResultPage : Window
    {
        public InspectionResultPage()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            new InspectorDashboard().Show();
        }
    }
}
