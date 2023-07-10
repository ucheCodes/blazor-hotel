using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModels
{
    public class KitchenOrder
    {
        public string Id { get; set; } = "";
        public string KitchenId { get; set; } = "";
        public string Reference { get; set; } = "";
        public string Email { get; set; } = "";
        public string Mobile { get; set; } = "";
        public int Quantity { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
