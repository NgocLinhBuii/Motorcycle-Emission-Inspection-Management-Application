using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using Motorcycle_Emission_Inspection_Management.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorcycle_Emission_Inspection_Management.BLL.Services
{
    public class RoleService
    {
        private readonly RoleRepository _repository = new();

        public List<Role> GetAllRoles()
        {
            return _repository.GetAll();
        }

        public Role? GetRoleById(int id)
        {
            return _repository.GetById(id);
        }

        public Role? GetRoleByName(string name)
        {
            return _repository.GetByName(name);
        }
    }
}
