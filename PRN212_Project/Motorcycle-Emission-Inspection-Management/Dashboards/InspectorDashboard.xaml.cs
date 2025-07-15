using Motorcycle_Emission_Inspection_Management.DAL.Entities;
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
using Motorcycle_Emission_Inspection_Management.Common;   // chứa UserSession

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
            MainContent.Content = new TextBlock
            {
                Text = "Chào mừng Nhân viên kiểm định!",
                FontSize = 24,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
        }

        private void ViewAssignedBtn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new AssignedInspectionsPage();
        }

        private void EnterResultsBtn_Click(object sender, RoutedEventArgs e)
        {

            MainContent.Content = new InspectionWorkers.InspectionResultPage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new();
            login.Show();
            Close();
        }

        private void MainContent_Loaded(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new AssignedInspectionsPage();
        }
    }
}
