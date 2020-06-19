namespace ResourceViewer
{
    using System;
    using System.IO;
    using System.Reflection;

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: ResourceViewer <path to assembly>");
            }

            try
            {
                var assemblyFile = new FileInfo(args[0]);
                if (!assemblyFile.Exists)
                {
                    throw new FileNotFoundException($"Could not find file {assemblyFile.FullName}");
                }
            
                var assembly = Assembly.LoadFrom(assemblyFile.FullName);
                
                foreach(var resourceName in assembly.GetManifestResourceNames())
                {
                    Console.WriteLine($"  Resource: {resourceName}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType().Name}: {e.Message}");
            }
        }
    }
}
