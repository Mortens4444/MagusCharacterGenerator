using System.ComponentModel;

namespace M.A.G.U.S.Enums;

public enum InitiativeEntryKind
{
    [Description("")]
    Attack,

    [Description("🐾")] //"🚶" "🪽" "🦈"
    Movement,

    [Description("☠")]
    Death,

    [Description("😵‍💫")]
    LostConsciousness
}
