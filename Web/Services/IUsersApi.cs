//<auto-generated />

using System.Threading.Tasks;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Refit;
using Web.Models;
using static Web.Models.AuthModel;

namespace Web.Services
{
    public interface IUsersApi
    {
        [Post("/Users/LoginUser")]
        Task<AuthDataResult> LoginUser([Body] LoginModel loginModel);

        [Post("/Users/RegisterUser")]
        Task<IResult> RegisterUser([Body] RegisterModel registerModel);
    }
}