using Business.Constants;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Core.DataAccess;
using Core.DataAccess.RefitApi;
using Core.Utilities.Security.Jwt;
using DataLayer.Abstract;
using DataLayer.Concrete.EntityFramework;
using Entities.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
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
            Func<IServiceProvider, ClaimsPrincipal> getPrincipal = (sp) =>
              sp.GetService<IHttpContextAccessor>().HttpContext?.User ??
              new ClaimsPrincipal(new ClaimsIdentity(Messages.Unknown));

            services.AddScoped<IPrincipal>(getPrincipal);
            services.AddTransient<ICarsDal, EfCarsDal>();
            services.AddTransient<ICarsService, CarsManager>();
            
            services.AddTransient<ILocationDal, EfLocationDal>();
            services.AddTransient<ILocationService, LocationManager>();
            
            services.AddTransient<IVehicleDal, EfVehicleDal>();
            services.AddTransient<IVehicleService, VehicleManager>(); 
            
            services.AddTransient<IWareHouseDal, EfWareHouseDal>();
            services.AddTransient<IWareHouseService, WareHouseManager>();   
            
            services.AddTransient<ICartItemDal, EfCartItemDal>();
            services.AddTransient<ICartItemService, CartItemManager>();
            
            services.AddTransient<IUsersDal, EfUsersDal>();
            services.AddTransient<IUsersService, UsersManager>();

            services.AddTransient<ITokenHelper, JwtHelper>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IRefitApiRepository, RefitApiRepository>();

            services.AddDbContext<CognizantDbContext>(ServiceLifetime.Transient);

        }
    }
}
