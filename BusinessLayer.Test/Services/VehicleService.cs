using BusinessLayer.Abstract;
using Core.Entities;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Test.Services
{
    [TestClass]
    public class VehicleService
    {
        private IVehicleService _vehicleService;
        [TestInitialize]
        public void Setup()
        {
            StartupTest.ConfigureServices();
            _vehicleService = StartupTest.serviceProvider.GetService<IVehicleService>();
        }
        [TestMethod]
        [DataRow(2,"Test brand","Test Model",2020,29382,true)]
        public void Add(int carId,string make,string model,int yearModel,float price,bool licenced)
        {
            Vehicle vehicle = new Vehicle()
            {
                CarsId = carId,
                Make = make,
                Model = model,
                YearModel = yearModel,
                Price = price,
                Licensed = licenced,
                DateAdded = DateTime.Now
            };
            var addedModel = _vehicleService.Add(vehicle);
            Assert.IsNotNull(addedModel);
        }

        [TestMethod]
        [DataRow(13)]
        public async Task DeleteAsync(int id)
        {
            var detail = await _vehicleService.GetById(id);
            _vehicleService.Delete(detail);
            var res = await _vehicleService.GetById(id);
            Assert.IsNull(res);
        }

        [TestMethod]
        public async Task GetBrandListAsync()
        {
            var list = await _vehicleService.GetBrandList();
            Assert.AreEqual(list.Any(), true);
        }
        [TestMethod]
        [DataRow(1)]
        public async Task GetByIdAsync(int id)
        {
            var detail = await _vehicleService.GetById(id);
            Assert.AreEqual(detail.Id, id);
        }
        [TestMethod]
        [DataRow("Volvo")]
        public async Task GetCountListAsync(string brandName)
        {
            var brandList = await _vehicleService.GetCountList(brandName);
            Assert.AreEqual(brandList > 0, true);            
        }
        [TestMethod]
        public async Task Get_List()
        {
            var list = await _vehicleService.GetList();
            Assert.AreEqual(list.Any(), true);
        }
        [TestMethod]
        [DataRow(0,10,null)]
        public async Task GetListAsync(int startIndex = 0, int count = 0, string brandName = null)
        {
            var list = await _vehicleService.GetList(startIndex, count, brandName);
            Assert.AreEqual(list.Any(), true);
        }
        [TestMethod]
        [DataRow(5,"Test Car")]
        public async Task UpdateAsync(int id,string brandName)
        {
            var detail = await _vehicleService.GetById(id);
            detail.Make = brandName;
            var updateModel = _vehicleService.Update(detail);
            Assert.IsInstanceOfType(updateModel, typeof(Vehicle));
        }
    }
}
