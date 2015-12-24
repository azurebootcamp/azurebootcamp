using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using bootcamp.Models;
using System.Net;
using System.IO;
using System.Net.Http;

namespace bootcamp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index(string location)
        {
            LocationInfo locationInfo = null;

            if (!string.IsNullOrEmpty(location))
            {
                var url =
                    String.Format("https://github.com/punitganshani/azurebootcamp/raw/master/2016/data/locations/{0}/data.json", location.ToLowerInvariant());

                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(url))
                using (HttpContent content = response.Content)
                {                    
                    var contents = await content.ReadAsStringAsync();
                    locationInfo = JsonConvert.DeserializeObject<LocationInfo>(contents);
                }
            }

            return View(locationInfo);

        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
