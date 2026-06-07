using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetApp
{
    internal static class FleetStatistics
    {
        public static void ShowVehicleCount<T>(Fleet<T> fleet) where T : Vehicle
        {
            Console.WriteLine($"Liczba pojazdów: {fleet.GetVehicles().Count}");
        }
    }
}
