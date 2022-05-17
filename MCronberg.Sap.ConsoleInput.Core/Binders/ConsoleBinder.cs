using System;
using MCronberg.Sap.ConsoleOutput.Core;

namespace MCronberg.Sap.ConsoleInput.Core
{
    public class ConsoleBinder
    {
        public static T Bind<T>(string preInputText = "Enter value for", string nullText = "use blank for null value")
        {
            try
            {
                Writer w = new Writer();
                var t = (T)Activator.CreateInstance(typeof(T));
                var properties = t.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                foreach (var property in properties)
                {
                    var y = Nullable.GetUnderlyingType(property.PropertyType);
                    if (y == null)
                        y = property.PropertyType;
                    w.Write(preInputText + " " + AttributeHelper.GetDescription(property) == null ? property.Name : AttributeHelper.GetDescription(property) + " (" + y.Name + " - " + nullText + "): ");
                    string s = Console.ReadLine().Trim();
                    if (s == "")
                        s = null;
                    Type type = property.PropertyType;
                    if (type == typeof(Nullable<int>))
                        property.SetValue(t, BinderHelper.GetNullableInt(s));

                    if (type == typeof(string))
                        property.SetValue(t, BinderHelper.GetString(s));

                    if (type == typeof(Nullable<bool>))
                        property.SetValue(t, BinderHelper.GetNullableBoolean(s));
                }
                return t;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error passing ", ex);
            }
        }
    }
}
