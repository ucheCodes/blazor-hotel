using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.StateVariables
{
    public class ShowLoginDialog
    {
        public bool Show { get; }
        public ShowLoginDialog(bool show)
        {
            Show = show;
        }
    }
}
