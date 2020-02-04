using System;
using System.Collections.Generic;
using System.Text;

namespace MBTADataFeeds.StopsJSON
{
    public class Rootobject
    {
        public Links links { get; set; }
        public Datum[] data { get; set; }
    }

    public class Links
    {
        public string self { get; set; }
        public string prev { get; set; }
        public string next { get; set; }
        public string last { get; set; }
        public string first { get; set; }
    }

    public class Datum
    {
        public string type { get; set; }
        public Relationships relationships { get; set; }
        public Links2 links { get; set; }
        public string id { get; set; }
        public Attributes attributes { get; set; }
    }

    public class Relationships
    {
        public Parent_Station parent_station { get; set; }
    }

    public class Parent_Station
    {
        public Links1 links { get; set; }
        public Data data { get; set; }
    }

    public class Links1
    {
        public string self { get; set; }
        public string related { get; set; }
    }

    public class Data
    {
        public string type { get; set; }
        public string id { get; set; }
    }

    public class Links2
    {
    }

    public class Attributes
    {
        public int wheelchair_boarding { get; set; }
        public string platform_name { get; set; }
        public string platform_code { get; set; }
        public string name { get; set; }
        public float longitude { get; set; }
        public int location_type { get; set; }
        public float latitude { get; set; }
        public string description { get; set; }
        public string address { get; set; }
    }
}

