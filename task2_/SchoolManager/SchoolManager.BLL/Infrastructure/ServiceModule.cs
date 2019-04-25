using Ninject.Modules;
using Ninject.Web.Common;
using SchoolManager.DAL.Interfaces;
using SchoolManager.DAL.Repositories;

namespace SchoolManager.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUoW>().To<EFUoW>().InRequestScope().WithConstructorArgument(connectionString);
        }
    }
}
