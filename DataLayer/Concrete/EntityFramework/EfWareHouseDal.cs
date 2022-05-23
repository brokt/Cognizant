using Core.DataAccess.EntityFramework;
using DataLayer.Abstract;
using Entities;
using Entities.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Concrete.EntityFramework
{
    public class EfWareHouseDal : EfEntityRepositoryBase<WareHouse, CognizantDbContext>, IWareHouseDal
    {
        public EfWareHouseDal(CognizantDbContext context)
        : base(context)
        {
        }
    }
}
