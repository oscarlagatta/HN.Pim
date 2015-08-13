using Core.Common.Core;

namespace HN.Pim.Client.Entities
{
    public class ResourceMaster : ObjectBase
    {
        private int _resourceId;
        private string _culture;
        private string _name;
        private string _value;

        public int ResourceId
        {
            get { return _resourceId; }
            set { _resourceId = value; }
        }

        public string Culture
        {
            get { return _culture; }
            set { _culture = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }


    }
}