using System;

namespace MCronberg.Sap.ConsoleInput.Core
{
    public class FileBinder
    {
        public static T Bind<T>(string jsonFile)
        {
            try
            {
                string json = System.IO.File.ReadAllText(jsonFile);
                var obj = System.Text.Json.JsonSerializer.Deserialize<T>(json);
                AttributeHelper.CheckRequired(obj);
                return obj;

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error passing " + jsonFile, ex);
            }
        }

        public static T Bind<T, TRoot>(string jsonFile)
        {

            try
            {
                string json = System.IO.File.ReadAllText(jsonFile);
                var rootObj = System.Text.Json.JsonSerializer.Deserialize<TRoot>(json);
                var properties = rootObj!.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                foreach (var property in properties)
                {
                    var t1 = property.GetValue(rootObj).GetType();
                    var t2 = typeof(T);
                    if (t1 == t2)
                    {
                        T obj = (T)property.GetValue(rootObj);
                        AttributeHelper.CheckRequired(obj);
                        return obj;
                    }
                }
                throw new ApplicationException("Root object missing when passing " + jsonFile);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error passing " + jsonFile, ex);
            }
        }

        
    }
}
