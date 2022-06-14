using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusApp1.Interfaces
{
    public interface ITickets
    {
        string Name { get; set; }
        string From { get; set; }
        string To { get; set; }
        DateTime DateOfJourney { get; set; }
        string DepartureTime { get; set; }
        string Type { get; set; }
        string Class { get; set; }
        int NumberOfPassengers { get; set; } 
        string AmountPaid { get; set; }
    }
}
