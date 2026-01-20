using System.ComponentModel;
using System.Reflection;
using AppInfo = M.A.G.U.S.Assistant.Models.AppInfo;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class AboutPageViewModel : BaseViewModel
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
    public string AppName => AppInfo.AppName;

    [ReadOnly(true)]
    public string AppVersion => AppInfo.AppVersion;

    [ReadOnly(true)]
    public string AppEmail => AppInfo.AppEmail;

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
