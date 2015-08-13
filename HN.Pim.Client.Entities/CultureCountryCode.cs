
using Core.Common.Core;

namespace HN.Pim.Client.Entities
{
    public class CultureCountryCode : ObjectBase
    {

        private int _id;
        private string _country;
        private string _twoLetterCountryCode;
        private string _threeLetterCountryCode;
        private string _language;
        private string _twoLetterLangCode;
        private string _threeLetterLangCode;
        private string _cultureInfoCode;
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(() => Id);
                }
            }
        }

        public string Country
        {
            get { return _country; }
            set
            {
                if (_country != value)
                {
                    _country = value;
                    OnPropertyChanged(() => Country);
                }
            }
        }

        public string TwoLetterCountryCode
        {
            get { return _twoLetterCountryCode; }
            set
            {
                if (_twoLetterCountryCode != value)
                {
                    _twoLetterCountryCode = value;
                    OnPropertyChanged(() => TwoLetterCountryCode);
                }
            }
        }

        public string ThreeLetterCountryCode
        {
            get { return _threeLetterCountryCode; }
            set
            {
                if (_threeLetterCountryCode != value)
                {
                    _threeLetterCountryCode = value;
                    OnPropertyChanged(() => ThreeLetterCountryCode);
                }
            }
        }

        public string Language
        {
            get { return _language; }
            set
            {
                if (_language != value)
                {
                    _language = value;
                    OnPropertyChanged(() => Language);
                }
            }
        }

        public string TwoLetterLangCode
        {
            get { return _twoLetterLangCode; }
            set
            {
                if (_twoLetterLangCode != value)
                {
                    _twoLetterLangCode = value;
                    OnPropertyChanged(() => TwoLetterLangCode);
                }
            }
        }

        public string ThreLetterLangCode
        {
            get { return _threeLetterLangCode; }
            set
            {
                if (_threeLetterLangCode != value)
                {
                    _threeLetterLangCode = value;
                    OnPropertyChanged(() => ThreLetterLangCode);
                }
            }
        }
        public string CultureInfoCode
        {
            get { return _cultureInfoCode; }
            set
            {
                if (_cultureInfoCode != value)
                {
                    _cultureInfoCode = value;
                    OnPropertyChanged(() => CultureInfoCode);
                }
            }
        }

    }
}