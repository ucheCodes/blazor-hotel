using AppStore.StateVariables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore
{
    public class State
    {
        public ActiveUser? ActiveUser{ get; set; }
        public IsAdmin IsAdmin { get; set; } = new IsAdmin(false, false);
        public EditValue? EditValue { get; set; }
        public Customers? Customers { get; set; }
        public ShowLoginDialog ShowLogin { get; set; } = new(false);
        public NotificationCount Counter { get; set; } = new(0);
    }
}
