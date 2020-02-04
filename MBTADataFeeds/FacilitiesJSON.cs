using System;
using System.Collections.Generic;
using System.Text;

namespace MBTADataFeeds.FacilitiesJSON
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
        public Stop stop { get; set; }
    }

    public class Stop
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
        public string type { get; set; }
        public Property1[] properties { get; set; }
        public string name { get; set; }
        public Nullable<float> longitude { get; set; }
        public Nullable<float> latitude { get; set; }
    }

    public class Property1
    {
        public string value { get; set; }
        public string name { get; set; }
    }
}
