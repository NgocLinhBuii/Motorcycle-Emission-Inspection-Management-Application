using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using Motorcycle_Emission_Inspection_Management.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorcycle_Emission_Inspection_Management.BLL.Services
{
    public class InspectionStationService
    {
        private readonly InspectionStationRepository _repo = new();

        public List<InspectionStation> GetAll() => _repo.GetAll();

        public InspectionStation? GetById(int id) => _repo.GetById(id);

        public void Create(InspectionStation x) => _repo.Add(x);

        public void Update(InspectionStation x) => _repo.Update(x);

        public void Delete(InspectionStation x) => _repo.Delete(x);
    }

}
