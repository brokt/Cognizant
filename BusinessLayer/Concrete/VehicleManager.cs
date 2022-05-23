using BusinessLayer.Abstract;
using Core.Entities;
using DataLayer.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class VehicleManager : IVehicleService
    {
        private readonly IVehicleDal _vehicleDal;

        public VehicleManager(IVehicleDal vehicleDal)
        {
            _vehicleDal = vehicleDal;
        }
        public Task<int> GetCountList(string brandName)
        {
            var res = _vehicleDal.GetListAsync(g => !string.IsNullOrEmpty(brandName) ? g.Make.Contains(brandName) : true)
                .ContinueWith(gr => gr.Result.Count());
            return res;
        }

        public Task<List<DropDownDtos>> GetBrandList()
        {
            var res = _vehicleDal.Query().Select(x => new DropDownDtos
            {
                Id = x.Make,
                Text = x.Make
            }).ToListAsync();
            return res;
        }

        public Task<List<Vehicle>> GetList()
        {
            var res = _vehicleDal.Query().Include(i => i.Cars).ThenInclude(i => i.WareHouse).ThenInclude(i =>i.Location).Select(x => new Vehicle() 
            {
                Id = x.Id,
                Make = x.Make,
                DateAdded = x.DateAdded,
                Model = x.Model,
                Price = x.Price,
                YearModel = x.YearModel,
                Licensed = x.Licensed,
                Cars = new Cars()
                {
                    Id = x.Cars.Id,
                    Location = x.Cars.Location,
                    WareHouse = x.Cars.WareHouse.Select(xs => new WareHouse
                    {
                        Id = xs.Id,
                        Name = xs.Name,
                        Location = new Location()
                        {
                            Lat = xs.Location.Lat,
                            Long = xs.Location.Long,
                        }
                    }).ToList()
                }
            }).OrderBy(a => a.DateAdded).ToListAsync();
            return res;
        }
        public Task<List<Vehicle>> GetList(int startIndex = 0, int count = 0,string brandName = null)
        {
            var res = _vehicleDal.Query().Where(g => !string.IsNullOrEmpty(brandName) ? g.Make.Contains(brandName) : true).Include(i => i.Cars).ThenInclude(i => i.WareHouse).ThenInclude(i =>i.Location).Select(x => new Vehicle() 
            {
                Id = x.Id,
                Make = x.Make,
                DateAdded = x.DateAdded,
                Model = x.Model,
                Price = x.Price,
                YearModel = x.YearModel,
                Licensed = x.Licensed,
                Cars = new Cars()
                {
                    Id = x.Cars.Id,
                    Location = x.Cars.Location,
                    WareHouse = x.Cars.WareHouse.Select(xs => new WareHouse
                    {
                        Id = xs.Id,
                        Name = xs.Name,
                        Location = new Location()
                        {
                            Lat = xs.Location.Lat,
                            Long = xs.Location.Long,
                        }
                    }).ToList()
                }
            }).OrderBy(a => a.DateAdded).Skip(startIndex).Take(count).ToListAsync();
            return res;
        }
        public Task<Vehicle> GetById(int id)
        {
            var res = _vehicleDal.Query().Where(g => g.Id == id).Include(i => i.Cars).ThenInclude(i => i.WareHouse).ThenInclude(i =>i.Location).Select(x => new Vehicle() 
            {
                Id = x.Id,
                Make = x.Make,
                DateAdded = x.DateAdded,
                Model = x.Model,
                Price = x.Price,
                YearModel = x.YearModel,
                Licensed = x.Licensed,
                Cars = new Cars()
                {
                    Id = x.Cars.Id,
                    Location = x.Cars.Location,
                    WareHouse = x.Cars.WareHouse.Select(xs => new WareHouse
                    {
                        Id = xs.Id,
                        Name = xs.Name,
                        Location = new Location()
                        {
                            Lat = xs.Location.Lat,
                            Long = xs.Location.Long,
                        }
                    }).ToList()
                }
            }).OrderBy(a => a.DateAdded).FirstOrDefaultAsync();
            return res;
        }

        public Vehicle Add(Vehicle entity)
        {
            var res = _vehicleDal.Add(entity);
            _vehicleDal.SaveChanges();
            return res;

        }

        public Vehicle Update(Vehicle entity)
        {
            var res =  _vehicleDal.Update(entity);
            _vehicleDal.SaveChanges();
            return res;
        }
        public void Delete(Vehicle entity)
        {
            _vehicleDal.Delete(entity);
            _vehicleDal.SaveChanges();
        }
    }
}
