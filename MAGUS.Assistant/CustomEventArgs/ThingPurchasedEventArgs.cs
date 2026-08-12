using MAGUS.Things;

namespace MAGUS.Assistant.CustomEventArgs;

internal sealed class ThingPurchasedEventArgs(Thing thing) : EventArgs
{
    public Thing Thing { get; } = thing ?? throw new ArgumentNullException(nameof(thing));
}
