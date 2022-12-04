using DictionaryLibrary;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Web.Common;

namespace lab3.DependencyInjection
{
    public class Ninject : NinjectModule
    {
        public override void Load() 
        {
            //Bind<IRepository<DictionaryItem>>().To<DBRepository.DBRepository>().InTransientScope();
            //Bind<IRepository<DictionaryItem>>().To<DBRepository.DBRepository>().InThreadScope();
            Bind<IRepository<DictionaryItem>>().To<DBRepository.DBRepository>().InRequestScope();

        }
    }
}