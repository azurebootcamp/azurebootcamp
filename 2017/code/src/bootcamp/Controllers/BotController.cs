using System.Linq;
using Microsoft.AspNet.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using bootcamp.Models;
using System.Collections.Generic;
using System.Globalization;

namespace bootcamp.Controllers
{
    public class BotController : Controller
    {
        public async Task<IActionResult> GetLocations(int? year)
        {
            if (year.HasValue == false)
                year = DateTime.Now.Year;

            string url = $"https://raw.githubusercontent.com/azurebootcamp/azurebootcamp-data/master/{year}/index.json";
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(url))
            using (HttpContent content = response.Content)
            {
                var contents = await content.ReadAsStringAsync();

                var locations = JsonConvert.DeserializeObject<LocationIndex>(contents).Locations.Where(x => x.Show).ToList();
                return Json(locations);
            }
        }

        public async Task<IActionResult> GetSessions(int? year, string location)
        {
            if (year.HasValue == false)
                year = DateTime.Now.Year;

            string url = $"https://github.com/punitganshani/azurebootcamp-data/raw/master/{year}/locations/{location}/data.json";
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(url))
            using (HttpContent content = response.Content)
            {
                var contents = await content.ReadAsStringAsync();
                var locationInfo = JsonConvert.DeserializeObject<LocationInfo>(contents);

                DateTime eventDate = DateTime.ParseExact(locationInfo.Event.Date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                List<BotSession> sessions = new List<Models.BotSession>();
                foreach (var track in locationInfo.Tracks)
                {
                    foreach (var current in track.Sessions)
                    {
                        if (current.Speaker == null) continue;
                        if (current.SessionId == "TBD" || current.Title == "TBD") continue;
                        if (sessions.Any(x => x.Code == current.SessionId)) continue; // avoid dupes

                        var viewSession = new BotSession();
                        viewSession.Code = current.SessionId;
                        viewSession.Name = current.Title;
                        viewSession.SessionType = track.Name.Replace("Track", string.Empty).Trim();
                        var timeRange = current.Time.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                        var start = DateTime.ParseExact(timeRange[0].Trim(), "h:mm tt", CultureInfo.InvariantCulture);
                        var end = DateTime.ParseExact(timeRange[1].Trim(), "h:mm tt", CultureInfo.InvariantCulture);
                        viewSession.DateTime_Start = new DateTime(eventDate.Year, eventDate.Month, eventDate.Day, start.Hour, start.Minute, 0);
                        viewSession.FinishDateTime =
                            new DateTime(eventDate.Year, eventDate.Month, eventDate.Day, end.Hour, end.Minute, 0).ToString("dd-MM-yyyy h:mm:ss tt");
                        viewSession.StartDateTime = viewSession.DateTime_Start.ToString("dd-MM-yyyy h:mm:ss tt");
                        viewSession.Room = current.Room;
                        viewSession.Presenters = new List<BotPresenter>();
                        viewSession.Description = current.Speaker.Description;

                        try
                        {
                            var parts = current.Speaker.Name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            viewSession.Presenters.Add(new BotPresenter
                            {
                                FirstName = parts[0],
                                LastName = parts[1]
                            });
                        }
                        catch
                        {
                            viewSession.Presenters.Add(new BotPresenter { FirstName = current.Speaker.Name });
                        }


                        sessions.Add(viewSession);
                    }
                }


                return Json(sessions);
            }
        }
    }
}