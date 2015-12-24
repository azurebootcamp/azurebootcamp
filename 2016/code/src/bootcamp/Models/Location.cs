using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bootcamp.Models
{
    public class LocationInfo
    {
        public Location Location { get; set; }
        public Social Social { get; set; }
        public Registration Registration { get; set; }
        public Contact[] Contact { get; set; }
        public Sponsor[] Sponsors { get; set; }
        public Prize[] Prizes { get; set; }
        public Track[]   Agenda { get; set; }
    }

    public class Location
    {
        public string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Address { get; set; }
    } 

    public class Registration
    {
        public string Status { get; set; }
        public string Link { get; set; }
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
