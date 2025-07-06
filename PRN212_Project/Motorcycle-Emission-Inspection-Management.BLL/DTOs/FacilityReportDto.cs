using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorcycle_Emission_Inspection_Management.BLL.DTOs
{
    public class FacilityReportDto
    {
        public DateTime InspectionDate { get; set; }
        public string StationAddress { get; set; }
        public string StationName { get; set; }
        public string Phone { get; set; }
        public int PassedCount { get; set; }
        public int FailedCount { get; set; }
    }
}
