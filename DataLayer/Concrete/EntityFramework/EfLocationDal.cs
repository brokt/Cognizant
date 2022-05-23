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
    public class EfLocationDal : EfEntityRepositoryBase<Location, CognizantDbContext>, ILocationDal
    {
        public EfLocationDal(CognizantDbContext context)
        : base(context)
        {
        }
    }
}
