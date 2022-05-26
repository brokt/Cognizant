namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {

        TAccessToken CreateToken<TAccessToken>(int userId, string fullName)
           where TAccessToken : IAccessToken, new();
    }
}
