using System;
using System.Runtime.Serialization;
using Core.Common.Contracts;
using Core.Common.Core;

namespace HN.Pim.Business.Entities
{
    [DataContract]
    public class Style : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int MerretStyleID { get; set; }
        [DataMember]
        public string MerretDescription { get; set; }
        [DataMember]
        public Nullable<int> DeliveryInfoID { get; set; }

        //[DataMember]
        //public virtual DeliveryInfo DeliveryInfo { get; set; }

        #region Commented code
        //[DataMember]
        //public Nullable<int> DepartmentID { get; set; }
        //[DataMember]
        //public string BrandID { get; set; }
        //[DataMember]
        //public string WebAttribute1 { get; set; }
        //[DataMember]
        //public string WebAttribute2 { get; set; }
        //[DataMember]
        //public string WebAttribute3 { get; set; }
        //[DataMember]
        //public string WebAttribute4 { get; set; }
        //[DataMember]
        //public string WebAttribute5 { get; set; }
        //[DataMember]
        //public string WebAttribute6 { get; set; }
        //[DataMember]
        //public string WebAttribute7 { get; set; }
        //[DataMember]
        //public string WebAttribute8 { get; set; }
        //[DataMember]
        //public string WebAttribute9 { get; set; }
        //[DataMember]
        //public string WebAttribute10 { get; set; }
        //[DataMember]
        //public string ShortWebDescription { get; set; }
        //[DataMember]
        //public string LongWebDescription { get; set; }
        //[DataMember]
        //public Nullable<int> StyleTemplateID { get; set; }
        //[DataMember]
        //public bool Live { get; set; }
        //[DataMember]
        //public Nullable<decimal> MinPrice { get; set; }
        //[DataMember]
        //public Nullable<decimal> MaxPrice { get; set; }
        //[DataMember]
        //public Nullable<bool> OverrideMerretVAT { get; set; }
        //[DataMember]
        //public Nullable<decimal> VAT { get; set; }
        //[DataMember]
        //public Nullable<int> StyleType { get; set; }
        //[DataMember]
        //public string ExtendedProductDetail { get; set; }
        //[DataMember]
        //public Nullable<short> GradeID { get; set; }
        //[DataMember]
        //public Nullable<bool> HasImage { get; set; }
        //[DataMember]
        //public int BucketID { get; set; }
        //[DataMember]
        //public string Season { get; set; }
        //[DataMember]
        //public string WebApplicable { get; set; }
        //[DataMember]
        //public Nullable<bool> IsMatrix { get; set; }
        //[DataMember]
        //public bool IsHamper { get; set; }
        //[DataMember]
        //public bool HasGiftBox { get; set; }
        //[DataMember]
        //public Nullable<bool> EnabledMagento { get; set; }
        //[DataMember]
        //public bool MarkedDown { get; set; }
        //[DataMember]
        //public Nullable<int> MagentoID { get; set; }
        //[DataMember]
        //public Nullable<int> MaxItemsBasket { get; set; }
        //[DataMember]
        //public Nullable<bool> IsCategoryDirty { get; set; }
        //[DataMember]
        //public string EditorsView { get; set; }
        //[DataMember]
        //public Nullable<bool> InStoreOnly { get; set; }
        //[DataMember]
        //public Nullable<bool> GroupColourOptions { get; set; }
        //[DataMember]
        //public Nullable<bool> IsSeasonal { get; set; }
        //[DataMember]
        //public Nullable<int> SizeGuideID { get; set; }
        //[DataMember]
        //public Nullable<int> DeliveryInfoID { get; set; }
        //[DataMember]
        //public Nullable<int> MerchandiseBrandID { get; set; }
        //[DataMember]
        //public bool IsDirty { get; set; }
        //[DataMember]
        //public bool IsMerretDirty { get; set; }
        //[DataMember]
        //public bool Over18Only { get; set; }
        //[DataMember]
        //public Nullable<decimal> MagentoPrice { get; set; }
        //[DataMember]
        //public Nullable<int> TaxClassID { get; set; }
        //[DataMember]
        //public string FamilyBusiness { get; set; }
        //[DataMember]
        //public Nullable<bool> IsFashion { get; set; }
        //[DataMember]
        //public Nullable<System.DateTime> LastImportedDate { get; set; }
        //[DataMember]
        //public bool ImportedToGAE { get; set; }
        //[DataMember]
        //public bool ImageImportedToGAE { get; set; }
        //[DataMember]
        //public Nullable<System.DateTime> FirstEnabled { get; set; }
        //[DataMember]
        //public Nullable<bool> IsMerretMatrix { get; set; }
        //[DataMember]
        //public Nullable<bool> IsColourOnly { get; set; }
        //[DataMember]
        //public Nullable<bool> InconsistentPrice { get; set; }
        //[DataMember]
        //public string ProductLink { get; set; }
        //[DataMember]
        //public Nullable<bool> AutomaticStock { get; set; }
        //[DataMember]
        //public Nullable<bool> ProductLinkingDone { get; set; }
        //[DataMember]
        //public Nullable<System.DateTime> RequestedGoLiveDate { get; set; }
        //[DataMember]
        //public string EmailWhenLive { get; set; }
        //[DataMember]
        //public Nullable<bool> ClickToPurchase { get; set; }
        //[DataMember]
        //public int VersionNumber { get; set; }
        //[DataMember]
        //public Nullable<bool> StyledWith { get; set; }
        //[DataMember]
        //public string PIMStyleID { get; set; }
        //[DataMember]
        //public Nullable<bool> ClickTry { get; set; }
        //[DataMember]
        //public Nullable<bool> IncludeInFeed { get; set; }
        //[DataMember]
        //public Nullable<int> SizeTypeID { get; set; }

        #endregion

        public int EntityId
        {
            get { return MerretStyleID; }
            set { MerretStyleID = value; }
        }
    }
}