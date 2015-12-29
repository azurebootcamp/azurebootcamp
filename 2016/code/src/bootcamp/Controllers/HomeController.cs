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
using Microsoft.Extensions.OptionsModel;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using bootcamp.Utilities;

namespace bootcamp.Controllers
{
    public class HomeController : Controller
    {
        private IOptions<AppSettings> Configuration;

        public HomeController(IOptions<AppSettings> configuration)
        {
            Configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            var appSettings = Configuration.Value;
            string location = appSettings.Location;//.Get("AppSettings:Location");

           // location = Startup.Location;

            LocationInfo locationInfo = null;
            try
            {
                if (!string.IsNullOrEmpty(location))
                {
                    var url =
                        String.Format("https://github.com/punitganshani/azurebootcamp-data/raw/master/2016/locations/{0}/data.json", location.ToLowerInvariant());

                    using (HttpClient client = new HttpClient())
                    using (HttpResponseMessage response = await client.GetAsync(url))
                    using (HttpContent content = response.Content)
                    {
                        var contents = await content.ReadAsStringAsync();

                        locationInfo = JsonConvert.DeserializeObject<LocationInfo>(contents);
                    }
                }

            }
            catch
            {
                return RedirectToAction("Error");
            }

            return View(locationInfo);

        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
