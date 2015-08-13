using System.Runtime.Serialization;
using Core.Common.Contracts;
using Core.Common.Core;

namespace HN.Pim.Business.Entities
{
    [DataContract]
    public class Product : EntityBase, IIdentifiableEntity, IAccountOwnedEntity
    {
        #region all fields
        /*
        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Barcode { get; set; }

        [DataMember]
        public string Asin { get; set; }

        [DataMember]
        public int Stock { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public decimal RetailPrice { get; set; }

        [DataMember]
        public decimal SalesPrice { get; set; }

        [DataMember]
        public decimal Vat { get; set; }

        [DataMember]
        public string ManufacturerName { get; set; }

        [DataMember]
        public string ProductBrandName { get; set; }

        [DataMember]
        public string CharonBrandName { get; set; }

        [DataMember]
        public string Model { get; set; }

        [DataMember]
        public byte Image { get; set; }

        [DataMember]
        public byte WebSiteImage { get; set; }

        [DataMember]
        public string YoutubeVideo { get; set; }

        [DataMember]
        public string ProductDimension { get; set; }

        [DataMember]
        public string ProductWeight { get; set; }

        [DataMember]
        public string Language { get; set; }

        [DataMember]
        public string ProductTitle { get; set; }

        [DataMember]
        public string ProductFeatures { get; set; }

        [DataMember]
        public string LongDescription { get; set; }

        [DataMember]
        public string ShortDescription { get; set; }

        [DataMember]
        public string MaterialslUsed { get; set; }

        [DataMember]
        public string ProductType { get; set; }

        [DataMember]
        public string Colour { get; set; }

        [DataMember]
        public string Style { get; set; }

         */
        #endregion

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