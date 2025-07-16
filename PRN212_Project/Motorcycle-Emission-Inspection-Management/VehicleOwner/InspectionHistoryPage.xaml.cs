using Motorcycle_Emission_Inspection_Management.BLL.Services;
using Motorcycle_Emission_Inspection_Management.Common;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;
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
    public partial class InspectionHistoryPage : Page
    {
        private readonly InspectionRecordService _recordService = new();

        public InspectionHistoryPage()
        {
            InitializeComponent();
            LoadInspectionHistory();
        }


        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
        }
        private void LoadInspectionHistory()
        {
            int ownerId = UserSession.UserId;
            var records = _recordService.GetByOwnerId(ownerId);

            // Lưu toàn bộ danh sách để lọc
            _allRecords = (List<InspectionRecord>)records;

            dgInspectionHistory.ItemsSource = _allRecords;

            // Load Station vào ComboBox
            cbStationFilter.ItemsSource = _recordService.GetAll();
            cbStationFilter.DisplayMemberPath = "Name";
            cbStationFilter.SelectedValuePath = "StationId";
            cbStationFilter.SelectedIndex = -1;
        }

        // Danh sách lưu lại để lọc
        private List<InspectionRecord> _allRecords = new();

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var filtered = _allRecords.AsEnumerable(); // _allRecords đã được Load từ DB trước đó

            // Lọc theo Station nếu có chọn
            if (cbStationFilter.SelectedValue is int selectedStationId)
            {
                filtered = filtered.Where(r => r.StationId == selectedStationId);
            }

            // Lọc theo ngày nếu có chọn
            if (dpDateFilter.SelectedDate.HasValue)
            {
                DateTime selectedDate = dpDateFilter.SelectedDate.Value.Date;
                filtered = filtered.Where(r => r.InspectionDate!.Value.Date == selectedDate);
            }

            // Cập nhật DataGrid
            dgInspectionHistory.ItemsSource = filtered.ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedRecord = dgInspectionHistory.SelectedItem as InspectionRecord;
            if (selectedRecord == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng kiểm định để xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa kiểm định ngày {selectedRecord.InspectionDate:dd/MM/yyyy} của xe {selectedRecord.Vehicle?.PlateNumber}?",
                "Xác nhận xóa",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (confirm == MessageBoxResult.Yes)
            {
                try
                {
                    _recordService.Delete(selectedRecord);  // gọi Service
                    MessageBox.Show("Đã xóa kiểm định thành công.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadInspectionHistory(); // refresh lại
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa kiểm định: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

    }

}

