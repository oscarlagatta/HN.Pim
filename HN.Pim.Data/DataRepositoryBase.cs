using Core.Common.Contracts;
using Core.Common.Data;

namespace HN.Pim.Data
{
    public abstract class DataRepositoryBase<T> : DataRepositoryBase<T, PimContext>
       where T : class, IIdentifiableEntity, new()
    {
    }
}