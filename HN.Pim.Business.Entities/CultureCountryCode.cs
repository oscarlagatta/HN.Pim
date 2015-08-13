using System.Runtime.Serialization;
using Core.Common.Contracts;
using Core.Common.Core;

namespace HN.Pim.Business.Entities
{
    public class CultureCountryCode : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string TwoLetterCountryCode { get; set; }

        [DataMember]
        public string ThreeLetterCountryCode { get; set; }

        [DataMember]
        public string Language { get; set; }

        [DataMember]
        public string TwoLetterLangCode { get; set; }

        [DataMember]
        public string ThreeLetterLangCode { get; set; }

        [DataMember]
        public string CultureInfoCode { get; set; }

        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }

    }
}