﻿using Core.Utilies.Results.Abstract;
using DataAccess.Abstract;
using Entity.Concrete.MongoDbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBuildService
    {
        IDataResult<List<Build>> GetAll();
        IDataResult<Build> GetBuildById(string buildId );
        IResult Add(Build build);
        IResult Delete(string buildId);
    }
}
