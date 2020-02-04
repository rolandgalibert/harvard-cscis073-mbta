using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MBTADataFeeds
{
    public class FacilitiesQuery
    {
        public static String baseURL = "https://api-v3.mbta.com/facilities";
        public static String stopsFilter;

        public async static Task<FacilitiesJSON.Rootobject> ExecuteQuery()
        {
            FacilitiesJSON.Rootobject ro;
            HttpClient client = new HttpClient();
            string url = baseURL + stopsFilter;

            // Execute the REST API call.
            HttpResponseMessage response = await client.GetAsync(url);

            // Get the JSON response.
            string contentString = await response.Content.ReadAsStringAsync();

            // Instantiate return object 

            try
            {
                JsonTextReader reader = new JsonTextReader(new StringReader(contentString));
                JsonSerializer serializer = new JsonSerializer();
                ro = (FacilitiesJSON.Rootobject)serializer.Deserialize(reader, typeof(FacilitiesJSON.Rootobject));
                return ro;
            }
            catch (Exception ex)
            {
                //retval.Add("Exception: " + ex.ToString());
                return ro = new FacilitiesJSON.Rootobject();
            }
        }

        public static List<Facility> convertJSONToList(FacilitiesJSON.Rootobject ro)
        {
            List<Facility> newList = new List<Facility>();
            foreach (FacilitiesJSON.Datum d in ro.data)
            {
                newList.Add(new Facility(d.id, d.attributes.name, 
                    d.attributes.type, d.relationships.stop.data == null ? "" : d.relationships.stop.data.id));
                foreach (FacilitiesJSON.Property1 p in d.attributes.properties)
                {
                    newList[newList.Count - 1].addProperty(p.name, p.value);
                }
            }
            return newList;
        }

        public static void clearStopsFilter()
        {
            stopsFilter = "";
        }

        public static void addStopToFilter(String stop)
        {
            if (stopsFilter.Length == 0)
            {
                stopsFilter = "?" + "filter[stop]=" + stop;
            }
            else
            {
                stopsFilter = stopsFilter + "," + stop;
            }
        }

    }
}
