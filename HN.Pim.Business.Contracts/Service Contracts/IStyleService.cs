using System;
using System.ServiceModel;
using Core.Common.Exceptions;
using HN.Pim.Business.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Common.Contracts;

namespace HN.Pim.Business.Contracts
{
    [ServiceContract]
    public interface IStyleService
    {
        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Style GetStyle(int MerretStleID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Style[] GetAllStyles();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Style[] GetPagedStyles(
            int? page,
            int? pageSize = null,
            string[] includePaths = null,
            string[] filter = null,
            string[] sortExpression = null
            //,
            //Expression<Func<Style, bool>> filter = null,
            //params ISortExpression<Style>[] sortExpression
            );

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Style UpdateStyle(Style style);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteStyle(int MerretStleID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int GetTotalOfStyles();

    }
}