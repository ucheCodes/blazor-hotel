using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.StateVariables
{
    public class IsAdmin
    {
        public bool isAdmin { get;}
        public bool isSuperAdmin { get; }
        public IsAdmin(bool isAdmin, bool isSuperAdmin)
        {
            this.isAdmin = isAdmin;
            this.isSuperAdmin = isSuperAdmin;
        }
    }
}
