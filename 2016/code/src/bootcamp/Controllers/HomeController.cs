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
            if (string.IsNullOrEmpty(location) || location == "unknown")
            {
                return RedirectToAction("Locations", "Home");
            }

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

        public async Task<IActionResult> Locations()
        {
            var url = "https://github.com/punitganshani/azurebootcamp-data/raw/master/2016/index.json";

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(url))
            using (HttpContent content = response.Content)
            {
                var contents = await content.ReadAsStringAsync();
                //contents = @"{""Locations"": [""test""]}";
                return View(JsonConvert.DeserializeObject<LocationIndex>(contents));
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
