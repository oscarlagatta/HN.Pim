using Core.Common.Core;

namespace HN.Pim.Client.Entities
{
    public class Product : ObjectBase
    {

        #region All fields
        /*
        private int _productId;
        private string _name;
        private string _barCode;
        private string _asin;
        private int _stock;
        private string _country;
        private decimal _retailPrice;
        private decimal _salesPrice;
        private decimal _vat;
        private string _manufacturerName;
        private string _productBrandName;
        private string _charonBrandName;
        private string _model;
        private byte _image;
        private byte _webSiteImage;
        private string _youtubeVideo;
        private string _productDimension;
        private string _productWeight;
        private string _language;
        private string _productTitle;
        private string _productFeatures;
        private string _longDescription;
        private string _shortDescription;
        private string _materialUsed;
        private string _productType;
        private string _colour;
        private string _style;

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

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(() => Name);
            }
        }

        public string Barcode
        {
            get { return _barCode; }
            set
            {
                _barCode = value;
                OnPropertyChanged(() => Barcode);
            }
        }

        public string Asin
        {
            get { return _asin; }
            set
            {
                _asin = value;
                OnPropertyChanged(() => Asin);
            }
        }

        public int Stock
        {
            get { return _stock; }
            set
            {
                _stock = value;
                OnPropertyChanged(() => Stock);
            }
        }

        public string Country
        {
            get { return _country; }
            set
            {
                _country = value;
                OnPropertyChanged(() => Country);
            }
        }

        public decimal RetailPrice
        {
            get { return _retailPrice; }
            set
            {
                _retailPrice = value;
                OnPropertyChanged(() => RetailPrice);
            }
        }

        public decimal SalesPrice
        {
            get { return _salesPrice; }
            set
            {
                _salesPrice = value;
                OnPropertyChanged(() => SalesPrice);
            }
        }

        public decimal Vat
        {
            get { return _vat; }
            set
            {
                _vat = value;
                OnPropertyChanged(() => Vat);
            }
        }

        public string ManufacturerName
        {
            get { return _manufacturerName; }
            set
            {
                _manufacturerName = value;
                OnPropertyChanged(() => ManufacturerName);
            }
        }

        public string ProductBrandName
        {
            get { return _productBrandName; }
            set
            {
                _productBrandName = value;
                OnPropertyChanged(() => ProductBrandName);
            }
        }

        public string CharonBrandName
        {
            get { return _charonBrandName; }
            set
            {
                _charonBrandName = value;
                OnPropertyChanged(() => CharonBrandName);
            }
        }

        public string Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged(() => Model);
            }
        }

        public byte Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged(() => Image);
            }
        }

        public byte WebSiteImage
        {
            get { return _webSiteImage; }
            set
            {
                _webSiteImage = value;
                OnPropertyChanged(() => WebSiteImage);
            }
        }

        public string YoutubeVideo
        {
            get { return _youtubeVideo; }
            set
            {
                _youtubeVideo = value;
                OnPropertyChanged(() => YoutubeVideo);
            }
        }

        public string ProductDimension
        {
            get { return _productDimension; }
            set
            {
                _productDimension = value;
                OnPropertyChanged(() => ProductDimension);
            }
        }

        public string ProductWeight
        {
            get { return _productWeight; }
            set
            {
                _productWeight = value;
                OnPropertyChanged(() => ProductWeight);
            }
        }

        public string Language
        {
            get { return _language; }
            set
            {
                _language = value;
                OnPropertyChanged(() => Language);
            }
        }

        public string ProductTitle
        {
            get { return _productTitle; }
            set
            {
                _productTitle = value;
                OnPropertyChanged(() => ProductTitle);
            }
        }

        public string ProductFeatures
        {
            get { return _productFeatures; }
            set
            {
                _productFeatures = value;
                OnPropertyChanged(() => ProductFeatures);
            }
        }

        public string LongDescription
        {
            get { return _longDescription; }
            set
            {
                _longDescription = value;
                OnPropertyChanged(() => LongDescription);
            }
        }

        public string ShortDescription
        {
            get { return _shortDescription; }
            set
            {
                _shortDescription = value;
                OnPropertyChanged(() => ShortDescription);
            }
        }

        public string MaterialslUsed
        {
            get { return _materialUsed; }
            set
            {
                _materialUsed = value;
                OnPropertyChanged(() => MaterialslUsed);
            }
        }

        public string ProductType
        {
            get { return _productType; }
            set
            {
                _productType = value;
                OnPropertyChanged(() => ProductType);
            }
        }

        public string Colour
        {
            get { return _colour; }
            set
            {
                _colour = value;
                OnPropertyChanged(() => Colour);
            }
        }

        public string Style
        {
            get { return _colour; }
            set
            {
                _colour = value;
                OnPropertyChanged(() => Style);
            }
        }         */
        #endregion

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