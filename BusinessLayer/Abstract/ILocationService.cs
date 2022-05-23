using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ILocationService
    {
        List<Location> GetList();
        Location Add(Location cars);
        Location Update(Location cars);
        void Delete(Location cars);
    }
}
