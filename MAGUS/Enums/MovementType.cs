using MAGUS.GameSystem.Attributes;

namespace MAGUS.Enums;

public enum MovementType
{
    [DefenseHelper(0)]
    Motionless,

    [DefenseHelper(10)]
    Predictable,

    [DefenseHelper(35)]
    Unpredictable,

    [DefenseHelper(50)]
    Evasive
}
