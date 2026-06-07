using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetApp
{
    internal class Fleet<T> where T : Vehicle
    {
        private List<T> vehicles = new List<T>();

        public void AddVehicle(T vehicle)
        {
            vehicles.Add(vehicle);
        }

        public List<T> GetVehicles()
        {
            return vehicles;
        }

        public T this[int index]
        {
            get
            {
                return vehicles[index];
            }
        }

        public async Task<T> FindByVinAsync(string vin)
        {
            await Task.Delay(1000);

            return vehicles.FirstOrDefault(vehicle => vehicle.Vin == vin);
        }
    }
}

