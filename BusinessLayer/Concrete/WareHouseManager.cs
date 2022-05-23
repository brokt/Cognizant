using BusinessLayer.Abstract;
using DataLayer.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WareHouseManager : IWareHouseService
    {
        private readonly IWareHouseDal _wareHouseDal;

        public WareHouseManager(IWareHouseDal wareHouseDal)
        {
            _wareHouseDal = wareHouseDal;
        }

        public Task<IEnumerable<WareHouse>> GetListAsync()
        {
            return _wareHouseDal.GetListAsync();
        }
        public Task<WareHouse> GetByIdAsync(int id)
        {
            return _wareHouseDal.GetAsync(g => g.Id == id);
        } 
        public List<WareHouse> GetList()
        {
            return _wareHouseDal.GetList().ToList();
        }

        public List<WareHouse> Add(List<WareHouse> cars)
        {
            var res = _wareHouseDal.Add(cars);
            _wareHouseDal.SaveChanges();
            return res;

        }
        public WareHouse Add(WareHouse cars)
        {
            var res = _wareHouseDal.Add(cars);
            _wareHouseDal.SaveChanges();
            return res;
        }

        public WareHouse Update(WareHouse cars)
        {
            return _wareHouseDal.Update(cars);
        }
        public void Delete(WareHouse cars)
        {
            _wareHouseDal.Delete(cars);
        }
    }
}
