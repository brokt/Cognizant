using Business.Constants;
using Business.Services.Authentication;
using BusinessLayer.Abstract;
using BusinessLayer.Dtos;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using DataLayer.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UsersManager : IUsersService
    {
        private readonly IUsersDal _usersDal;
        private readonly ITokenHelper _tokenHelper;
        public UsersManager(IUsersDal usersDal, ITokenHelper tokenHelper)
        {
            _usersDal = usersDal;
            _tokenHelper = tokenHelper;
        }

        public async Task<IDataResult<AccessToken>> ValidateUser(string email, string password)
        {
            var user = _usersDal.Query().Where(g => g.Status == true && g.Email == email).FirstOrDefault();

            if (user == null)
            {
                return new ErrorDataResult<AccessToken>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordSalt, user.PasswordHash))
            {
                return new ErrorDataResult<AccessToken>(Messages.PasswordError);
            }

            var accessToken = _tokenHelper.CreateToken<DArchToken>(user.Id, user.Email);
            accessToken.Claims = new List<string>() { "UsersRole"};

            return new SuccessDataResult<AccessToken>(accessToken, Messages.SuccessfulLogin);
        }

        public async Task<IResult> RegisterUser(RegisterUserDtos registerCustomerDtos)
        {
            var isThereAnyUser = _usersDal.Query().Where(g => g.Status == true && g.Email == registerCustomerDtos.Email).FirstOrDefault();

            if (isThereAnyUser != null)
            {
                return new ErrorResult(Messages.NameAlreadyExist);
            }

            HashingHelper.CreatePasswordHash(registerCustomerDtos.Password, out var passwordSalt, out var passwordHash);
            var user = new Users
            {
                Email = registerCustomerDtos.Email,
                Name = registerCustomerDtos.Name,
                LastName = registerCustomerDtos.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _usersDal.Add(user);
            await _usersDal.SaveChangesAsync();

            return new SuccessResult(Messages.Added);
        }
    }
}
