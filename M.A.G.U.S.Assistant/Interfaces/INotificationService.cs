namespace M.A.G.U.S.Assistant.Interfaces;

public interface INotificationService
{
    void Initialize();

    void ShowNotification(string title, string message, int notificationId = 1);

    void StartBackgroundNotificationService();

    void StopBackgroundNotificationService();
}
