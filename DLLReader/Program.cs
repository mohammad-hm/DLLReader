using System;
using System.Runtime.Loader;

namespace PathInputApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a path:");
            string path = Console.ReadLine();

            // read bytes for handling locking file
            var assemblyBytes = File.ReadAllBytes(path);

            var context = new AssemblyLoadContext(null, isCollectible: true);
            var assembly = context.LoadFromStream(new MemoryStream(assemblyBytes));

            var types = assembly.GetTypes();
            var dllFileType = assembly.GetType("produce.dll.ProduceDll"); 

            if (dllFileType != null)
            {
                var instance = Activator.CreateInstance(dllFileType);
                var firstVal = dllFileType.GetProperty("firstvalue");
                var timeInfo = dllFileType.GetProperty("firstvalueTime");
                if (instance != null && firstVal != null && timeInfo != null)
                {
                    if (firstVal.GetValue(instance) is string firstValue &&
                        timeInfo.GetValue(instance) is DateTimeOffset timeInfoValue)
                    {
                        Console.WriteLine("the value in dll file is: {0}", firstValue);
                        Console.WriteLine("the tim value in dll file is: {0}", timeInfoValue);
                    }
                }
                else
                {
                    Console.WriteLine("Properties not found or accessible in the DLL file.");
                }
            }
            else
            {
                Console.WriteLine("No type found in the DLL.");
            }

            // dispose DLL file
            context.Unload();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
