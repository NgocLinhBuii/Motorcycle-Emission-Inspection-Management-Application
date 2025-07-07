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

       
    }
}
