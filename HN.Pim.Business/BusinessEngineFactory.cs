using System.ComponentModel.Composition;
using Core.Common.Contracts;
using Core.Common.Core;

namespace HN.Pim.Business
{
    [Export(typeof(IBusinessEngineFactory))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BusinessEngineFactory : IBusinessEngineFactory
    {
        public T GetBusinessEngine<T>() where T : IBusinessEngine
        {
            return ObjectBase.Container.GetExportedValue<T>();
        }
    }
}