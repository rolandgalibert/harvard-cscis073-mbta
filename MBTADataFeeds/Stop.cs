using System;
using System.Collections.Generic;
using System.Text;

namespace MBTADataFeeds
{
    public class Stop
    {
        public Stop(string id, string name, string description, float latitude, float longitude,
            string parent_station_id, string parent_station_type, int wheelchair_boarding)
        {
            this.id = id ?? "";
            this.name = name ?? "";
            this.description = description ?? "";
            this.latitude = latitude;
            this.longitude = longitude;
            this.parent_station_id = parent_station_id ?? "";
            this.parent_station_type = parent_station_type ?? "";
            this.wheelchair_boarding = wheelchair_boarding;
        }
        public string id { get; set; }
        public string parent_station_id { get; set; }
        public string parent_station_type { get; set; }
        public int wheelchair_boarding { get; set; }
        public string name { get; set; }
        public float longitude { get; set; }
        public float latitude { get; set; }
        public string description { get; set; }
    }
}
