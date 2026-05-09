using M.A.G.U.S.Things;

namespace M.A.G.U.S.Assistant.CustomEventArgs;

internal sealed class ThingPurchasedEventArgs(Thing thing) : EventArgs
{
    public Thing Thing { get; } = thing ?? throw new ArgumentNullException(nameof(thing));
}
