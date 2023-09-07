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

        public IResult Add(Build build)
        {
            _buildDal.Insert(build);
            return new SuccessResult();
        }

        public IDataResult<List<Build>> GetAll(int userId)
        {
            var result = _buildDal.GetAll(filter: x => x.UserId == userId);
            return new SuccessDataResult<List<Build>>(result);
        }

        public IDataResult<Build> GetBuildById(string buildId, int userId)
        {
            var build = _buildDal.Get(buildId);
            if (build.UserId == userId)
            {
                return new SuccessDataResult<Build>(build);
            }
            else
            {
                return new ErrorDataResult<Build>("Yetkisiz Erişim!");
            }
            
        }
    }
}
