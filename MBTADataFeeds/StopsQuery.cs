using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MBTADataFeeds
{
    public class StopsQuery
    {
        public static String baseURL = "https://api-v3.mbta.com/stops";
        public static String queryFilter;

        public async static Task<StopsJSON.Rootobject> ExecuteQuery()
        {
            StopsJSON.Rootobject ro;
            HttpClient client = new HttpClient();
            string url = baseURL + queryFilter;
            // Execute the REST API call.
            // HttpResponseMessage response = await client.GetAsync(baseURL + queryFilter);
            HttpResponseMessage response = await client.GetAsync(url);
            // Get the JSON response.
            string contentString = await response.Content.ReadAsStringAsync();

            // Instantiate return object 

            try
            {
                JsonTextReader reader = new JsonTextReader(new StringReader(contentString));
                JsonSerializer serializer = new JsonSerializer();
                ro = (StopsJSON.Rootobject)serializer.Deserialize(reader, typeof(StopsJSON.Rootobject));
                return ro;
            }
            catch (Exception ex)
            {
                //retval.Add("Exception: " + ex.ToString());
                return ro = new StopsJSON.Rootobject();
            }
        }

        public static List<Stop> convertJSONToList(StopsJSON.Rootobject ro)
        {
            List<Stop> newList = new List<Stop>();
            Stop newStop;
            foreach (StopsJSON.Datum d in ro.data)
            {
                newStop = new Stop(d.id, d.attributes.name, d.attributes.description,
                    d.attributes.latitude, d.attributes.longitude,
                    d.relationships.parent_station.data == null? "" : d.relationships.parent_station.data.id,
                    d.relationships.parent_station.data == null ? "" : d.relationships.parent_station.data.type,
                    d.attributes.wheelchair_boarding);
                newList.Add(newStop);
            }
            return newList;
        }

        public static void clearQueryFilter()
        {
            queryFilter = "";
        }

        public static void addLatitudeFilter(String latitude)
        {
            if (queryFilter.Length == 0)
            {
                queryFilter = "?" + "filter[latitude]=" + latitude;
            } else
            {
                queryFilter = queryFilter + "&filter[latitude]=" + latitude;
            }
        }

        public static void addLongitudeFilter(String longitude)
        {
            if (queryFilter.Length == 0)
            {
                queryFilter = "?" + "filter[longitude]=" + longitude;
            }
            else
            {
                queryFilter = queryFilter + "&filter[longitude]=" + longitude;
            }
        }

        public static void addRadiusFilter(String radiusInMiles)
        {
            if (queryFilter.Length == 0)
            {
                queryFilter = "?" + "filter[radius]=" + MBTADegreeRadius(radiusInMiles);
            }
            else
            {
                queryFilter = queryFilter + "&filter[radius]=" + MBTADegreeRadius(radiusInMiles);
            }
        }

        private static String MBTADegreeRadius(String radiusInMiles)
        {
            switch (radiusInMiles)
            {
                case "1":
                    return "0.02";
                case "1.5":
                    return "0.03";
                case "2":
                    return "0.04";
                case "5":
                    return "0.10";
                case "10":
                    return "0.20";
                default:
                    return "0.01";
            }
        }

    }
}
