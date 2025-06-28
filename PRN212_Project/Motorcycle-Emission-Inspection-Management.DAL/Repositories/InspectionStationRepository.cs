
using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorcycle_Emission_Inspection_Management.DAL.Repositories
{
    public class InspectionStationRepository
    {
        public List<InspectionStation> GetAll()
        {
            using var context = new EmissionInspectionContext();
            return context.InspectionStations.ToList();
        }

        public void Add(InspectionStation x)
        {
            using var context = new EmissionInspectionContext();
            context.InspectionStations.Add(x);
            context.SaveChanges();
        }

        public void Update(InspectionStation x)
        {
            using var context = new EmissionInspectionContext();
            context.InspectionStations.Update(x);
            context.SaveChanges();
        }

        public void Delete(InspectionStation x)
        {
            using var context = new EmissionInspectionContext();
            context.InspectionStations.Remove(x);
            context.SaveChanges();
        }

        public InspectionStation? GetById(int id)
        {
            using var context = new EmissionInspectionContext();
            return context.InspectionStations.FirstOrDefault(s => s.StationId == id);
        }
    }

}
