using System.ComponentModel;

namespace MAGUS.Enums;

public enum Occurrence
{
    [Description("Frequent")]
    Frequent,
    
    [Description("Rare")]
    Rare,

    [Description("Very rare")]
    VeryRare,

    [Description("Summoned")]
    Summoned
}
