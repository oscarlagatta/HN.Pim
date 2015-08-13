using System.Runtime.Serialization;
using Core.Common.Contracts;
using Core.Common.Core;

namespace HN.Pim.Business.Entities
{
    [DataContract]
    public class ResourceMaster : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int ResourceId { get; set; }

        [DataMember]
        public string Culture { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Value { get; set; }

        public int EntityId
        {
            get { return ResourceId; }
            set { ResourceId = value; }
        }
    }
}