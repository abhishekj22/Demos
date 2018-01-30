using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ThinClient.Controllers
{
    using Sales;
    using System.ServiceModel;

    public class OrderInput
    {
        public string CustomerId { get; set; }

        public int ProductNo { get; set; }

        public int Quantity { get; set; }   
    }

    [RoutePrefix("sales")]
    public class OrderManagerController : ApiController
    {
        [Route("order")]
        public IHttpActionResult Post(OrderInput input)
        {
            try
            {
                using (var service = new ChannelFactory<IOrderManager>(new NetTcpBinding(), "net.tcp://localhost:4014/sales/ordermanager"))
                {
                    IOrderManager client = service.CreateChannel();
                    int orderNo = client.AcceptOrder(input.CustomerId, input.ProductNo, input.Quantity);
                    return Ok(orderNo);
                }
            }
            catch(Exception)
            {
                return InternalServerError(new ApplicationException("Invalid order input"));
            }
        }
    }
}
