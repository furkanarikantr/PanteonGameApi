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
    public class BuildTypeManeger : IBuildTypeService
    {
        IBuildTypeDal _buildTypeDal;

        public BuildTypeManeger(IBuildTypeDal buildTypeDal)
        {
            _buildTypeDal = buildTypeDal;
        }

        public IResult Add(BuildType buildType)
        {
            _buildTypeDal.Insert(buildType);
            return new SuccessResult();
        }

        public IDataResult<List<BuildType>> GetAll()
        {
            var result = _buildTypeDal.GetAll();
            return new SuccessDataResult<List<BuildType>>(result);
        }
    }
}
