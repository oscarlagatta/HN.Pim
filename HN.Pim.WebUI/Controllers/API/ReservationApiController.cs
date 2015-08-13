using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core.Common.Contracts;
using HN.Pim.Client.Contracts;
using HN.Pim.Client.Entities;
using HN.Pim.WebUI.Core;

namespace HN.Pim.WebUI.Controllers.API
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Authorize]
    [RoutePrefix("api/reservation")]
    [UsesDisposableService]
    public class ReservationApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public ReservationApiController(IProductService productService)
        {
            _ProductService = productService;
        }

        IProductService _ProductService;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_ProductService);
        }

        [HttpGet]
        [Route("availablecars/{pickupDate}/{returnDate}")]
        public HttpResponseMessage GetAvailableCars(HttpRequestMessage request, DateTime pickupDate, DateTime returnDate)
        {
            return GetHttpResponse(request, () =>
            {
                Product[] products = _ProductService.GetAllProducts();
                
                //Car[] cars = _ProductService.GetAvailableCars(pickupDate, returnDate);

                return request.CreateResponse<Product[]>(HttpStatusCode.OK, products);
            });
        }
    }
}
