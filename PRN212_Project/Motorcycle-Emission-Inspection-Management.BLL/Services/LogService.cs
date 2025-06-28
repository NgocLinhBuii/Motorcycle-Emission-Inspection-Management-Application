using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using Motorcycle_Emission_Inspection_Management.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorcycle_Emission_Inspection_Management.BLL.Services
{
    public class LogService
    {
        private readonly LogRepository _repo = new();

        public List<Log> GetAll() => _repo.GetAll();

        public Log? GetById(int id) => _repo.GetById(id);

        public void Create(Log x) => _repo.Add(x);

        public void Update(Log x) => _repo.Update(x);

        public void Delete(Log x) => _repo.Delete(x);
    }

}
