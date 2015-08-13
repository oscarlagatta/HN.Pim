using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core.Common.Contracts;
using HN.Pim.Client.Contracts;
using HN.Pim.Client.Entities;
using HN.Pim.WebUI.Core;
using HN.Pim.WebUI.Models;

namespace HN.Pim.WebUI.Controllers.API
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/culturecountrycode")]
    [UsesDisposableService]
    public class CultureCountryCodeApiController : ApiControllerBase
    {
         [ImportingConstructor]
        public CultureCountryCodeApiController(ICultureCountryCodeService cultureCountryCodeService)
        {
            _cultureCountryCodeService = cultureCountryCodeService;
        }

         ICultureCountryCodeService _cultureCountryCodeService;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_cultureCountryCodeService);
        }

        [HttpPost]
        [Route("availableculturecountrycodes")]
        public HttpResponseMessage GetAvailableProducts(HttpRequestMessage request, [FromBody]AccountRegisterModel accountModel)
        {
            return GetHttpResponse(request, () =>
            {
                CultureCountryCode[] cultureCountryCodes = _cultureCountryCodeService.GetAllCultureCountryCode();

                return request.CreateResponse<CultureCountryCode[]>(HttpStatusCode.OK, cultureCountryCodes);
            });
        }
    }
}
