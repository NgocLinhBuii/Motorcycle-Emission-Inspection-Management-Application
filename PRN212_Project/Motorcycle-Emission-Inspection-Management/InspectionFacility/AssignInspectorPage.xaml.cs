using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Motorcycle_Emission_Inspection_Management.BLL.Services;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;

namespace Motorcycle_Emission_Inspection_Management.InspectionFacility
{
    public partial class AssignInspectorPage : Page
    {
        private readonly InspectionRecordService _rese = new();

        private readonly UserService _userService = new();

        public AssignInspectorPage()
        {
            InitializeComponent();
            InspectDatePicker.SelectedDate = DateTime.Today;
            LoadInspectors();
            LoadPlates();
        }

        private void LoadInspectors()
        {
            var inspectors = _userService.GetAllUser.Where(x => x.RoleId == 3); // List<User>
            InspectorComboBox.ItemsSource = inspectors;
            InspectorComboBox.DisplayMemberPath = "FullName";
            InspectorComboBox.SelectedValuePath = "UserId";
        }

        private void LoadPlates()
        {
            var records = new Motorcycle_Emission_Inspection_Management.BLL.Services.InspectionRecordService()
                               .GetAll()
                               .Where(r => r.Vehicle != null)
                               .Select(r => new { r.RecordId, PlateNumber = r.Vehicle.PlateNumber })
                               .Distinct()
                               .ToList();

            PlateComboBox.ItemsSource = records;
            PlateComboBox.DisplayMemberPath = "PlateNumber";
            PlateComboBox.SelectedValuePath = "RecordId";
        }



        private void AssignButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlateComboBox.SelectedValue is not int recordId)
            {
                MessageBox.Show("Vui lòng chọn biển số!", "Thiếu thông tin",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (InspectorComboBox.SelectedValue is not int inspectorId)
            {
                MessageBox.Show("Vui lòng chọn công nhân!", "Thiếu thông tin",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!InspectDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Vui lòng chọn ngày kiểm định!", "Thiếu thông tin",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DateTime date = InspectDatePicker.SelectedDate.Value;

            try
            {
                _rese.AssignInspector(recordId, inspectorId, date);
                MessageBox.Show("Phân công thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi phân công: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {

        }

    
    }
}
