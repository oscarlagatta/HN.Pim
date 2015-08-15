using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using Core.Common.Contracts;
using Core.Common.Core;

namespace HN.Pim.Business.Entities
{
    [DataContract]
    public class MenuItem : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int MenuId { get; set; }
        [DataMember]
        public int? ParentMenuId { get; set; }
        [DataMember]
        public string MenuTitle { get; set; }
        [DataMember]
        public int DisplayOrder { get; set; }
        [DataMember]
        public string MenuAction { get; set; }
        [DataMember]
        public IEnumerable<MenuItem> Menus { get; set; }

        public int EntityId
        {
            get
            {
                return MenuId;
            }

            set
            {
                MenuId =value;
            }
        }
    }
}