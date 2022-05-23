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
    public class CarsManager : ICarsService
    {
        private readonly ICarsDal _carsDal;

        public CarsManager(ICarsDal carsDal)
        {
            _carsDal = carsDal;
        }

        public List<Cars> GetList()
        {
            return _carsDal.GetList().ToList();
        }

        public Cars Add(Cars cars)
        {
            return _carsDal.Add(cars);
        }
        
        public Cars Update(Cars cars)
        {
            return _carsDal.Update(cars);
        }
        public void Delete(Cars cars)
        {
            _carsDal.Delete(cars);
        }
    }
}
