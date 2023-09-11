using Core.DataAccess.MongoRepository;
using Entity.Concrete.MongoDbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBuildTypeDal : IRepository<BuildType>
    {
    }
}
