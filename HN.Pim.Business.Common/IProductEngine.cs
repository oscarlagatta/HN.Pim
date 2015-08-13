using System;
using System.Collections.Generic;
using Core.Common.Contracts;
using HN.Pim.Business.Entities;

namespace HN.Pim.Business.Common
{
    public interface IProductEngine : IBusinessEngine
    {
        bool isProductAvailable(int productId, DateTime createdOn, DateTime currentDateTime,
            IEnumerable<Product> products);

        bool isProductAvailable(int productId);

        bool isProductCurrentlyReserved(int productId);

        bool isProductCurrentlyDispatched(int productId);
    }
}