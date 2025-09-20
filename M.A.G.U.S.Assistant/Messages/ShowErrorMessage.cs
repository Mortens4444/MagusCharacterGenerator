using CommunityToolkit.Mvvm.Messaging.Messages;
using Mtf.LanguageService;
using Mtf.Maui.Controls.Extensions;

namespace M.A.G.U.S.Assistant.Messages;

public class ShowErrorMessage : ValueChangedMessage<string>
{
    public ShowErrorMessage(Exception exception)
#if DEBUG
        : base(exception.GetDetails())
#else
    : base(exception.Message)
#endif
    { }

    public ShowErrorMessage(string title, Exception exception)
        : base(exception.GetDetails(Lng.Elem(title)))
    { }

    public ShowErrorMessage(string message)
        : base(Lng.Elem(message))
    { }
}
