using Microsoft.IdentityModel.Tokens;
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
    public class VehicleService
    {
        private readonly VehicleRepository _repo = new();

        public List<Vehicle> GetAllVehicles() => _repo.GetAll();

        public Vehicle? GetByPlate(string plateNumber)
        {
            using var context = new EmissionInspectionContext();

            return context.Vehicles
                          .FirstOrDefault(v => v.PlateNumber == plateNumber);
        }
        public Vehicle? GetVehicle(int id) => _repo.GetById(id);

        public void CreateVehicle(Vehicle x) => _repo.Add(x);

        public void UpdateVehicle(Vehicle x) => _repo.Update(x);

        public void DeleteVehicle(Vehicle x) => _repo.Delete(x);
        public bool DeleteVehicleById(int vehicleId, out string errorMsg)
        {
            errorMsg = string.Empty;

            try
            {
                using var ctx = new EmissionInspectionContext();

                var vehicle = ctx.Vehicles.FirstOrDefault(v => v.VehicleId == vehicleId);
                if (vehicle == null)
                {
                    errorMsg = "Không tìm thấy phương tiện.";
                    return false;
                }

                // Xóa toàn bộ bản ghi kiểm định liên quan
                var inspections = ctx.InspectionRecords
                                     .Where(r => r.VehicleId == vehicleId)
                                     .ToList();

                ctx.InspectionRecords.RemoveRange(inspections);

                // Sau đó xóa xe
                ctx.Vehicles.Remove(vehicle);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                errorMsg = "Lỗi khi xóa: " + ex.Message;
                return false;
            }
        }


        public async Task AddVehicleAsync(Vehicle vehicle)
        {
            using var context = new EmissionInspectionContext();
            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();
        }

        public List<Vehicle> SearchVehicle(string? plateNumber, string? model)
        {
            var query = _repo.GetAll().AsQueryable();   // lấy List<Vehicle> từ repo

            // Lọc theo biển số (contains, không phân biệt hoa-thường)
            if (!string.IsNullOrWhiteSpace(plateNumber))
                query = query.Where(v => v.PlateNumber != null &&
                                         v.PlateNumber.Contains(plateNumber, StringComparison.OrdinalIgnoreCase));

            // Lọc theo model (so khớp chính xác, ignore case)
            if (!string.IsNullOrWhiteSpace(model))
                query = query.Where(v => v.Model != null &&
                                         v.Model.Equals(model, StringComparison.OrdinalIgnoreCase));

            return query.ToList();
        }
        public List<Vehicle> GetMyVehicles(int ownerId)
        {
            using var context = new EmissionInspectionContext();
            return context.Vehicles
                          .Where(v => v.OwnerId == ownerId)
                          .ToList();
        }
        public List<string> GetAllPlateNumbers()
        {
            return _repo.GetAll().Select(v => v.PlateNumber).ToList();
        }



    }

}
