using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Web.Mvc;

namespace HN.Pim.WebUI.Core
{
    public class MefDependencyResolver : IDependencyResolver
    {
        public MefDependencyResolver(CompositionContainer container)
        {
            _Container = container;
        }

        CompositionContainer _Container;

        public object GetService(Type serviceType)
        {
            return _Container.GetExportedValueByType(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _Container.GetExportedValuesByType(serviceType);
        }
    }
}