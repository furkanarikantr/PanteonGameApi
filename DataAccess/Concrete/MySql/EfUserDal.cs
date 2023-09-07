using Core.DataAccess.EntityFramework.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.MySql.Context;
using Entity.Concrete.MySqlEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.MySql
{
    public class EfUserDal : EfEntityRepositoryBase<User, MySqlContext>, IUserDal
    {
    }
}
