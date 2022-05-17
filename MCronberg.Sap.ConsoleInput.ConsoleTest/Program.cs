﻿
namespace MCronberg.Sap.ConsoleInput.ConsoleTest
{
    using MCronberg.Sap.ConsoleInput.Core;
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            TestSimpleFileBinder();
            TestSimpleFileBinderRoot();  
            TestArgsBinder();
            TestConsoleBinder();

        }

        private static void TestSimpleFileBinder()
        {
            var s = FileBinder.Bind<Settings>("appsettings.json");            
            ShowJson(s, "Simple FileBinder");
        }

        private static void TestSimpleFileBinderRoot()
        {
            var s = FileBinder.Bind<Settings, Root>("appsettingsWithRoot.json");
            ShowJson(s, "FileBinder with root");
        }

        private static void TestConsoleBinder()
        {
            var s = ConsoleBinder.Bind<Settings>();
            Console.WriteLine();
            ShowJson(s, "ConsoleBinder");
        }

        private static void TestArgsBinder()
        {
            // simulate args
            List<string> a = new List<string>();
            // -n 1 -s a -b true
            a.Add("-n");
            a.Add("1");
            a.Add("s");
            a.Add("a");
            a.Add("b");
            a.Add("true");
            var s = ArgumentsBinder.Bind<Settings>(a.ToArray()); 
            ShowJson(s, "ArgsBinder");
        }

        private static void ShowJson(Settings s, string title = null)
        {
            if (title != null)
            {
                Console.WriteLine(title);
                Console.WriteLine(new string('-', title.Length));
            }
            string json = System.Text.Json.JsonSerializer.Serialize(s, options: new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(json);
            Console.WriteLine();
        }
    }
}