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
                DateTime now = DateTime.Now;
                List<int> list = new List<int>();
                List<string> XLine = new List<string>();
                int count = int.Parse(listOfParams[0]);
                Random rand = new Random();
                string choosedType = listOfParams[1];
                for (int i = 0; i < count; i++)
                 {
                      list.Add(rand.Next(1, 99));
                 }
                if (choosedType == "Days")
                {
                    for (int i = 0; i < count; i++)
                    {
                        XLine.Add(now.Day + "/" + now.Month);
                        now = now.AddDays(1);
                    }
                }
                if (choosedType == "Minutes")
                {
                    for (int i = 0; i < count; i++)
                    {
                        XLine.Add(now.Hour + ":" + now.Minute);
                        now = now.AddHours(1);
                    }
                }


                Pack pack = new Pack { XLine = XLine, FirstLine = list, Type = choosedType };
                 return Request.CreateResponse(HttpStatusCode.OK, pack); 
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadGateway, e.Message);
            }
        }
    }
}
