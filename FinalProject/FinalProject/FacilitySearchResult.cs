using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject
{
    public class FacilitySearchResult
    {
        public string stop_id { get; set; }
        public string name { get; set; }
        public FacilitySearchResult (string stop_id, string name)
        {
            this.stop_id = stop_id;
            this.name = name;
        }
    }
}
