
using Microsoft.EntityFrameworkCore;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorcycle_Emission_Inspection_Management.DAL.Repositories
{
    public class InspectionRecordRepository
    {
        
        public List<InspectionRecord> GetAll()
        {
            using var context = new EmissionInspectionContext();
            return context.InspectionRecords.Include(v => v.Vehicle).
                Include(x => x.Station).ToList();
        }

        public void Add(InspectionRecord x)
        {
            using var context = new EmissionInspectionContext();
            context.InspectionRecords.Add(x);
            context.SaveChanges();
        }

        public bool AddSafe(InspectionRecord record, out string errorMsg)
        {
            errorMsg = string.Empty;

            using var context = new EmissionInspectionContext();

            // 1) Xác thực StationId
            if (record.StationId <= 0)
            {
                errorMsg = "StationId không hợp lệ (<= 0).";
                return false;
            }

            bool stationExists = context.InspectionStations
                                        .Any(s => s.StationId == record.StationId);

            if (!stationExists)
            {
                errorMsg = $"StationId {record.StationId} không tồn tại trong " +
                           "bảng InspectionStations.";
                return false;
            }

            // 2) Thêm bản ghi & lưu
            try
            {
                context.InspectionRecords.Add(record);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log nếu cần
                errorMsg = "Lỗi khi lưu: " + ex.Message;
                return false;
            }
        }

        public void Update(InspectionRecord x)
        {
            using var context = new EmissionInspectionContext();
            context.InspectionRecords.Update(x);
            context.SaveChanges();
        }

        public void Delete(InspectionRecord x)
        {
            using var context = new EmissionInspectionContext();
            context.InspectionRecords.Remove(x);
            context.SaveChanges();
        }

        public InspectionRecord? GetById(int id)
        {
            using var context = new EmissionInspectionContext();
            return context.InspectionRecords.FirstOrDefault(i => i.RecordId == id);
        }
       
    }

}
