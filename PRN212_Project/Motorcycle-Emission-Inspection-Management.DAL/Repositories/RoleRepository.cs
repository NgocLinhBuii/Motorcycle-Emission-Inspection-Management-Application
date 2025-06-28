using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorcycle_Emission_Inspection_Management.DAL.Repositories
{
    public class RoleRepository
    {
        EmissionInspectionContext _context;

        public List<Role> GetAll()
        {
            _context = new();
            return _context.Roles.ToList();
        }

        public Role? GetById(int id)
        {
            return _context.Roles.FirstOrDefault(r => r.RoleId == id);
        }

        public Role? GetByName(string name)
        {
            return _context.Roles.FirstOrDefault(r => r.RoleName == name);
        }
    }
}
