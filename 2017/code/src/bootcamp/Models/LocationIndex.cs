using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bootcamp.Models
{
    public class LocationIndex
    {
        public LocationIndexInfo[] Locations { get; set; }
    }

    public class LocationIndexInfo
    {
        public string Name { get; set; }
        public string Folder { get; set; }
        public string WebsiteUrl { get; set; }
        public bool Show { get; set; }
    }


}
