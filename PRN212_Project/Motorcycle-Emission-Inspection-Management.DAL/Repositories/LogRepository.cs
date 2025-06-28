
using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorcycle_Emission_Inspection_Management.DAL.Repositories
{
    public class LogRepository
    {
        public List<Log> GetAll()
        {
            using var context = new EmissionInspectionContext();
            return context.Logs.ToList();
        }

        public void Add(Log x)
        {
            using var context = new EmissionInspectionContext();
            context.Logs.Add(x);
            context.SaveChanges();
        }

        public void Update(Log x)
        {
            using var context = new EmissionInspectionContext();
            context.Logs.Update(x);
            context.SaveChanges();
        }

        public void Delete(Log x)
        {
            using var context = new EmissionInspectionContext();
            context.Logs.Remove(x);
            context.SaveChanges();
        }

        public Log? GetById(int id)
        {
            using var context = new EmissionInspectionContext();
            return context.Logs.FirstOrDefault(l => l.LogId == id);
        }
    }

}
