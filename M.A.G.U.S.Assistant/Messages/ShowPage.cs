using CommunityToolkit.Mvvm.Messaging.Messages;

namespace M.A.G.U.S.Assistant.Messages;

public class ShowPage(Page page) : AsyncRequestMessage<Page>
{
    public Page Page { get; set; } = page;
}
