using M.A.G.U.S.Assistant.Interfaces;
using System.Diagnostics;

namespace M.A.G.U.S.Assistant.Services;

internal sealed class StubNotificationService : INotificationService
{
    public void Initialize()
    {
        // No-op stub to avoid nulls on platforms without a concrete implementation
        Debug.WriteLine("StubNotificationService.Initialize() called");
    }

    public void ShowNotification(string title, string message, int notificationId = 1)
    {
        // No-op. Log for diagnostics.
        Debug.WriteLine($"StubNotificationService.ShowNotification: {title} - {message} (id={notificationId})");
    }
}
