﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModels
{
    public class TransactionInfo
    {
        public string Reference { get; set; } = "";
        public string AccessCode { get; set; } = "";
        public string Email { get; set; } = "";
        public string Mobile { get; set; } = "";
        public string Domain { get; set; } = "";
        public int Amount { get; set; }
        public string AccountName { get; set; } = "";
        public string Bank { get; set; } = "";
        public string Bin { get; set; } = "";
        public string CardBrand { get; set; } = "";
        public string CardExpiry { get; set; } = "";
        public string CardLastFourDigits { get; set; } = "";
        public string Status { get; set; } = "";
        public string Department { get; set; } = "";
        public DateTime Date { get; set; }
    }
}
