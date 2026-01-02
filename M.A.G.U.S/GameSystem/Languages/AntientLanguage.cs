using System.ComponentModel;

namespace M.A.G.U.S.GameSystem.Languages;

public enum AntientLanguage
{
	Kyr,

	[Description("Lingua Domini")]
	LinguaDomini,

	Aquir,

	Voul,

    // Ősi birodalmi/archaikus nyelvek
    [Description("Classical Shadoni")]
    ClassicalShadoni,

    [Description("Archaic Jad")]
    ArchaicJad,

    [Description("Old Toronian")]
    OldToronian,

    [Description("Old Doranian")]
    OldDoranian,
    
    [Description("Old Godonian")]
    OldGodonian,

    // Faji ősi nyelvek
    [Description("Ancient Elven")]
    AncientElven,

    [Description("Dragon Speech")]
    DragonSpeech,

    [Description("Ancient Goblyn Tongue")]
    AncientGoblynTongue,

    // Krán és misztikus tradíciók
    [Description("Krannish Ritual Speech")]
    KrannishRitualSpeech,

    // Ritka / töredékes / misztikus nyelvek
    [Description("Wyrm Tongue")]
    WyrmTongue,

    [Description("Pre-Shadonian")]
    PreShadonian,

    [Description("Primeval Human")]
    PrimevalHuman
}
