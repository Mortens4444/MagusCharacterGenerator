using System.ComponentModel;

namespace MAGUS.Enums;

public enum InitiativeEntryKind
{
    [Description("")]
    Attack,

    [Description("🐾")] //"🚶" "🪽" "🦈"
    Movement,

    [Description("☠")]
    Death,

    [Description("😵‍💫")]
    LostConsciousness,

    [Description("☣")]
    EffectTick
}
