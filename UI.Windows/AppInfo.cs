using System.Reflection;
namespace UI.Windows;
public static class AppInfo
{
    private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();

    public static string Name =>
       Assembly.GetName().Name ?? "unknown";

    public static string AssemblyVersion =>
        Assembly.GetName().Version?.ToString() ?? "unknown";

    public static string Version =>
     Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
     ?.InformationalVersion ?? "unknown";

    public static string FileVersion =>
        Assembly.GetCustomAttribute<AssemblyFileVersionAttribute>()
        ?.Version ?? "unknown";

    public static string Authors =>
        Assembly.GetCustomAttributes<AssemblyMetadataAttribute>()
        .FirstOrDefault(a => a.Key == "Authors")
        ?.Value ?? "unknown";
}


