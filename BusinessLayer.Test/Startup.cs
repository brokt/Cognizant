using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Castle.Core.Configuration;
using DataLayer.Abstract;
using DataLayer.Concrete.EntityFramework;
using Entities.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace BusinessLayer.Test
{
    public static class StartupTest
    {
        public static ServiceCollection services;
        public static ServiceProvider serviceProvider;
        private static IConfiguration _config;

        public static void ConfigureServices()
        {
            services = new ServiceCollection();
            services.AddTransient<ICarsDal, EfCarsDal>();
            services.AddTransient<ICarsService, CarsManager>();

            services.AddTransient<ILocationDal, EfLocationDal>();
            services.AddTransient<ILocationService, LocationManager>();

            services.AddTransient<IVehicleDal, EfVehicleDal>();
            services.AddTransient<IVehicleService, VehicleManager>();

            services.AddTransient<IWareHouseDal, EfWareHouseDal>();
            services.AddTransient<IWareHouseService, WareHouseManager>();

            services.AddDbContext<CognizantDbContext>();
            services.AddScoped<IConfiguration>(_ => Configuration);
            serviceProvider = services.BuildServiceProvider();
        }

        public static IConfiguration Configuration
        {
            get
            {
                if (_config == null)
                {
                    var builder = new ConfigurationBuilder().AddJsonFile($"testsettings.json", optional: false);
                    _config = builder.Build();
                }

                return _config;
            }
        }
    }
}
