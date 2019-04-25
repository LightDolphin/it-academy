using Ninject.Modules;
using SchoolManager.BLL.Services;
using SchoolManager.BLL.Interfaces;

namespace SchoolManager.PL.Util
{
    public class PersonModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPersonService>().To<PersonService>();
        }
    }
}