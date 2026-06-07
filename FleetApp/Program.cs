using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run().GetAwaiter().GetResult();
        }

        static async Task Run()
        {
            Fleet<Vehicle> fleet =
                new Fleet<Vehicle>();

            List<Driver> drivers =
                new List<Driver>();

            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine("=== SYSTEM OBSŁUGI FLOTY ===");
                Console.WriteLine();

                Console.WriteLine("1. Wyświetl pojazdy");
                Console.WriteLine("2. Dodaj samochód");
                Console.WriteLine("3. Dodaj ciężarówkę");
                Console.WriteLine("4. Wyszukaj pojazd po VIN");
                Console.WriteLine("5. Wyświetl liczbę pojazdów");
                Console.WriteLine("6. Tankuj wszystkie pojazdy");
                Console.WriteLine("7. Dodaj kierowcę");
                Console.WriteLine("8. Wyświetl kierowców");
                Console.WriteLine("9. Przypisz kierowcę do pojazdu");
                Console.WriteLine("10. Historia kierowców");
                Console.WriteLine("0. Wyjście");

                Console.WriteLine();
                Console.Write("Wybór: ");

                string option = Console.ReadLine();

                Console.Clear();

                switch (option)
                {
                    case "1":

                        if (fleet.GetVehicles().Count == 0)
                        {
                            Console.WriteLine("Brak pojazdów.");
                        }
                        else
                        {
                            foreach (Vehicle vehicle in fleet.GetVehicles())
                            {
                                vehicle.DisplayInfo();
                                Console.WriteLine();
                            }
                        }

                        break;

                    case "2":

                        Console.Write("VIN: ");
                        string carVin = Console.ReadLine();

                        Console.Write("Marka: ");
                        string carBrand = Console.ReadLine();

                        Console.Write("Rejestracja: ");
                        string carRegistration = Console.ReadLine();

                        Console.Write("Liczba miejsc: ");
                        int seats = int.Parse(Console.ReadLine());

                        Car car = new Car(carVin, carBrand, carRegistration, DateTime.Now, seats);

                        fleet.AddVehicle(car);

                        Console.WriteLine();
                        Console.WriteLine("Samochód został dodany.");

                        break;

                    case "3":

                        Console.Write("VIN: ");
                        string truckVin = Console.ReadLine();

                        Console.Write("Marka: ");
                        string truckBrand = Console.ReadLine();

                        Console.Write("Rejestracja: ");
                        string truckRegistration = Console.ReadLine();

                        Console.Write("Ładowność (t): ");
                        double loadCapacity = double.Parse(Console.ReadLine());

                        Truck truck = new Truck(truckVin, truckBrand, truckRegistration, DateTime.Now, loadCapacity);

                        fleet.AddVehicle(truck);

                        Console.WriteLine();
                        Console.WriteLine("Ciężarówka została dodana.");

                        break;

                    case "4":

                        Console.Write("Podaj VIN: ");

                        string vin = Console.ReadLine();

                        Vehicle foundVehicle = await fleet.FindByVinAsync(vin);

                        if (foundVehicle != null)
                        {
                            foundVehicle.DisplayInfo();
                        }
                        else
                        {
                            Console.WriteLine("Nie znaleziono pojazdu.");
                        }

                        break;

                    case "5":

                        FleetStatistics.ShowVehicleCount(fleet);
                        break;

                    case "6":

                        foreach (Vehicle vehicle in fleet.GetVehicles())
                        {
                            IFuelable fuelable = vehicle as IFuelable;

                            if (fuelable != null)
                            {
                                fuelable.Refuel();
                            }
                        }

                        break;

                    case "7":

                        Console.Write("Imię: ");
                        string firstName = Console.ReadLine();

                        Console.Write("Nazwisko: ");
                        string lastName = Console.ReadLine();

                        Console.Write("Numer prawa jazdy: ");

                        string licenseNumber = Console.ReadLine();

                        Driver driver = new Driver(firstName, lastName, licenseNumber);

                        drivers.Add(driver);

                        Console.WriteLine();
                        Console.WriteLine("Kierowca został dodany.");

                        break;

                    case "8":

                        if (drivers.Count == 0)
                        {
                            Console.WriteLine("Brak kierowców.");
                        }
                        else
                        {
                            for (int i = 0; i < drivers.Count; i++)
                            {
                                Console.WriteLine((i + 1) + ". " + drivers[i]);
                            }
                        }

                        break;

                    case "9":

                        if (drivers.Count == 0)
                        {
                            Console.WriteLine("Najpierw dodaj kierowców.");

                            break;
                        }

                        Console.Write("VIN pojazdu: ");

                        string vehicleVin = Console.ReadLine();

                        Vehicle vehicleToAssign = await fleet.FindByVinAsync(vehicleVin);

                        if (vehicleToAssign == null)
                        {
                            Console.WriteLine("Nie znaleziono pojazdu.");

                            break;
                        }

                        Console.WriteLine();
                        Console.WriteLine("Lista kierowców:");

                        for (int i = 0; i < drivers.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + drivers[i]);
                        }

                        Console.WriteLine();

                        Console.Write("Wybierz kierowcę: ");

                        int driverIndex = int.Parse(Console.ReadLine()) - 1;

                        if (driverIndex < 0 || driverIndex >= drivers.Count)
                        {
                            Console.WriteLine("Nieprawidłowy wybór.");

                            break;
                        }

                        vehicleToAssign.ChangeDriver(drivers[driverIndex]);

                        Console.WriteLine("Kierowca został przypisany.");

                        break;

                    case "10":

                        Console.Write("VIN pojazdu: ");

                        string historyVin = Console.ReadLine();

                        Vehicle historyVehicle = await fleet.FindByVinAsync(historyVin);

                        if (historyVehicle != null)
                        {
                            historyVehicle.ShowDriverHistory();
                        }
                        else
                        {
                            Console.WriteLine("Nie znaleziono pojazdu.");
                        }

                        break;

                    case "0":

                        isRunning = false;

                        Console.WriteLine("Zamykanie programu...");

                        break;

                    default:

                        Console.WriteLine("Nieprawidłowa opcja.");

                        break;
                }

                if (isRunning)
                {
                    Console.WriteLine();
                    Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");

                    Console.ReadKey();
                }
            }
        }
    }
    
}
