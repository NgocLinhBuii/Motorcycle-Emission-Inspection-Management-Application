using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using Motorcycle_Emission_Inspection_Management.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorcycle_Emission_Inspection_Management.BLL.Services
{
    public class VehicleService
    {
        private readonly VehicleRepository _repo = new();

        public List<Vehicle> GetAllVehicles() => _repo.GetAll();

        public Vehicle? GetVehicle(int id) => _repo.GetById(id);

        public void CreateVehicle(Vehicle x) => _repo.Add(x);

        public void UpdateVehicle(Vehicle x) => _repo.Update(x);

        public void DeleteVehicle(Vehicle x) => _repo.Delete(x);
    }

}
