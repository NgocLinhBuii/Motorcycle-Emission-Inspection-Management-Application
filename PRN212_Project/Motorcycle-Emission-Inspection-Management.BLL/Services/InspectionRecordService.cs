using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using Motorcycle_Emission_Inspection_Management.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorcycle_Emission_Inspection_Management.BLL.Services
{
    public class InspectionRecordService
    {
        private readonly InspectionRecordRepository _repo = new();

        public List<InspectionRecord> GetAll() => _repo.GetAll();

        public InspectionRecord? GetById(int id) => _repo.GetById(id);

        public void Create(InspectionRecord x) => _repo.Add(x);

        public void Update(InspectionRecord x) => _repo.Update(x);

        public void Delete(InspectionRecord x) => _repo.Delete(x);

        public List<InspectionRecord> SearchInspectionRecords(
    string? plateNumber,      
    string? status,           
    DateTime? inspectionDate) 
        {
       
            List<InspectionRecord> result = _repo.GetAll();

            // Nếu người dùng không nhập gì, trả thẳng về
            if (string.IsNullOrWhiteSpace(plateNumber) &&
                string.IsNullOrWhiteSpace(status) &&
                !inspectionDate.HasValue)
                return result;

            //Lọc theo biển số (partial, không phân biệt hoa-thường)
            if (!string.IsNullOrWhiteSpace(plateNumber))
                result = result.Where(ir =>
                         ir.Vehicle != null &&
                         ir.Vehicle.PlateNumber != null &&
                         ir.Vehicle.PlateNumber
                                  .Contains(plateNumber.Trim(),
                                            StringComparison.OrdinalIgnoreCase))
                               .ToList();

            // Lọc theo trạng thái / kết quả
            if (!string.IsNullOrWhiteSpace(status))
                result = result.Where(ir =>
                         ir.Result != null &&
                         ir.Result.Contains(status.Trim(),
                                            StringComparison.OrdinalIgnoreCase))
                               .ToList();

            // Lọc theo ngày kiểm định (so sánh phần ngày, bỏ qua giờ)
            if (inspectionDate.HasValue)
                result = result.Where(ir => ir.InspectionDate.Value == inspectionDate.Value.Date)
                               .ToList();

            return result;
        }

    }

}
