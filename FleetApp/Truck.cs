using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetApp
{
    internal class Truck : Vehicle, IFuelable
    {
        public double LoadCapacity { get; set; }

        public double FuelLevel { get; set; }

        public Truck()
        {
        }

        public Truck(string vin, string brand, string registrationNumber, DateTime lastInspectionDate, double loadCapacity) : base(vin, brand, registrationNumber, lastInspectionDate)
        {
            LoadCapacity = loadCapacity;
            FuelLevel = 100;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("=== CIĘŻARÓWKA ===");
            Console.WriteLine($"VIN: {Vin}");
            Console.WriteLine($"Marka: {Brand}");
            Console.WriteLine($"Rejestracja: {RegistrationNumber}");
            Console.WriteLine($"Ładowność: {LoadCapacity} t");
            Console.WriteLine($"Poziom paliwa: {FuelLevel}%");

            if (CurrentDriver != null)
            {
                Console.WriteLine($"Kierowca: {CurrentDriver}");
            }
        }

        public void Refuel()
        {
            FuelLevel = 100;

            Console.WriteLine($"Ciężarówka {RegistrationNumber} zatankowana.");
        }
    }
}
