using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCronberg.Sap.ConsoleInput.Core
{
    public class BinderHelper
    {
        public static Nullable<int> GetNullableInt(string txt) {
            if (txt == null)
                return null;
            else
                return (Nullable<int>)Convert.ToInt32(txt);
        }

        public static Nullable<bool> GetNullableBoolean(string txt)
        {
            if (txt == null)
            {
                return null;
            }
            else
            {
                if (txt == "0")
                    txt = "false";
                if (txt == "1")
                    txt = "true";
                return (Nullable<bool>)Convert.ToBoolean(txt);
            }
        }

        public static string GetString(string txt)
        {
            return txt;
        }
    }
}
