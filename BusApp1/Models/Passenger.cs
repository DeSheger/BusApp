using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusApp1.Interfaces;

namespace BusApp1.Models
{
    public class Passenger : IPassenger
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public Passenger(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
