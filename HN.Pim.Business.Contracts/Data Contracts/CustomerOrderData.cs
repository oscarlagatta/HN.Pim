using System;
using System.Runtime.Serialization;
using Core.Common.ServiceModel;

namespace HN.Pim.Business.Contracts.Data_Contracts
{
    [DataContract]
    public class CustomerOrderData : DataContractBase
    {
        [DataMember]
        public int SalesOrderId { get; set; }

        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public DateTime DatePurchased { get; set; }
    }
}