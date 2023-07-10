using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModels
{
    public class Notifications
    {
        public string Id { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public bool Is4Admin { get; set; }
        public string Department { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
