using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCronberg.Sap.ConsoleInput.Core
{
    public class ShortNameAttribute : Attribute
    {
        public string ShortName { get; set; }

        public ShortNameAttribute(string shortName)
        {
            ShortName = shortName;
        }
    }
}
