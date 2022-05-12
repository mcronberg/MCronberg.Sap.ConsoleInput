using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCronberg.Sap.ConsoleInput.Core
{
    public class ArgumentsBinder
    {
        public static T Bind<T>(string[] args)
        {
            var t = (T)Activator.CreateInstance(typeof(T));
            Dictionary<string, string> arguments = new Dictionary<string, string>();
            for (int i = 0; i < args.Length; i += 2)
            {
                arguments.Add(args[i].Trim().ToLower().Replace("-", ""), args[i + 1].Trim());
            }
            var properties = t.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            foreach (var property in properties)
            {
                string shortName = AttributeHelper.GetShortname(property);
                if (shortName == "")
                    throw new ApplicationException(property.Name + " is missing a shortname");
                var a = arguments.Where(i => i.Key == shortName).FirstOrDefault();
                Type type = property.PropertyType;
                string s = a.Value;
                if (type == typeof(Nullable<int>))
                    property.SetValue(t, BinderHelper.GetNullableInt(s));

                if (type == typeof(string))
                    property.SetValue(t, BinderHelper.GetString(s));

                if (type == typeof(Nullable<bool>))
                    property.SetValue(t, BinderHelper.GetNullableBoolean(s));

            }
            AttributeHelper.CheckRequired(t);
            return t;
        }

    }
}
