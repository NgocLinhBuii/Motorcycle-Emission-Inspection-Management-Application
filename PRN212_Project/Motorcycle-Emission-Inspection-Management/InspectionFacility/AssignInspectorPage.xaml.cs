using System;
using System.Linq;
using System.Windows;
using Motorcycle_Emission_Inspection_Management.BLL.Services;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;

namespace Motorcycle_Emission_Inspection_Management.InspectionFacility
{
    public partial class AssignInspectorPage : Window
    {
        private readonly InspectionRecordService _recordService = new();
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
            var inspectors = _userService.GetAllUser; // List<User>
            InspectorComboBox.ItemsSource = inspectors;
            InspectorComboBox.DisplayMemberPath = "FullName";
            InspectorComboBox.SelectedValuePath = "UserId";
        }

        private void LoadPlates()
        {
            var records = _recordService.GetAll()
                .Where(r => r.Vehicle != null)
                .Select(r => new
                {
                    RecordId = r.RecordId,
                    PlateNumber = r.Vehicle.PlateNumber
                })
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
                _recordService.AssignInspector(recordId, inspectorId, date);
                MessageBox.Show("Phân công thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi phân công: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e) => Close();
    }
}
