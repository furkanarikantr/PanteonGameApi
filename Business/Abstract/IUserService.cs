using Core.Utilies.Results.Abstract;
using Entity.Concrete.MySqlEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetList();
        IDataResult<User> GetUserById(int userId);

        IResult AddUser(User user);

        IResult Authenticate(string username, string password);
    }
}
