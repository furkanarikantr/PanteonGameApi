using Core.Utilies.Results.Abstract;
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
        IDataResult<List<Build>> GetAll(int userId);
        IDataResult<Build> GetBuildById(string buildId,int userId);
        IResult Add(Build build);
    }
}
