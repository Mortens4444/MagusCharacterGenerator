using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Reflection;
using AppInfo = M.A.G.U.S.Assistant.Models.AppInfo;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class AboutPageViewModel : ObservableObject
{
    static AboutPageViewModel()
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        if (assemblies != null)
        {
            mainAssembly = assemblies.FirstOrDefault(static a => a.GetName().Name == "M.A.G.U.S.Assistant");
        }
        if (mainAssembly == null)
        {
            mainAssembly = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
        }
    }

    public static Assembly? mainAssembly;
    public static AppInfo AppInfo => AppInfo.GetAppInfo(mainAssembly!);

    [ReadOnly(true)]
    [ObservableProperty]
    public string appName = AppInfo.AppName;

    [ReadOnly(true)]
    [ObservableProperty]
    public string appVersion = AppInfo.AppVersion;

    [ReadOnly(true)]
    [ObservableProperty]
    public string appEmail = AppInfo.AppEmail;

    public static Task SendEmailAsync()
    {
        var message = new EmailMessage
        {
            Subject = $"New function request / Report a problem ({AppInfo.AppName} {AppInfo.AppVersion})",
            Body = "Dear Software developer,\r\n\r\nRequest or problem description...\r\n\r\nBest regards,\r\n\r\n",
            To = [AppInfo.AppEmail],
            BodyFormat = EmailBodyFormat.PlainText
        };

        if (!String.IsNullOrEmpty(AppInfo.DevEmail) && AppInfo.AppEmail != AppInfo.DevEmail)
        {
            message.Bcc = [AppInfo.DevEmail];
        }

        return Email.ComposeAsync(message);
    }
}
