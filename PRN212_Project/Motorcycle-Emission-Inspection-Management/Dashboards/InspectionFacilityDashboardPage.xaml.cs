using Motorcycle_Emission_Inspection_Management.Common;
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
    /// Interaction logic for InspectionFacilityDashboardPage.xaml
    /// </summary>
    public partial class InspectionFacilityDashboardPage : Window
    {
 
        private int _userId;

        public InspectionFacilityDashboardPage(int userId)
        {
            InitializeComponent();
            _userId = userId;
            
            // Bạn có thể lấy StationID từ UserSession nếu cần
            // hoặc gọi service tại đây nếu cần dùng _userId
        }

        // Constructor mặc định nếu bạn vẫn dùng nó ở nơi khác
        public InspectionFacilityDashboardPage()
        {
            InitializeComponent();
            MainContent.Content = new TextBlock
            {
                Text = "Chào mừng Chủ trạm!",
                FontSize = 24,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
        }


        private void ViewRequestsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new InspectionFacility.InspectionRequestListPage();
        }

        private void AssignInspectorBtn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new InspectionFacility.AssignInspectorPage();
        }

        private void FacilityReportBtn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new InspectionFacility.FacilityReportPage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new();
            login.Show();
            Close();
        }

        private void MainContent_Loaded(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new InspectionFacility.InspectionRequestListPage();
        }
    }
}
