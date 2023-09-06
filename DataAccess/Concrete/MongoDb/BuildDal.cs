using Core.Settings;
using DataAccess.Abstract;
using Entity.Concrete.MongoDbEntities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.MongoDb
{
    public class BuildDal : MongoRepositoryBase<Build>, IBuildDal
    {
        public BuildDal(IOptions<MongoSettings> settings) : base(settings)
        {
        }
    }
}
