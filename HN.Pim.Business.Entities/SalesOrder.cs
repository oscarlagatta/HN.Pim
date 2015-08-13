using Core.Common.Contracts;
using Core.Common.Core;

namespace HN.Pim.Business.Entities
{
    public class SalesOrder : EntityBase, IIdentifiableEntity, IAccountOwnedEntity
    {
        public int SalesOrderId { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }

        public int EntityId
        {
            get { return SalesOrderId; }
            set { SalesOrderId = value; }
        }

        public int OwnerAccountId
        {
            get{return AccountId;}
            set { AccountId = value; }
        }
    }
}
