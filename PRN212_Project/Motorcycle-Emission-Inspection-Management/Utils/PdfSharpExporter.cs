using System.Collections.Generic;
using System.IO;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using Motorcycle_Emission_Inspection_Management.BLL.DTOs;

namespace Motorcycle_Emission_Inspection_Management.Utils
{
    public static class PdfSharpExporter
    {
        public static void ExportReport(List<EmissionStatisticsDto> passedStats, List<InspectionStationReportDto> failureStats, string outputPath)
        {
            var doc = new Document();
            var section = doc.AddSection();
            section.PageSetup.Orientation = Orientation.Landscape;

            // Tiêu đề chính
            var title = section.AddParagraph("BÁO CÁO THỐNG KÊ KHÍ THẢI XE MÁY");
            title.Format.Font.Size = 16;
            title.Format.Font.Bold = true;
            title.Format.SpaceAfter = "0.5cm";

            // 1. Thống kê đạt chuẩn
            var sub1 = section.AddParagraph("1. Thống kê xe đạt tiêu chuẩn khí thải");
            sub1.Format.Font.Bold = true;
            sub1.Format.SpaceAfter = "0.3cm";

            var table1 = section.AddTable();
            table1.Borders.Width = 0.75;
            table1.AddColumn(Unit.FromCentimeter(10));
            table1.AddColumn(Unit.FromCentimeter(5));

            var headerRow1 = table1.AddRow();
            headerRow1.Shading.Color = Colors.LightGray;
            headerRow1.Cells[0].AddParagraph("Khu vực");
            headerRow1.Cells[1].AddParagraph("Số xe đạt chuẩn");

            foreach (var stat in passedStats)
            {
                var row = table1.AddRow();
                row.Cells[0].AddParagraph(stat.StationName);
                row.Cells[1].AddParagraph(stat.PassedVehicleCount.ToString());
            }

            section.AddParagraph("\n");

            // 2. Thống kê không đạt
            var sub2 = section.AddParagraph("2. Báo cáo cơ sở và tỉ lệ xe không đạt");
            sub2.Format.Font.Bold = true;
            sub2.Format.SpaceAfter = "0.3cm";

            var table2 = section.AddTable();
            table2.Borders.Width = 0.75;
            table2.AddColumn(Unit.FromCentimeter(8));
            table2.AddColumn(Unit.FromCentimeter(4));
            table2.AddColumn(Unit.FromCentimeter(4));
            table2.AddColumn(Unit.FromCentimeter(4));

            var headerRow2 = table2.AddRow();
            headerRow2.Shading.Color = Colors.LightGray;
            headerRow2.Cells[0].AddParagraph("Tên cơ sở");
            headerRow2.Cells[1].AddParagraph("Tổng lượt");
            headerRow2.Cells[2].AddParagraph("Không đạt");
            headerRow2.Cells[3].AddParagraph("Tỉ lệ (%)");

            foreach (var stat in failureStats)
            {
                var row = table2.AddRow();
                row.Cells[0].AddParagraph(stat.StationName);
                row.Cells[1].AddParagraph(stat.TotalInspections.ToString());
                row.Cells[2].AddParagraph(stat.FailedInspections.ToString());
                row.Cells[3].AddParagraph(stat.FailedRate.ToString("F2"));
            }

            // Xuất file PDF
            var renderer = new PdfDocumentRenderer(true); // true: embed font
            renderer.Document = doc;
            renderer.RenderDocument();
            renderer.Save(outputPath);
        }
    }
}
