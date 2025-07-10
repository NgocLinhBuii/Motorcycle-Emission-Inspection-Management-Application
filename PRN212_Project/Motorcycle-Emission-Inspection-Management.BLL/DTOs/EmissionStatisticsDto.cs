using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorcycle_Emission_Inspection_Management.BLL.DTOs
{
    public class EmissionStatisticsDto
    {
        public string StationName { get; set; }
        public int PassedVehicleCount { get; set; }
    }

    public class InspectionStationReportDto
    {
        public string StationName { get; set; }
        public int TotalInspections { get; set; }
        public int FailedInspections { get; set; }
        public double FailedRate => TotalInspections == 0 ? 0 : (FailedInspections * 100.0 / TotalInspections);
    }
}
