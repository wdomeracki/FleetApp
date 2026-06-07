using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetApp
{
    internal interface IFuelable
    {
        double FuelLevel { get; set; }

        void Refuel();
    }
}
