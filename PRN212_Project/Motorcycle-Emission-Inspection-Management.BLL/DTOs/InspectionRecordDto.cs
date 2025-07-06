using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorcycle_Emission_Inspection_Management.BLL.DTOs
{
    public  class InspectionRecordDto
    {
        public string PlateNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime InspectionDate { get; set; }
        public string Result { get; set; }
        public string StationName { get; set; }
    }
}
