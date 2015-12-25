﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootcamp.Models
{
    public class LocationInfo
    {
        public Location Location { get; set; }
        public Social Social { get; set; }
        public Callout Callout { get; set; }
        public Contact[] Organizers { get; set; }
        public Sponsor[] Sponsors { get; set; }
        public Prize[] Prizes { get; set; }
        public Track[] Tracks { get; set; }

        public static Dictionary<string, List<Session>> ToTimeWiseTracks(Track[] Tracks)
        {
            var output = new Dictionary<string, List<Session>>();
            if (Tracks == null)
                return output;

            var distinctTime = Tracks.SelectMany(x => x.Sessions.Select(y => y.Time)).Distinct();

            foreach (var time in distinctTime)
            {
                var sessions = Tracks.SelectMany(x => x.Sessions.Where(y => y.Time.Equals(time)));
                output.Add(time, sessions.ToList());
            }

            return output;
        }
    }

    public class Location
    {
        public string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Address { get; set; }
    }

    public class Callout
    {
        public string Link { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
    }
    public class Track
    {
        public string Name { get; set; }
        public Session[] Sessions { get; set; }
    }

    public class Session
    {
        public string Time { get; set; }
        public string Title { get; set; }
        public Speaker Speaker { get; set; }
    }

    public class Speaker
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public Social Social { get; set; }

        public string UniqueId()
        {
            return Name.RemoveSpecialCharacters();
        }
    }

    public class Contact
    {
        public string Name { get; set; }
        public Social Social { get; set; }
    }

    public class Sponsor
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
    }

    public class Prize
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Link { get; set; }
    }



    public class Social
    {
        public string Twitter { get; set; }
        public string Meetup { get; set; }
        public string Facebook { get; set; }
        public string Google { get; set; }
        public string Website { get; set; }

        public string Email { get; set; }

    }
}
