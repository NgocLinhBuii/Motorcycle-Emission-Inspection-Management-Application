using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using Motorcycle_Emission_Inspection_Management.BLL.DTOs;
using Motorcycle_Emission_Inspection_Management.DAL;

namespace Motorcycle_Emission_Inspection_Management.BLL.Services
{
    public class StatisticsService
    {
        public List<EmissionStatisticsDto> GetPassedVehiclesByAreaAndTime(DateTime fromDate, DateTime toDate)
        {
            using var context = new EmissionInspectionContext();

            var result = context.InspectionRecords
                .Where(r => r.InspectionDate >= fromDate && r.InspectionDate <= toDate && r.Result == "Pass")
                .GroupBy(r => r.Station.Name)
                .Select(g => new EmissionStatisticsDto
                {
                    StationName = g.Key,
                    PassedVehicleCount = g.Count()
                }).ToList();

            return result;
        }

        public List<InspectionStationReportDto> GetStationFailureRates()
        {
            using var context = new EmissionInspectionContext();

            var report = context.InspectionRecords
                .GroupBy(r => r.Station.Name)
                .Select(g => new InspectionStationReportDto
                {
                    StationName = g.Key,
                    TotalInspections = g.Count(),
                    FailedInspections = g.Count(r => r.Result == "Fail")
                }).ToList();

            return report;
        }
    }
}