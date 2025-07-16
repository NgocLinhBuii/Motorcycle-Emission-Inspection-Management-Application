using Microsoft.EntityFrameworkCore;
using Motorcycle_Emission_Inspection_Management.BLL.DTOs;
using Motorcycle_Emission_Inspection_Management.DAL;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using Motorcycle_Emission_Inspection_Management.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Motorcycle_Emission_Inspection_Management.BLL.Services
{
    public class InspectionRecordService
    {
        private readonly InspectionRecordRepository _repo = new();

        /* ==== CRUD CƠ BẢN ==== */
        public List<InspectionRecord> GetAll()
        {
            using var context = new EmissionInspectionContext();
            return context.InspectionRecords
                          .Include(r => r.Vehicle)
                          .Include(r => r.Station)
                          .ToList();
        }

        // Các hàm có sẵn của bạn…

        public bool AddSafe(InspectionRecord record, out string errorMsg)
        {
            errorMsg = string.Empty;

            using var context = new EmissionInspectionContext();

            // Kiểm tra StationId có tồn tại
            bool stationExists = context.InspectionStations
                                        .Any(s => s.StationId == record.StationId);

            if (!stationExists)
            {
                errorMsg = $"Trạm kiểm định có ID = {record.StationId} không tồn tại.";
                return false;
            }

            try
            {
                context.InspectionRecords.Add(record);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                errorMsg = "Lỗi khi lưu: " + ex.Message;
                return false;
            }
        }



        public InspectionRecord? GetById(int id) => _repo.GetById(id);
        public void Create(InspectionRecord x) => _repo.Add(x);
        public void Update(InspectionRecord x) => _repo.Update(x);
        public void Delete(InspectionRecord x) => _repo.Delete(x);

        /* ==== TÌM KIẾM HỒ SƠ ==== */
        public List<InspectionRecord> SearchInspectionRecords(
            string? plateNumber,
            string? status,
            DateTime? inspectionDate)
        {
            List<InspectionRecord> result = _repo.GetAll();

            if (string.IsNullOrWhiteSpace(plateNumber) &&
                string.IsNullOrWhiteSpace(status) &&
                !inspectionDate.HasValue)
                return result;

            if (!string.IsNullOrWhiteSpace(plateNumber))
                result = result.Where(ir =>
                             ir.Vehicle?.PlateNumber != null &&
                             ir.Vehicle.PlateNumber.Contains(plateNumber.Trim(),
                                                             StringComparison.OrdinalIgnoreCase))
                               .ToList();

            if (!string.IsNullOrWhiteSpace(status))
                result = result.Where(ir =>
                             ir.Result != null &&
                             ir.Result.Contains(status.Trim(),
                                                StringComparison.OrdinalIgnoreCase))
                               .ToList();

            if (inspectionDate.HasValue)
                result = result.Where(ir =>
                             ir.InspectionDate!.Value.Date == inspectionDate.Value.Date)
                               .ToList();

            return result;
        }

        public void AssignInspector(int recordId, int inspectorId, DateTime date)
        {
            using var context = new EmissionInspectionContext();

            var record = context.InspectionRecords.FirstOrDefault(r => r.RecordId == recordId)
                         ?? throw new Exception("Không tìm thấy hồ sơ kiểm định.");

            record.InspectorId = inspectorId;
            record.InspectionDate = date;

            context.SaveChanges();
        }

        /* ==== BÁO CÁO – LẤY DỮ LIỆU ĐỒNG BỘ ==== */
        public IList<InspectionRecordDto> GetRequests(
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

            return q.Select(r => new InspectionRecordDto
            {
                PlateNumber = r.Vehicle.PlateNumber,
                Brand = r.Vehicle.Brand,
                Model = r.Vehicle.Model,
                InspectionDate = r.InspectionDate!.Value,
                Result = r.Result,
                StationName = r.Station.Name
            })
                    .OrderByDescending(x => x.InspectionDate)
                    .ToList();
        }

        public IList<FacilityReportDto> SearchFacilityReports(
            DateTime? fromDate,
            DateTime? toDate,
            string? stationAddress,
            string? phone)
        {
            using var ctx = new EmissionInspectionContext();

            var q = ctx.InspectionRecords
                       .Include(r => r.Station)
                       .AsQueryable();

            if (fromDate.HasValue) q = q.Where(r => r.InspectionDate >= fromDate.Value);
            if (toDate.HasValue) q = q.Where(r => r.InspectionDate <= toDate.Value);

            if (!string.IsNullOrWhiteSpace(stationAddress))
                q = q.Where(r => r.Station.Address != null &&
                                 r.Station.Address.Contains(stationAddress.Trim(),
                                                            StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(phone))
                q = q.Where(r => r.Station.Phone != null &&
                                 r.Station.Phone.Contains(phone.Trim(),
                                                          StringComparison.OrdinalIgnoreCase));

            return q.GroupBy(r => new
            {
                Date = r.InspectionDate!.Value,
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
                        PassedCount = g.Count(x => x.Result.Equals("Pass", StringComparison.OrdinalIgnoreCase)),
                        FailedCount = g.Count(x => x.Result.Equals("Fail", StringComparison.OrdinalIgnoreCase))
                    })
                    .OrderByDescending(x => x.InspectionDate)
                    .ToList();
        }

        public IList<InspectionRecord> GetByOwnerId(int ownerId)
        {
            using var context = new EmissionInspectionContext();
            return context.InspectionRecords
                          .Include(r => r.Vehicle)
                          .Where(r => r.Vehicle.OwnerId == ownerId)
                          .ToList();
        }

        public IList<FacilityReportDto> GetFacilityReports(
        DateTime? from, DateTime? to,
        int? stationId, string phone)
        {
            using var context = new EmissionInspectionContext();

            var query = context.InspectionRecords
                               .Include(r => r.Station)
                               .AsQueryable();

            if (from.HasValue) query = query.Where(r => r.InspectionDate >= from.Value);
            if (to.HasValue) query = query.Where(r => r.InspectionDate <= to.Value);
            if (stationId.HasValue) query = query.Where(r => r.StationId == stationId.Value);
            if (!string.IsNullOrWhiteSpace(phone))
                query = query.Where(r => r.Station.Phone.Contains(phone));

            // **KHÔNG dùng Equals(StringComparison)** trong LINQ to Entities
            var result = query
                .GroupBy(r => new
                {
                    Date = r.InspectionDate!.Value.Date,
                    r.Station.StationId,
                    r.Station.Phone,
                    r.Station.Name,
                    r.Station.Address
                })
                .Select(g => new FacilityReportDto
                {
                    InspectionDate = g.Key.Date,
                    StationName = g.Key.Name,
                    Phone = g.Key.Phone,
                    StationAddress = g.Key.Address,
                    PassedCount = g.Count(x => x.Result == "Pass" || x.Result == "PASS" || x.Result == "pass"),
                    FailedCount = g.Count(x => x.Result == "Fail" || x.Result == "FAIL" || x.Result == "fail")
                })
                .OrderByDescending(x => x.InspectionDate)
                .ToList();      // <-- chuyển sang List ở đây, xử lý tiếp trong bộ nhớ

            // Nếu muốn ép chính xác hơn (vd. chỉ "Pass"/"Fail" chuẩn), có thể dùng .ToUpper()
            // nhưng phải thực hiện SAU khi ToList() để tránh lỗi dịch SQL.

            return result;
        }


        /* ==== ĐĂNG KÝ HỒ SƠ MỚI ==== */
        public void RegisterInspection(
            int vehicleId,
            int stationId,
            DateTime inspectionDate,
            string result = "Fail",
            int? inspectorId = null)
        {
            if (inspectionDate.Date <= DateTime.Today)
                throw new ArgumentException("Ngày kiểm định phải sau hôm nay.", nameof(inspectionDate));

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
                Result = result,
                Co2emission = 0m,
                Hcemission = 0m,
                Comments = string.Empty
            };

            ctx.InspectionRecords.Add(record);
            ctx.SaveChanges();
        }

        /* ==== TÌM KIẾM HỒ SƠ ==== */
        public List<InspectionRecord> SearchInspectionRecords(string plateNumber, DateTime? fromDate, DateTime? toDate, string stationName)
        {
            // Start query to fetch inspection records
            var query = _repo.GetAll().AsQueryable();

            // Filter by Plate Number (Biển số xe)
            if (!string.IsNullOrEmpty(plateNumber))
            {
                query = query.Where(ir => ir.Vehicle.PlateNumber.Contains(plateNumber.Trim(), StringComparison.OrdinalIgnoreCase));
            }

            // Filter by Inspection Date Range (Từ ngày đến ngày)
            if (fromDate.HasValue)
            {
                query = query.Where(ir => ir.InspectionDate >= fromDate.Value);
            }

            if (toDate.HasValue)
            {
                query = query.Where(ir => ir.InspectionDate <= toDate.Value);
            }

            // Filter by Station Name (Trạm kiểm định)
            if (!string.IsNullOrEmpty(stationName))
            {
                query = query.Where(ir => ir.Station.Name.Contains(stationName.Trim(), StringComparison.OrdinalIgnoreCase));
            }

            // Filter by Result (only "Pass")
            query = query.Where(ir => ir.Result.Equals("Pass", StringComparison.OrdinalIgnoreCase));

            // Execute the query and return the filtered results
            return query.ToList();
        }


    }
}
