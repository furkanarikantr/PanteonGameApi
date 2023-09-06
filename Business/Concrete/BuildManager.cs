using Business.Abstract;
using Core.Utilies.Results.Abstract;
using Core.Utilies.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete.MongoDbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BuildManager : IBuildService
    {
        IBuildDal _buildDal;

        public BuildManager(IBuildDal buildDal)
        {
            _buildDal = buildDal;
        }

        public IDataResult<List<Build>> GetAll()
        {
            var result = _buildDal.GetAll();
            return new SuccessDataResult<List<Build>>(result);
        }
    }
}
