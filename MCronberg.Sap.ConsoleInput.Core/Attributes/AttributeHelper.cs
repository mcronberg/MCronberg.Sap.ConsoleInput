using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MCronberg.Sap.ConsoleInput.Core
{
    public class AttributeHelper
    {
        public static bool IsRequired(PropertyInfo property)
        {
            return Attribute.IsDefined(property, typeof(IsRequiredAttribute));
        }

        public static bool HasShortname(PropertyInfo property)
        {
            return Attribute.IsDefined(property, typeof(ShortNameAttribute));
        }

        public static string GetDescription(object obj, string name) {
            return AttributeHelper.GetDescription(obj.GetType().GetProperty(name));
        }

        public static string GetShortname(object obj, string name)
        {
            return AttributeHelper.GetShortname(obj.GetType().GetProperty(name));
        }

        public static List<string> GetShortnames(object obj)
        {
            List<string> p = new List<string>();
            foreach (var item in obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)) 
            {
                p.Add(GetShortname(item));
            }
            return p;
        }

        public static bool IsRequired(object obj, string name)
        {
            return AttributeHelper.IsRequired(obj.GetType().GetProperty(name));
        }



        public static string GetDescription(PropertyInfo property)
        {
            if (Attribute.IsDefined(property, typeof(DescriptionTextAttribute)))
            {
                DescriptionTextAttribute description = (DescriptionTextAttribute)Attribute.GetCustomAttribute(property, typeof(DescriptionTextAttribute));
                return description.Description;
            }
            else
            {
                return "";
            }
        }

        public static string GetShortname(PropertyInfo property)
        {
            if (Attribute.IsDefined(property, typeof(ShortNameAttribute)))
            {
                ShortNameAttribute description = (ShortNameAttribute)Attribute.GetCustomAttribute(property, typeof(ShortNameAttribute));
                return description.ShortName;
            }
            else
            {
                return "";
            }
        }

        public static void CheckRequired(object obj)
        {
            var properties = obj.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            foreach (var property in properties)
            {
                if (Attribute.IsDefined(property, typeof(IsRequiredAttribute)))
                {
                    if (property.GetValue(obj) == null)
                        throw new ApplicationException(property.Name + " is required");
                }
            }
        }
    }
}
