using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Http.Cors;
using Drawer.Models;

namespace Drawer.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ChartController : ApiController
    {
        [HttpGet]
        [ActionName("getpoints")]
        public HttpResponseMessage GetPoints(string id)
        {
            try
            {
                string[] listOfParams = id.Split(',');
                List<int> list = new List<int>();
                int count = int.Parse(listOfParams[0]);
                Random rand = new Random();
                for (int i = 0; i < count; i++)
                 {
                      list.Add(rand.Next(1, 99));
                 }
                Pack pack = new Pack { array = list, type = listOfParams[1] };
                 return Request.CreateResponse(HttpStatusCode.OK, pack); 
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadGateway, e.Message);
            }
        }
    }
}
