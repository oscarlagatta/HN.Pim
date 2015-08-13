using Core.Common.Core;

namespace HN.Pim.Client.Entities
{
    public class Product : ObjectBase
    {

        private int _productId;
        private string _asin;
        private string _name;
        private decimal _price;
        //private int _accountId;

        public int ProductId
        {
            get { return _productId; }
            set
            {
                if (_productId != value)
                {
                    _productId = value;
                    OnPropertyChanged(() => ProductId);
                }
            }
        }

        public string Asin
        {
            get { return _asin; }
            set
            {
                if (_asin != value)
                {
                    _asin = value;
                    OnPropertyChanged(() => Asin);
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(() => Name);
                }
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged(() => Name);
                }
            }
        }

        //public int AccountId
        //{
        //    get { return _accountId; }
        //    set
        //    {
        //        if (_accountId != value)
        //        {
        //            _accountId = value;
        //            OnPropertyChanged(() => AccountId);
        //        }
        //    }
        //}

    }

}