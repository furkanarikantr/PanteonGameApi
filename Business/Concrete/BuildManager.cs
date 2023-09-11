using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Utilies.Results.Abstract;
using Core.Utilies.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete.MongoDbEntities;
using FluentValidation;
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
            var context = new ValidationContext<Build>(build);
            BuildValidator validator = new BuildValidator();
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                var errorMessage = result.Errors.Select(e => e.ErrorMessage).ToList();
                return new ErrorResult(string.Join(" - ", errorMessage));
            }
            _buildDal.Insert(build);
            return new SuccessResult();
        }

        public IResult Delete(string buildId)
        {
            _buildDal.Delete(buildId);
            return new SuccessResult("silindi");
        }

        public IDataResult<List<Build>> GetAll()
        {
            var result = _buildDal.GetAll();
            return new SuccessDataResult<List<Build>>(result);
        }

        public IDataResult<Build> GetBuildById(string buildId)
        {
            var build = _buildDal.Get(buildId);
            return new SuccessDataResult<Build>(build);
        }
    }
}
