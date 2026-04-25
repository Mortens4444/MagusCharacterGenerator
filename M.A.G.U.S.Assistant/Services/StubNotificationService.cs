using M.A.G.U.S.Assistant.Interfaces;
using System.Diagnostics;

namespace M.A.G.U.S.Assistant.Services;

internal sealed class StubNotificationService : INotificationService
{
    public void Initialize()
    {
        Debug.WriteLine("StubNotificationService.Initialize() called");
    }

    public void ShowNotification(string title, string message, int notificationId = 1)
    {
        Debug.WriteLine($"StubNotificationService.ShowNotification: {title} - {message} (id={notificationId})");
    }

    public void StartBackgroundNotificationService()
    {
        Debug.WriteLine("StubNotificationService.StartBackgroundNotificationService() called");
    }

    public void StopBackgroundNotificationService()
    {
        Debug.WriteLine("StubNotificationService.StopBackgroundNotificationService() called");
    }
}
