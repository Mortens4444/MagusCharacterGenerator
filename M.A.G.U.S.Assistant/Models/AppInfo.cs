using System.Reflection;

namespace M.A.G.U.S.Assistant.Models;

internal class AppInfo
{
    public string AppName { get; private set; }

    public string AppVersion { get; private set; }

    public string AppEmail { get; private set; }

    public string DevEmail { get; private set; }

    private AppInfo(string appName, string appVersion, string appEmail, string devEmail)
    {
        AppName = appName;
        AppVersion = appVersion;
        AppEmail = appEmail;
        DevEmail = devEmail;
    }

    public static AppInfo GetAppInfo(Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(assembly);
        var titleAttribute = assembly.GetCustomAttribute<AssemblyTitleAttribute>()!;
        var versionAttribute = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>()!;
        var appName = titleAttribute.Title;
        var appVersion = versionAttribute.Version[0..versionAttribute.Version.LastIndexOf('.')];
        var appEmail = "mortens.4444@gmail.com";
        return new AppInfo(appName, appVersion, appEmail, appEmail);
    }
}