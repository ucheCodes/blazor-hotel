using AppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.StateVariables
{
    public class ActiveUser
    {
        public Users User { get; set; }
        public ActiveUser(Users user) { 
            User = user;
        }
    }
}
