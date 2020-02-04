using System;
using System.Collections.Generic;
using System.Text;

namespace MBTADataFeeds
{
    public class Facility
    {
        public Facility(string id, string name, string type, string stop_id)
        {
            this.id = id ?? "";
            this.name = name ?? "";
            this.type = type ?? "";
            this.stop_id = stop_id ?? "";
            this.properties = new List<string[]>();
        }
        public void addProperty(string key, string value)
        {
            string [] newProperty = new string[2];
            newProperty[0] = key;
            newProperty[1] = value;
            this.properties.Add(newProperty);
        }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string stop_id { get; set; }
        public List<string[]> properties { get; set; }
        public Boolean isBikeStorage()
        {
            return type.Equals("BIKE_STORAGE");
        }
        public Boolean isParkingArea()
        {
            return type.Equals("PARKING_AREA");
        }
        public Boolean isElectricCarChargingFacility()
        {
            return type.Equals("ELECTRIC_CAR_CHARGERS");
        }
        public Boolean isFarePurchaseFacility()
        {
            return type.Equals("FARE_MEDIA_ASSISTANCE_FACILITY")
                || type.Equals("FARE_MEDIA_ASSISTANT")
                || type.Equals("FARE_VENDING_MACHINE")
                || type.Equals("FARE_VENDING_RETAILER")
                || type.Equals("TICKET_WINDOW");
        }
    }
}
