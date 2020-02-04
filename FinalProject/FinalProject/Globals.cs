using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using MBTADataFeeds;

namespace FinalProject
{
    class Globals
    {
        public static List<Facility> facilities;
        public static List<Stop> stops;

        public static Location MyLocation;
        public static double LatitudeDefault = 0;
        public static double LongitudeDefault = 0;
        public static String SearchLatitude = "";
        public static String SearchLongitude = "";
        public static String SearchRadius = "";

        public static String LatitudeBraintree = "42.2073";
        public static String LongitudeBraintree = "-71.0014";
        public static String LatitudeAlewife = "42.3954";
        public static String LongitudeAlewife = "-71.1425";
        public static String LatitudeHarvardSquare = "42.3736";
        public static String LongitudeHarvardSquare = "-71.1190";
        public static String LatitudeCopleySquare = "42.3431969605";
        public static String LongitudeCopleySquare = "-71.0726130429";
        public static String LatitudeFramingham = "42.276389";
        public static String LongitudeFramingham = "-71.418333";

        public static Dictionary<string, string> stopIDToNameDictionary;
    }
}
