using System.ComponentModel.Composition;
using Core.Common.ServiceModel;
using HN.Pim.Client.Contracts;
using HN.Pim.Client.Entities;

namespace HN.Pim.Client.Proxies
{

    [Export(typeof(ICultureCountryCodeService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CultureCountryCodeClient : UserClientBase<ICultureCountryCodeService>, ICultureCountryCodeService
    {
        public CultureCountryCode GetCultureCountryCode(int cultureCountryCodeId)
        {
            return Channel.GetCultureCountryCode(cultureCountryCodeId);
        }

        public CultureCountryCode[] GetAllCultureCountryCode()
        {
            return Channel.GetAllCultureCountryCode();
        }

        public CultureCountryCode UpdateCultureCountryCode(CultureCountryCode cultureCountryCode)
        {
            return Channel.UpdateCultureCountryCode(cultureCountryCode);
        }

        public void DeleteCultureCountryCode(int cultureCountryCodeId)
        {
            Channel.DeleteCultureCountryCode(cultureCountryCodeId);
        }
    }
}