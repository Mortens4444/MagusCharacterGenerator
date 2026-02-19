using System.ComponentModel;

namespace M.A.G.U.S.Enums;

public enum PoisonType
{
    [Description("Poisons Affecting the Digestive System")]
    DigestiveSystem = 1 << 1,

    [Description("Poisons Affecting the Nervous System")]
    NervousSystem = 1 << 2,

    [Description("Poisons Affecting the Muscular System")]
    MuscularSystem = 1 << 3,

    [Description("Poisons Affecting the Circulatory System")]
    CirculatorySystem = 1 << 4
}
