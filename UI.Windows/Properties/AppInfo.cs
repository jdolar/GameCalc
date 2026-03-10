using System.Reflection;
namespace UI.Windows.Properties;
public static class AppInfo
{
    private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();
    public static string Name =>
        Assembly.GetName().Name ?? "unknown";
    public static string Version =>
        Assembly.GetCustomAttribute<AssemblyFileVersionAttribute>()
        ?.Version ?? "unknown";
    public static string InfoVersion =>
        Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
        ?.InformationalVersion ?? "unknown";
}