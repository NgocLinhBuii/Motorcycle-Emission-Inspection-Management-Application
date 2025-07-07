using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Motorcycle_Emission_Inspection_Management.BLL.DTOs;
using Motorcycle_Emission_Inspection_Management.Common;
using Motorcycle_Emission_Inspection_Management.DAL;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using Motorcycle_Emission_Inspection_Management.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Motorcycle_Emission_Inspection_Management.BLL.Services
{
    public class InspectionRecordService
    {
        private readonly InspectionRecordRepository _repo = new();

        public List<InspectionRecord> GetAll()
        {
            using var context = new EmissionInspectionContext();

            return context.InspectionRecords.ToList();
        }

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

        public void AssignInspector(int recordId, int inspectorId, DateTime date)
        {
            using var context = new EmissionInspectionContext();

            var record = context.InspectionRecords.FirstOrDefault(r => r.RecordId == recordId);
            if (record == null) throw new Exception("Không tìm thấy hồ sơ kiểm định.");

            record.InspectorId = inspectorId;
            record.InspectionDate = date;

            context.SaveChanges();
        }
        public async Task<IList<InspectionRecordDto>> GetRequestsAsync(
        DateTime? from, DateTime? to, string? result)
        {
            using var ctx = new EmissionInspectionContext();

            var q = ctx.InspectionRecords
                       .Include(r => r.Vehicle)
                       .Include(r => r.Station)
                       .AsQueryable();

            if (from.HasValue) q = q.Where(r => r.InspectionDate >= from.Value);
            if (to.HasValue) q = q.Where(r => r.InspectionDate <= to.Value);
            if (!string.IsNullOrWhiteSpace(result))
                q = q.Where(r => r.Result == result);

            return await q.Select(r => new InspectionRecordDto
            {
                PlateNumber = r.Vehicle.PlateNumber,
                Brand = r.Vehicle.Brand,
                Model = r.Vehicle.Model,
                InspectionDate = r.InspectionDate.Value,
                Result = r.Result,
                StationName = r.Station.Name
            })
                        .OrderByDescending(x => x.InspectionDate)
                        .ToListAsync();
        }


        public async Task<IList<FacilityReportDto>> SearchFacilityReportsAsync(
        DateTime? fromDate,
        DateTime? toDate,
        string? stationAddress,
        string? phone)
        {
            using var ctx = new EmissionInspectionContext();

            // Truy vấn gốc (có Include Station)
            var q = ctx.InspectionRecords
                       .Include(r => r.Station)
                       .AsQueryable();

            /* ----- LỌC THEO FORM ----- */
            if (fromDate.HasValue)
                q = q.Where(r => r.InspectionDate >= fromDate);

            if (toDate.HasValue)
                q = q.Where(r => r.InspectionDate <= toDate);

            if (!string.IsNullOrWhiteSpace(stationAddress))
                q = q.Where(r => r.Station.Address != null &&
                                 r.Station.Address.Contains(stationAddress.Trim(),
                                                            StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(phone))
                q = q.Where(r => r.Station.Phone != null &&
                                 r.Station.Phone.Contains(phone.Trim(),
                                                          StringComparison.OrdinalIgnoreCase));

            /* ----- GỘP THÀNH FacilityReportDto ----- */
            return await q.GroupBy(r => new
            {
                Date = r.InspectionDate.Value,
                r.Station.StationId,
                r.Station.Name,
                r.Station.Address,
                r.Station.Phone
            })
                          .Select(g => new FacilityReportDto
                          {
                              InspectionDate = g.Key.Date,
                              StationName = g.Key.Name,
                              StationAddress = g.Key.Address,
                              Phone = g.Key.Phone,
                              PassedCount = g.Count(x => x.Result.Equals("Pass",
                                                           StringComparison.OrdinalIgnoreCase)),
                              FailedCount = g.Count(x => x.Result.Equals("Fail",
                                                           StringComparison.OrdinalIgnoreCase))
                          })
                          .OrderByDescending(x => x.InspectionDate)
                          .ToListAsync();
        }


        public List<InspectionRecord> GetByOwnerId(int ownerId)
        {
            using var context = new EmissionInspectionContext();

            return context.InspectionRecords
                .Include(r => r.Vehicle)
                .Where(r => r.Vehicle.OwnerId == ownerId)
                .ToList();
        }
       

        public async Task<IList<FacilityReportDto>> GetFacilityReportsAsync(
    DateTime? from, DateTime? to, int? stationId, string phone)
        {
            using var context = new EmissionInspectionContext();

            var query = context.InspectionRecords
                               .Include(r => r.Station)
                               .AsQueryable();

            if (from.HasValue)
                query = query.Where(r => r.InspectionDate >= from);

            if (to.HasValue)
                query = query.Where(r => r.InspectionDate <= to);

            if (stationId.HasValue)
                query = query.Where(r => r.StationId == stationId);

            if (!string.IsNullOrWhiteSpace(phone))
                query = query.Where(r => r.Station.Phone.Contains(phone));

            var result = await query
                .GroupBy(r => new
                {
                    r.InspectionDate.Value,
                    r.Station.StationId,
                    r.Station.Name,
                    r.Station.Address,
                    r.Station.Phone
                })
               .Select(g => new FacilityReportDto
               {
                   InspectionDate = g.Key.Value,
                   StationName = g.Key.Name,
                   StationAddress = g.Key.Address,
                   Phone = g.Key.Phone,
                   PassedCount = g.Count(x => x.Result.ToLower() == "pass"),
                   FailedCount = g.Count(x => x.Result.ToLower() == "fail")
               })

                .OrderByDescending(x => x.InspectionDate)
                .ToListAsync();

            return result;
        }

        public void RegisterInspection(int vehicleId,
                               int stationId,
                               DateTime inspectionDate,
                               string result = "Fail",
                               int? inspectorId = null)
        {
            // Ngày phải > hôm nay
            if (inspectionDate.Date <= DateTime.Today)
                throw new ArgumentException("Ngày kiểm định phải sau hôm nay.", nameof(inspectionDate));

            // Result chỉ được "Pass" hoặc "Fail"
            result = result.Trim();
            if (!result.Equals("Pass", StringComparison.OrdinalIgnoreCase) &&
                !result.Equals("Fail", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("Result chỉ được 'Pass' hoặc 'Fail'.", nameof(result));

            using var ctx = new EmissionInspectionContext();

            var record = new InspectionRecord
            {
                VehicleId = vehicleId,
                StationId = stationId,
                InspectorId = inspectorId,   // null → phân công sau
                InspectionDate = inspectionDate,
                Result = result,        // "Pass" hoặc "Fail"
                Co2emission = 0m,
                Hcemission = 0m,
                Comments = string.Empty
            };

            ctx.InspectionRecords.Add(record);
            ctx.SaveChanges();
        }

    }

}
