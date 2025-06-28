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
    }

}
