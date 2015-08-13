using System.Runtime.Serialization;
using Core.Common.Contracts;
using Core.Common.Core;

namespace HN.Pim.Business.Entities
{
    [DataContract]
    public class Product : EntityBase, IIdentifiableEntity, IAccountOwnedEntity
    {
        
        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public string Asin { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public int AccountId { get; set; }

        public int EntityId
        {
            get { return ProductId; }
            set { ProductId = value; }
        }


        [DataMember]
        public int Stock { get; set; }

        public int OwnerAccountId
        {
            get { return AccountId; }
        }
    }
}