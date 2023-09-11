using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.MongoDb;
using DataAccess.Concrete.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TokenManager>().As<ITokenService>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<BuildManager>().As<IBuildService>();
            builder.RegisterType<BuildDal>().As<IBuildDal>();

            builder.RegisterType<BuildTypeManeger>().As<IBuildTypeService>();
            builder.RegisterType<BuildTypeDal>().As<IBuildTypeDal>();


        }
    }
}
