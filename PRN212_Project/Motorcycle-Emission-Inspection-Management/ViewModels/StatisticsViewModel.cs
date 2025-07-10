using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Input;

using LiveCharts;
using LiveCharts.Wpf;

using Motorcycle_Emission_Inspection_Management.BLL.DTOs;
using Motorcycle_Emission_Inspection_Management.BLL.Services;
using Motorcycle_Emission_Inspection_Management.Common;

namespace Motorcycle_Emission_Inspection_Management.ViewModels
{
    public class StatisticsViewModel : INotifyPropertyChanged
    {
        private readonly StatisticsService _service = new StatisticsService();

        public ObservableCollection<EmissionStatisticsDto> EmissionStats { get; set; } = new();
        public ObservableCollection<InspectionStationReportDto> FailureReports { get; set; } = new();

        public DateTime FromDate { get; set; } = DateTime.Now.AddMonths(-1);
        public DateTime ToDate { get; set; } = DateTime.Now;

        public ICommand LoadPassedStatsCommand => new RelayCommand(LoadPassedStats);
        public ICommand LoadFailureReportCommand => new RelayCommand(LoadFailureReport);
        public ICommand ExportPdfCommand => new RelayCommand(ExportToPdf);

        // 🔹 Dữ liệu cho biểu đồ LiveCharts
        public SeriesCollection PassedChartSeries { get; set; }
        public List<string> AreaLabels { get; set; } = new();
        public Func<double, string> YFormatter { get; set; } = value => value.ToString("N0");

        private void LoadPassedStats()
        {
            EmissionStats.Clear();
            var data = _service.GetPassedVehiclesByAreaAndTime(FromDate, ToDate);
            foreach (var item in data)
                EmissionStats.Add(item);
            OnPropertyChanged(nameof(EmissionStats));

            // Cập nhật biểu đồ
            PassedChartSeries = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Xe đạt chuẩn",
                    Values = new ChartValues<int>(data.Select(x => x.PassedVehicleCount))
                }
            };
            AreaLabels = data.Select(x => x.StationName).ToList();

            OnPropertyChanged(nameof(PassedChartSeries));
            OnPropertyChanged(nameof(AreaLabels));
            OnPropertyChanged(nameof(YFormatter));
        }

        private void LoadFailureReport()
        {
            FailureReports.Clear();
            var data = _service.GetStationFailureRates();
            foreach (var item in data)
                FailureReports.Add(item);
            OnPropertyChanged(nameof(FailureReports));
        }

        private void ExportToPdf()
        {
            try
            {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string outputPath = Path.Combine(folder, "BaoCaoThongKe_KhiThai.pdf");

                var passedData = _service.GetPassedVehiclesByAreaAndTime(FromDate, ToDate);
                var failedData = _service.GetStationFailureRates();

                Utils.PdfSharpExporter.ExportReport(passedData, failedData, outputPath);

                System.Windows.MessageBox.Show("Xuất PDF thành công ra Desktop!", "Thông báo");
                Process.Start("explorer.exe", folder);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Lỗi khi xuất PDF: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
