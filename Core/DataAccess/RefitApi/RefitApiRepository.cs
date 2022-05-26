using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.RefitApi
{
    public class RefitApiRepository : IRefitApiRepository
    {
        private readonly IConfiguration _configuration;
        private readonly HttpContext _httpContext;

        public RefitApiRepository(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContext = httpContextAccessor.HttpContext;
        }
        public T GetClientService<T>()
        {
            return RestService.For<T>(_configuration.GetSection("RefitClientUrl").Value, new RefitSettings()
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(_httpContext.Session.GetString("Token")),
            });
        }
    }
}
