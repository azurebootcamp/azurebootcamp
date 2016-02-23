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
        public async Task<IActionResult> Index(string proxyUrl = "https://github.com/punitganshani/azurebootcamp-data/raw/master/2016/locations/{0}/data.json")
        {
            var appSettings = Configuration.Value;
            string location = appSettings.Location;

            LocationInfo locationInfo = null;
            try
            {
                if (!string.IsNullOrEmpty(location))
                {
                    var url = String.Format(proxyUrl, location.ToLowerInvariant());
                    var uri = new Uri(url);
                    bool isLocalFile = uri.IsFile;

                    if (!isLocalFile)
                    {
                        using (HttpClient client = new HttpClient())
                        using (HttpResponseMessage response = await client.GetAsync(url))
                        using (HttpContent content = response.Content)
                        {
                            var contents = await content.ReadAsStringAsync();
                            locationInfo = JsonConvert.DeserializeObject<LocationInfo>(contents);
                        }

                    }
                    else
                    {
                        if (System.IO.File.Exists(url))
                        {
                            var contents = System.IO.File.ReadAllText(url);
                            locationInfo = JsonConvert.DeserializeObject<LocationInfo>(contents);
                        }
                        else
                        {
                            throw new FileNotFoundException("File not found at: " + url);
                        }
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

        public IActionResult Verify()
        {
            return View();
        }

        [HttpPost]
        [CustomExceptionFilter]
        public IActionResult VerifyJSON(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("No JSON entered by user");

            try
            {
                var locationInfo = JsonConvert.DeserializeObject<LocationInfo>(value);
                if (locationInfo == null)
                    throw new InvalidOperationException("Could not parse JSON");

                return View("Index", locationInfo);
            }
            catch
            {
                throw;
            }
        }
    }
}
