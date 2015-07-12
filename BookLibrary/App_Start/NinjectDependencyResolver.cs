using BookLibrary.Repositories.Abstract;
using BookLibrary.Repositories.Repositories;
using BookLibrary.Service.Abstract;
using BookLibrary.Service.Services;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookLibrary.App_Start
{

    public class NinjectDependencyResolver : DefaultControllerFactory, IDependencyResolver
    {

        private IKernel ninjectKernel;

        public NinjectDependencyResolver()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return ninjectKernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return ninjectKernel.GetAll(serviceType);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IBookRepository>().To<BookRepository>().InRequestScope();
            ninjectKernel.Bind<IBookService>().To<BookService>().InRequestScope();

        }

    }

}