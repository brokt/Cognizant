using Core.Entities;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IVehicleService
    {
        Task<List<DropDownDtos>> GetBrandList();
        Task<int> GetCountList(string brandName);
        Task<List<Vehicle>> GetList();
        Task<List<Vehicle>> GetList(int startIndex = 0, int count = 0, string brandName = null);
        Task<Vehicle> GetById(int id);
        Vehicle Add(Vehicle cars);
        Vehicle Update(Vehicle cars);
        void Delete(Vehicle cars);
    }
}
