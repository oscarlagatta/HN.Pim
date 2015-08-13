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
    
    //[Authorize]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/product")]
    [UsesDisposableService]
    public class ProductApiController : ApiControllerBase
    {

         [ImportingConstructor]
        public ProductApiController(IProductService productService)
        {
            _ProductService = productService;
        }

        IProductService _ProductService;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_ProductService);
        }

        [HttpPost]
        [Route("availableproducts")]
        public HttpResponseMessage GetAvailableProducts(HttpRequestMessage request, [FromBody]AccountRegisterModel accountModel)
        {
            return GetHttpResponse(request, () =>
            {
                Product[] products = _ProductService.GetAllProducts();

                return request.CreateResponse<Product[]>(HttpStatusCode.OK, products);
            });
        }
    }
}
