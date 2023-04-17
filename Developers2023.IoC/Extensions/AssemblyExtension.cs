using System.Reflection;

namespace Developers2023.IoC.Extensions
{
    public static class AssemblyExtension
    {
        public static Assembly[] GetUserAssemblies(this AppDomain domain)
        {
            return domain.GetAssemblies().Where(p => p.GetName().ToString().StartsWith("Developers2023")).ToArray();
        }

        public static string GetAssemblyPath(this Assembly assembly)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{assembly.GetName().Name}.xml");
        }
    }
}
