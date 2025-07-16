using Microsoft.EntityFrameworkCore;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using Motorcycle_Emission_Inspection_Management.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorcycle_Emission_Inspection_Management.BLL.Services
{
    public class UserService
    {
        UserRepository _repo = new();
        public List<User> GetAllUser => _repo.GetAll();

        public User? Authenticate(string email, string password)
        {
            return _repo.GetOne(email, password);
        }
        public void CreateUser(User user) => _repo.Add(user);

        public void UpdateUser(User user) => _repo.Update(user);

        public void DeleteUser(User user) => _repo.Delete(user);

        public List<User> SearchUsers(string nameQuery, string emailQuery, string roleQuery)
        {
            // Start query to fetch users
            var query = _repo.GetAll().AsQueryable();

            if (!string.IsNullOrEmpty(nameQuery))
            {
                query = query.Where(u => u.FullName.ToLower().Contains(nameQuery.ToLower()));
            }

            if (!string.IsNullOrEmpty(emailQuery))
            {
                query = query.Where(u => u.Email.ToLower().Contains(emailQuery.ToLower()));
            }

            if (!string.IsNullOrEmpty(roleQuery))
            {
                // Ensure that Role is not null and matches the provided roleQuery
                query = query.Where(u => u.Role != null && u.Role.RoleId.ToString() == roleQuery);
            }

            // Execute the query and return the filtered users
            return query.ToList();
        }
    }
}
