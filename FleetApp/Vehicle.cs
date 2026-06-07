using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetApp
{
    internal abstract class Vehicle
    {
        public string Vin { get; set; }

        public string Brand { get; set; }

        public string RegistrationNumber { get; set; }

        public DateTime LastInspectionDate { get; set; }

        public Driver CurrentDriver { get; set; }

        public Driver LastDriver { get; set; }

        protected Vehicle()
        {
        }

        protected Vehicle(string vin, string brand, string registrationNumber, DateTime lastInspectionDate)
        {
            Vin = vin;
            Brand = brand;
            RegistrationNumber = registrationNumber;
            LastInspectionDate = lastInspectionDate;
        }

        public void ChangeDriver(Driver newDriver)
        {
            LastDriver = CurrentDriver;
            CurrentDriver = newDriver;
        }

        public void ShowDriverHistory()
        {
            Console.WriteLine();

            if (CurrentDriver != null)
            {
                Console.WriteLine($"Aktualny kierowca: {CurrentDriver}");
            }
            else
            {
                Console.WriteLine("Brak przypisanego kierowcy.");
            }

            if (LastDriver != null)
            {
                Console.WriteLine($"Poprzedni kierowca: {LastDriver}");
            }
            else
            {
                Console.WriteLine("Brak poprzedniego kierowcy.");
            }
        }

        public abstract void DisplayInfo();
    }
}
