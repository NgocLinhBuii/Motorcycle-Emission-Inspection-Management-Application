
using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorcycle_Emission_Inspection_Management.DAL.Repositories
{
    public class NotificationRepository
    {
        public List<Notification> GetAll()
        {
            using var context = new EmissionInspectionContext();
            return context.Notifications.ToList();
        }

        public void Add(Notification x)
        {
            using var context = new EmissionInspectionContext();
            context.Notifications.Add(x);
            context.SaveChanges();
        }

        public void Update(Notification x)
        {
            using var context = new EmissionInspectionContext();
            context.Notifications.Update(x);
            context.SaveChanges();
        }

        public void Delete(Notification x)
        {
            using var context = new EmissionInspectionContext();
            context.Notifications.Remove(x);
            context.SaveChanges();
        }

        public Notification? GetById(int id)
        {
            using var context = new EmissionInspectionContext();
            return context.Notifications.FirstOrDefault(n => n.NotificationId == id);
        }
    }

}
