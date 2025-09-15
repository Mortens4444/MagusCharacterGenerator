using CommunityToolkit.Mvvm.Messaging.Messages;

namespace M.A.G.U.S.Assistant.Messages;

public class ShowInfoMessage : ValueChangedMessage<string>
{
    public string Title { get; init; }

    public string Message { get; init; }

    public ShowInfoMessage(string title, string message)
        : base(String.Empty)
    {
        Title = title;
        Message = message;
    }
}
