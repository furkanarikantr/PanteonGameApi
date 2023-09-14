using Business.Abstract;
using Business.Constants.BusinessMessages;
using Business.ValidationRules.FluentValidation;
using Core.Dtos;
using Core.Utilies.Results.Abstract;
using Core.Utilies.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete.MongoDbEntities;
using Entity.Concrete.MySqlEntities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public IResult AddUser(User user)
        {
            var context = new ValidationContext<User>(user);
            UserValidator validator = new UserValidator();

            var resultValidator = validator.Validate(context);
            if (!resultValidator.IsValid)
            {
                var errorMessage = resultValidator.Errors.Select(e => e.ErrorMessage).ToList();
                return new ErrorResult(string.Join(" - ", errorMessage));
            }

            if (CheckIfUsernameAlreadyTaken(user.UserName).Success && CheckIfEmailAlreadyTaken(user.Email).Success)
            {
                _userDal.Insert(user);
                return new SuccessResult(UserBusinessRulesMessages.UserAccepted);
            }
            else if (CheckIfUsernameAlreadyTaken(user.UserName).Success == false && CheckIfEmailAlreadyTaken(user.Email).Success == true)
            {
                return new ErrorResult(UserBusinessRulesMessages.CheckIfUsernameAlreadyTaken);
            }
            else if (CheckIfEmailAlreadyTaken(user.Email).Success == false && CheckIfUsernameAlreadyTaken(user.UserName).Success == true)
            {
                return new ErrorResult(UserBusinessRulesMessages.CheckIfEmailAlreadyTaken);
            }
            else
            {
                return new ErrorResult(UserBusinessRulesMessages.CheckIfUsernameAlreadyTaken + " - " + UserBusinessRulesMessages.CheckIfEmailAlreadyTaken);
            }
        }

        public IResult Authenticate(string username, string password)
        {
            var user = _userDal.Get(filter: x => x.Password == password && x.UserName == username);

            if (CheckIfUsernameAndPasswordIsTrue(username, password).Success)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                };

                var accessToken = _tokenService.GenerateAccessToken(claims);
                _userDal.Update(user);

                return new SuccessDataResult<AuthenticateDto>(new AuthenticateDto
                {
                    Token = accessToken,
                }, UserBusinessRulesMessages.CheckIfUsernameAndPasswordIsTrue);
            }

            return new ErrorResult(UserBusinessRulesMessages.CheckIfUsernameAndPasswordIsFalse);


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

        //BusinessRules
        private IResult CheckIfUsernameAlreadyTaken(string userName)
        {
            var users = _userDal.List(filter: u => u.UserName == userName).ToList();
            if (users.Count != 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IResult CheckIfEmailAlreadyTaken(string email)
        {
            var users = _userDal.List(filter: u => u.Email == email).ToList();
            if (users.Count != 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IResult CheckIfUsernameAndPasswordIsTrue(string username, string password)
        {
            var user = _userDal.List(filter: u => u.UserName == username && u.Password == password).FirstOrDefault();

            if (user == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
