using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core.Common.Contracts;
using HN.Pim.Client.Contracts;
using HN.Pim.WebUI.Core;

namespace HN.Pim.WebUI.Controllers.API
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/resourcemaster")]
    public class ResourceMasterApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public ResourceMasterApiController(IResourceMasterService resourceMasterService)
        {
            _ResourceMasterService = resourceMasterService;
        }

        IResourceMasterService _ResourceMasterService;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_ResourceMasterService);
        }

        [HttpGet]
        [Route("availableresourcemaster")]
        public HttpResponseMessage GetAvailableResourceMaster(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                string[] resourcesMasters = _ResourceMasterService.GetAvailableMasterResources();

                return request.CreateResponse<string[]>(HttpStatusCode.OK, resourcesMasters);
            });
        }


    }
}
