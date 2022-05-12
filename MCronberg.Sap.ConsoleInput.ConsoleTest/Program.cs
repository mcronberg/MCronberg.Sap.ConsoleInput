
namespace MCronberg.Sap.ConsoleInput.ConsoleTest
{
    using MCronberg.Sap.ConsoleInput.Core;

    public class Program
    {
        public static void Main(string[] args)
        {
            //var s1 = FileBinder.Bind<Settings>("appsettings.json");
            //var s2 = FileBinder.Bind<Settings, Root>("appsettingsWithRoot.json");
            var s3 = ConsoleBinder.Bind<Settings>();

            List<string> a = new List<string>();
            a.Add("n");
            a.Add("1");
            a.Add("s");
            a.Add("a");
            a.Add("b");
            a.Add("true");
            //var s4 = ArgumentsBinder.Bind<Settings>(a.ToArray());

        }
    }
}