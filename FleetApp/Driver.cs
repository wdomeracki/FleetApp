using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetApp
{
    internal class Driver
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string LicenseNumber { get; set; }

        public Driver()
        {
        }

        public Driver(string firstName, string lastName, string licenseNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            LicenseNumber = licenseNumber;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} ({LicenseNumber})";
        }
    }
}
