using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using bootcamp.Models;
using System.Net;

namespace bootcamp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string location)
        {
            LocationInfo locationInfo = null;

            try {
                if (!string.IsNullOrEmpty(location))
                {
                    var url =
                        String.Format("https://github.com/punitganshani/azurebootcamp/raw/master/2016/data/locations/{0}/data.json", location.ToLowerInvariant());
                    string contents;
                    using (var wc = new System.Net.WebClient())
                        contents = wc.DownloadString(url);

                    locationInfo = JsonConvert.DeserializeObject<LocationInfo>(contents);
                }
            }
            catch(WebException ex) // some problem getting the file
            {
                locationInfo = null; //TODO: need to give a default value instead of NULL
            }

            return View(locationInfo);

        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
