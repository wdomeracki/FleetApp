using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetApp
{
    internal class Car : Vehicle, IFuelable
    {
        public int Seats { get; set; }

        public double FuelLevel { get; set; }

        public Car()
        {
        }

        public Car(string vin, string brand, string registrationNumber, DateTime lastInspectionDate, int seats) : base(vin, brand, registrationNumber, lastInspectionDate)
        {
            Seats = seats;
            FuelLevel = 100;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("=== SAMOCHÓD ===");
            Console.WriteLine($"VIN: {Vin}");
            Console.WriteLine($"Marka: {Brand}");
            Console.WriteLine($"Rejestracja: {RegistrationNumber}");
            Console.WriteLine($"Liczba miejsc: {Seats}");
            Console.WriteLine($"Poziom paliwa: {FuelLevel}%");

            if (CurrentDriver != null)
            {
                Console.WriteLine($"Kierowca: {CurrentDriver}");
            }
        }

        public void Refuel()
        {
            FuelLevel = 100;

            Console.WriteLine($"Samochód {RegistrationNumber} zatankowany.");
        }
    }
}
