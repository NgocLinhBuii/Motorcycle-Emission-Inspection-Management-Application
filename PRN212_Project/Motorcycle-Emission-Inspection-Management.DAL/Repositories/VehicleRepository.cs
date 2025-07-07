using Microsoft.EntityFrameworkCore;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorcycle_Emission_Inspection_Management.DAL.Repositories
{
    public class VehicleRepository
    {
        public List<Vehicle> GetAll()
        {
            using var context = new EmissionInspectionContext();
            return context.Vehicles.ToList();
        }

        public void Add(Vehicle x)
        {
            using var context = new EmissionInspectionContext();
            context.Vehicles.Add(x);
            context.SaveChanges();
        }

        public void Update(Vehicle x)
        {
            using var context = new EmissionInspectionContext();
            context.Vehicles.Update(x);
            context.SaveChanges();
        }

        public void Delete(Vehicle x)
        {
            using var context = new EmissionInspectionContext();
            context.Vehicles.Remove(x);
            context.SaveChanges();
        }

        public Vehicle? GetById(int id)
        {
            using var context = new EmissionInspectionContext();
            return context.Vehicles.FirstOrDefault(v => v.VehicleId == id);
        }
    }

}
