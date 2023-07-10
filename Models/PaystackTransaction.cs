using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModels
{
    public class PaystackTransaction
    {
        public string Url { get; set; } = "";
        public string Reference { get; set; } = "";
        public string AccessCode { get; set; } = "";
        public string Department { get; set; } = "";
        public string TransactionId { get; set; } = "";
        public string Mobile { get; set; } = "";
        public DateTime Date { get; set; }
        public bool IsVerified { get; set; }
    }
}
