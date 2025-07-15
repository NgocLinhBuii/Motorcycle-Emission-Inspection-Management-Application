
using Microsoft.EntityFrameworkCore;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorcycle_Emission_Inspection_Management.DAL.Repositories
{
    public class UserRepository
    {
        EmissionInspectionContext _context;

        public List<User> GetAll()
        {
            _context = new();
            return _context.Users.Include(u => u.Role).Include(u => u.Station).ToList();
        }

        public void Add(User x)
        {
            _context = new();
            _context.Users.Add(x);
            _context.SaveChanges();
        }

        public void Update(User x)
        {
            _context = new();
            _context.Users.Update(x);
            _context.SaveChanges();
        }

        public void Delete(User x)
        {
            _context = new();
            _context.Users.Remove(x);
            _context.SaveChanges();
        }
        public User? GetOne(string email, string password)
        {
            _context = new();
            return _context.Users.FirstOrDefault(x => x.Email.ToLower() == email.ToLower() && x.Password == password);
        }
    }
}
