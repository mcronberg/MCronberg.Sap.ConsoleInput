using MCronberg.Sap.ConsoleOutput.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCronberg.Sap.ConsoleInput.Core
{
    public class Reader
    {
        [Obsolete]
        public T GetValue<T>(string text = null, bool useSimpleHeader = false) {
            if (text != null)
            {
                Writer writer = new Writer();
                if (useSimpleHeader) {
                    writer.SimpleHeader(text);
                } else {                 
                    writer.Write(text);
                }
            }
            string input = Console.ReadLine();
            return ConvertValue<T>(input);
        }

        public string GetString(string text = null, bool useSimpleHeader = false, string defaultValue = null)
        {
            if (text != null)
            {
                if (defaultValue != null)
                    text += " (default = " + defaultValue + ")";
                Writer writer = new Writer();
                if (useSimpleHeader)
                {
                    writer.SimpleHeader(text);
                }
                else
                {
                    writer.Write(text);
                }
            }
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
                return defaultValue;
            return input;
        }

        public int GetInt(string text = null, bool useSimpleHeader = false, int? defaultValue = null)
        {
            if (text != null)
            {
                if (defaultValue != null)
                    text += " (default = " + defaultValue + ")";
                Writer writer = new Writer();
                if (useSimpleHeader)
                {
                    writer.SimpleHeader(text);
                }
                else
                {
                    writer.Write(text);
                }
            }
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
                return defaultValue.Value;
            return System.Convert.ToInt32(input);
        }

        public double GetDouble(string text = null, bool useSimpleHeader = false, double? defaultValue = null)
        {
            if (text != null)
            {
                if (defaultValue != null)
                    text += " (default = " + defaultValue + ")";
                Writer writer = new Writer();
                if (useSimpleHeader)
                {
                    writer.SimpleHeader(text);
                }
                else
                {
                    writer.Write(text);
                }
            }
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
                return defaultValue.Value;
            return System.Convert.ToDouble(input);
        }

        public bool Choice(string text = null, bool useSimpleHeader = false, bool enterDefault = false)
        {
            if (text != null)
            {
                if (enterDefault)
                    text += " (enter = y)";
                Writer writer = new Writer();
                if (useSimpleHeader)
                {
                    writer.SimpleHeader(text);
                }
                else
                {
                    writer.Write(text);
                }
            }
            var input = GetConsoleKey();
            if (enterDefault && input == ConsoleKey.Enter)
                return true;
            if (input == ConsoleKey.Y)
                return true;
            return false;
        }


        public ConsoleKey GetConsoleKey(string text = null)
        {
            if (text != null)
            {
                Writer writer = new Writer();
                writer.Write(text);
            }
            return Console.ReadKey(true).Key;
        }

        private T ConvertValue<T>(string value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public int Menu(params string[] items)
        {
            if (items == null || items.Length == 0)
                throw new ApplicationException("Menu items missing");
            if (items.Length > 9)
                throw new ApplicationException("Too many menu items");

            Writer writer = new Writer();
            for (int i = 0; i < items.Length; i++)
            {
                writer.Write((i + 1) + " " + items[i]);
            }
            writer.NewLine();
            writer.Write("Enter menu # (1-" + (items.Length) + "): ");

            ConsoleKeyInfo input;
            bool c1;
            do
            {
                input = Console.ReadKey(true);
                c1 = ((int)input.KeyChar - 48) >= 1 && ((int)input.KeyChar - 48) <= (items.Length);
            } while (!c1);
            writer.NewLine();
            return (int)input.KeyChar - 48;
        }
    }
}
