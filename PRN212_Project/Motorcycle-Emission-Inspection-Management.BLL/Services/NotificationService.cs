using Motorcycle_Emission_Inspection_Management.DAL;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using Motorcycle_Emission_Inspection_Management.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorcycle_Emission_Inspection_Management.BLL.Services
{
    public class NotificationService
    {
        private readonly NotificationRepository _repo = new();

        public List<Notification> GetAll() => _repo.GetAll();

        public Notification? GetById(int id) => _repo.GetById(id);

        public void Create(Notification x) => _repo.Add(x);

        public void Update(Notification x) => _repo.Update(x);

        public void Delete(Notification x) => _repo.Delete(x);

        public void MarkAsRead(int notificationId)
        {
            using var context = new EmissionInspectionContext();

            var notification = context.Notifications.Find(notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
                context.SaveChanges();
            }
        }

        public List<Notification> GetByUserId(int userId)
        {
            using var context = new EmissionInspectionContext();

            return context.Notifications
                          .Where(n => n.UserId == userId)
                          .OrderByDescending(n => n.SentDate)
                          .ToList();
        }

        
    }
}


