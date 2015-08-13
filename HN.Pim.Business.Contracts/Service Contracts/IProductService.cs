using System;
using System.ServiceModel;
using Core.Common.Exceptions;
using HN.Pim.Business.Entities;

namespace HN.Pim.Business.Contracts
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Product GetProduct(int productId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Product[] GetAllProducts();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Product UpdateProdcut(Product product);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteProduct(int ProductId);

        Product[] GetAvailableProducts(DateTime pickupDate, DateTime returnDate);
    }
}