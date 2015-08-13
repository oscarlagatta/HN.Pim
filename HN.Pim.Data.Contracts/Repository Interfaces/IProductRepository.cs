using Core.Common.Contracts;
using HN.Pim.Business.Entities;

namespace HN.Pim.Data.Contracts.Repository_Interfaces
{
    public interface IProductRepository : IDataRepository<Product>
    {
        Product GetByAsin(string asinCode);
    }
}