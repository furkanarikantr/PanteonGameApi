﻿using Core.DataAccess.EntityFramework.Abstract;
using Entity.Concrete.MySqlEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEfEntityRepository<User>
    {
    }
}
