using AppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModels
{
    public class BookingData
    {
        public string Id { get; set; } = "";
        public string Email { get; set; } = "";
        public string Reference { get; set; } = "";
        public string Mobile { get; set; } = "";
        public string Name { get; set; } = "";
        public int AdultCount { get; set; } = 1;
        public int ChildrenCount { get; set; } = 1;
        public DateTime Date { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfDays { get; set; } = 1;
        public Room Room { get; set; } = new Room();
    }
}
