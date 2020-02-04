using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FinalProject
{
    class Utilities
    {
        public async static Task<Location> GetMyLocation()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    return location;
                }
                else
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.Low, TimeSpan.FromMilliseconds(10000));
                    location = await Geolocation.GetLocationAsync(request);
                    return location;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                return null;
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                return null;
            }
            catch (Exception ex)
            {
                // Unable to get location
                return null;
            }
        }
    }
}
