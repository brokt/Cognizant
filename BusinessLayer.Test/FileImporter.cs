using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataLayer.Abstract;
using DataLayer.Concrete.EntityFramework;
using Entities;
using Entities.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BusinessLayer.Test
{
    [TestClass]
    public class FileImporter
    {
        private IWareHouseService _wareHouseService;

        [TestInitialize]
        public void Setup()
        {
            StartupTest.ConfigureServices();
            _wareHouseService = StartupTest.serviceProvider.GetService<IWareHouseService>();
        }

        [TestMethod]
        public void Import_File_to_Db()
        {
            
            var fileData = File.ReadAllText(@"warehouses.json");
            var result = JsonConvert.DeserializeObject<List<WareHouse>>(fileData);
            result.ForEach(f => { f.Id = 0; f.Cars.Vehicles.ForEach(fr => fr.Id = 0); });
            var res = _wareHouseService.Add(result);
            Assert.AreEqual(result.Count, res.Count);
        }
    }
}
