
using Microsoft.EntityFrameworkCore;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorcycle_Emission_Inspection_Management.DAL.Repositories
{
    public class InspectionRecordRepository
    {
        public List<InspectionRecord> GetAll()
        {
            using var context = new EmissionInspectionContext();
            return context.InspectionRecords.Include("Vehicle").ToList();
        }

        public void Add(InspectionRecord x)
        {
            using var context = new EmissionInspectionContext();
            context.InspectionRecords.Add(x);
            context.SaveChanges();
        }

        public void Update(InspectionRecord x)
        {
            using var context = new EmissionInspectionContext();
            context.InspectionRecords.Update(x);
            context.SaveChanges();
        }

        public void Delete(InspectionRecord x)
        {
            using var context = new EmissionInspectionContext();
            context.InspectionRecords.Remove(x);
            context.SaveChanges();
        }

        public InspectionRecord? GetById(int id)
        {
            using var context = new EmissionInspectionContext();
            return context.InspectionRecords.FirstOrDefault(i => i.RecordId == id);
        }
    }

}
