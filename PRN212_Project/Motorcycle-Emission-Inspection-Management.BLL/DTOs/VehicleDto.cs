using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorcycle_Emission_Inspection_Management.BLL.DTOs
{
    public class VehicleDto
    {
        public int VehicleId { get; set; }
        public string PlateNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ManufactureYear { get; set; }
        public string Status { get; set; }
    }
}
