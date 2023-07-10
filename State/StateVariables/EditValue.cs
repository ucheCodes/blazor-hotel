using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.StateVariables
{
    public class EditValue
    {
        public KeyValuePair<int,string> kvp { get;}
        public EditValue(KeyValuePair<int, string> kvp)
        {
            this.kvp = kvp;
        }
    }
}
