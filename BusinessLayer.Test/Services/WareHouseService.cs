using BusinessLayer.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BusinessLayer.Test.Services
{
    [TestClass]
    public class WareHouseService
    {
        private IWareHouseService _wareHouseService;

        [TestInitialize]
        public void Setup()
        {
            StartupTest.ConfigureServices();
            _wareHouseService = StartupTest.serviceProvider.GetService<IWareHouseService>();
        }
        [TestMethod]
        public void Get_List_WareHouse()
        {
            var list =_wareHouseService.GetList();
            
        } 
        [TestMethod]
        public async Task Get_List_WareHouseAsync()
        {
            var list = await _wareHouseService.GetListAsync();
            
        }
        [TestMethod]
        [DataRow("Test",1,1)]
        public void Add_WareHouse(string wareHouseName,int carsId,int locationId)
        {
            WareHouse wareHouse = new WareHouse()
            {
                Name = wareHouseName,
                CarsId = carsId,
                LocationId = locationId
            };
            _wareHouseService.Add(wareHouse);
        } 
        
        [TestMethod]
        [DataRow("Test-5",2)]
        public async Task Update_WareHouseAsync(string wareHouseName,int wareHouseId)
        {
            var wareHouse = await _wareHouseService.GetByIdAsync(wareHouseId);
            wareHouse.Name = wareHouseName;
            _wareHouseService.Update(wareHouse);
        }
        [TestMethod]
        [DataRow(80)]
        public async Task Delete_WareHouseAsync(int wareHouseId)
        {
            var wareHouse = await _wareHouseService.GetByIdAsync(wareHouseId);            
            _wareHouseService.Delete(wareHouse);
        }

    }
}
