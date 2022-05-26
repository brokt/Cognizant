using BusinessLayer.Dtos;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUsersService
    {
        Task<IDataResult<AccessToken>> ValidateUser(string email, string password);
        Task<IResult> RegisterUser(RegisterUserDtos registerCustomerDtos);
    }
}
