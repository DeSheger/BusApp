using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BusApp1.Interfaces;

namespace BusApp1.Models
{
    public class Ticket : ITickets
    {
        public string Name { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        [Browsable(false)]
        public DateTime DateOfJourney { get; set; }

        [DisplayName("Data podróży")]
        public string DateOfJourneyFormatted => this.DateOfJourney.ToString("dddd, dd MMMM yyyy");

        public string DepartureTime { get; set; }

        public string Type { get; set; }

        public string Class { get; set; }

        public int NumberOfPassengers { get; set; }

        [Browsable(false)]
        public static int Price { set; get; }

        public string AmountPaid { set; get; }

        public Ticket()
        {
            this.From = "Chorzow";
            Ticket.Price = 2;
        }
    }
}
