using Business.Abstract;
using Core.Dtos;
using Core.Utilies.Results.Abstract;
using Core.Utilies.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete.MySqlEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        ITokenService _tokenService;
        public UserManager(IUserDal userDal, ITokenService tokenService)
        {
            _userDal = userDal;
            _tokenService = tokenService;
        }

        public IResult Authenticate(string username, string password)
        {
            var user = _userDal.Get(filter: x => x.Password == password && x.UserName == username);

            if (user == null)
                return null;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                 new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),

            };
            var accessToken = _tokenService.GenerateAccessToken(claims);
            //var refreshToken = _tokenService.GenerateRefreshToken();

            //user.RefreshToken = refreshToken;
            //user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            _userDal.Update(user);

            return new SuccessDataResult<AuthenticateDto>(new AuthenticateDto
            {
                Token = accessToken,
            });
        }

        public IDataResult<List<User>> GetList()
        {
            var result = _userDal.List();
            return new SuccessDataResult<List<User>>(result);
        }

        public IDataResult<User> GetUserById(int userId)
        {
            var result = _userDal.Get(filter: u => u.UserId == userId);
            return new SuccessDataResult<User>(result);
        }
    }
}
