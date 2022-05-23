using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWareHouseService
    {
        List<WareHouse> GetList();
        Task<IEnumerable<WareHouse>> GetListAsync();
        Task<WareHouse> GetByIdAsync(int id);
        WareHouse Add(WareHouse cars);
        List<WareHouse> Add(List<WareHouse> cars);
        WareHouse Update(WareHouse cars);
        void Delete(WareHouse cars);
    }
}
