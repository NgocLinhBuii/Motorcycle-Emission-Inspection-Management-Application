using Motorcycle_Emission_Inspection_Management.BLL.Services;
using Motorcycle_Emission_Inspection_Management.Common;
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

namespace Motorcycle_Emission_Inspection_Management.VehicleOwner
{
    /// <summary>
    /// Interaction logic for InspectionHistoryPage.xaml
    /// </summary>
    public partial class InspectionHistoryPage : Window
    {
        private readonly InspectionRecordService _recordService = new();

        public InspectionHistoryPage()
        {
            InitializeComponent();
            LoadInspectionHistory();
        }

        private void LoadInspectionHistory()
        {
            int ownerId = UserSession.UserId;
            var records = _recordService.GetByOwnerId(ownerId);
            dgInspectionHistory.ItemsSource = records;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

}
