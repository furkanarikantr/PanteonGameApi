using Core.Utilies.Results.Abstract;
using Entity.Concrete.MongoDbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBuildTypeService
    {
        IDataResult<List<BuildType>> GetAll();

        IResult Add(BuildType buildType);
    }
}
