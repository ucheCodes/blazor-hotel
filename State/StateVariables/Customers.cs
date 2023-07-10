using AppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.StateVariables
{
    public class Customers
    {
        public List<Users> ListCustomers { get; }
        public Customers(List<Users> customers)
        {
            ListCustomers = customers;
        }
    }
}
