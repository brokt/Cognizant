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
    public class LocationManager : ILocationService
    {
        private readonly ILocationDal _locationDal;

        public LocationManager(ILocationDal locationDal)
        {
            _locationDal = locationDal;
        }

        public List<Location> GetList()
        {
            return _locationDal.GetList().ToList();
        }

        public Location Add(Location cars)
        {
            return _locationDal.Add(cars);
        }

        public Location Update(Location cars)
        {
            return _locationDal.Update(cars);
        }
        public void Delete(Location cars)
        {
            _locationDal.Delete(cars);
        }
    }
}
