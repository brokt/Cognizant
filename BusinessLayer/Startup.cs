using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataLayer.Abstract;
using DataLayer.Concrete.EntityFramework;
using Entities.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusinessStartup
    {
        public BusinessStartup(IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            Configuration = configuration;
            HostEnvironment = hostEnvironment;
        }

        public IConfiguration Configuration { get; }

        protected IHostEnvironment HostEnvironment { get; }

        public virtual void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<ICarsDal, EfCarsDal>();
            services.AddTransient<ICarsService, CarsManager>();
            
            services.AddTransient<ILocationDal, EfLocationDal>();
            services.AddTransient<ILocationService, LocationManager>();
            
            services.AddTransient<IVehicleDal, EfVehicleDal>();
            services.AddTransient<IVehicleService, VehicleManager>(); 
            
            services.AddTransient<IWareHouseDal, EfWareHouseDal>();
            services.AddTransient<IWareHouseService, WareHouseManager>();

            services.AddDbContext<CognizantDbContext>();

        }
    }
}
