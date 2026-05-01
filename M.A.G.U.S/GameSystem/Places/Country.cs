using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Languages;
using System.ComponentModel;

namespace M.A.G.U.S.GameSystem.Places;

[Flags]
public enum Country : ulong
{
    Unknown = 0,

    // --- Északi Szövetség és vonzáskörzete ---

    Eren = 1UL << 0,

    [OfficialLanguage(Language.Erven)]
    [OfficialReligion(Deity.Kyel)]
    Erigow = 1UL << 1,

    [OfficialLanguage(Language.Tiadlanian)]
    [OfficialReligion(Deity.Arel)]
    Tiadlan = 1UL << 2,

    [OfficialLanguage(Language.Ilanorian)]
    [OfficialReligion(Deity.Arel)]
    Ilanor = 1UL << 3,

    [OfficialLanguage(Language.Erven)]
    Haonwell = 1UL << 4,

    [OfficialLanguage(Language.Doranian)]
    [OfficialReligion(Deity.Adron)] // Doran a varázslók városa, Adron a fő patrónus
    Doran = 1UL << 5,

    [OfficialLanguage(Language.Dwoon)]
    Dwoon = 1UL << 6,

    [OfficialLanguage(Language.Pyarronian)]
    [Description("Dwyll Union")]
    DwyllUnion = 1UL << 7,

    Gianag = 1UL << 8,

    Sirenar = 1UL << 9,

    // --- Toroni Szövetség ---
    [OfficialLanguage(Language.Toronian)]
    [OfficialReligion(Deity.Tharr)]
    Toron = 1UL << 10,

    [OfficialLanguage(Language.Toronian)]
    [OfficialReligion(Deity.Domvik)] // Bár sokszínű, Domvik (és a pyar hit) elterjedt, de politikailag semlegesebb
    Abasis = 1UL << 11,

    // --- Déli államok (Pyarroni szféra) ---

    [Description("Lar-Dor")]
    LarDor = 1UL << 12,

    [OfficialLanguage(Language.Pyarronian)]
    [OfficialReligion(Deity.Dreina)] // Pyarron államának feje és védnöke Dreina
    Pyarron = 1UL << 13,

    [OfficialLanguage(Language.Pyarronian)]
    Predoc = 1UL << 14,

    [OfficialLanguage(Language.Pyarronian)]
    Edorl = 1UL << 15,

    [Description("The Six Cities Alliance")]
    TheSixCitiesAlliance = 1UL << 16,

    [Description("Three Shields Alliance")]
    ThreeShieldsAlliance = 1UL << 17,

    Sempyer = 1UL << 18,

    Enysmon = 1UL << 19,

    [OfficialLanguage(Language.Pyarronian)]
    Ediomad = 1UL << 20,

    [OfficialReligion(Deity.MotherEarth)]
    [Description("Mount Doardon")]
    MountDoardon = 1UL << 21, //Amazon

    [OfficialReligion(Deity.MotherEarth)]
    [Description("Riegoy Bay")]
    RiegoyBay = 1UL << 22, //Amazon

    [OfficialReligion(Deity.Unbeliever)]
    [Description("J'Hapina")]
    JHapina = 1UL << 23, //Barbár

    [OfficialReligion(Deity.Unbeliever)]
    [Description("K'Harkad")]
    KHarkad = 1UL << 24, //Barbár

    [OfficialLanguage(Language.Shadonian)] // Bár Yllinorban keveredik, de Shadoni alapok + nomád
    [OfficialReligion(Deity.Arel)] // Yllinorban Chei Király miatt Arel a fő
    Yllinor = 1UL << 25,

    [OfficialLanguage(Language.Pyarronian)] // Szigorúan véve Pyarroni befolyás
    Syburr = 1UL << 26,

    // --- Shadon és szakadárjai ---

    [OfficialLanguage(Language.Shadonian)]
    [OfficialReligion(Deity.Domvik)] // Az Egyetlen
    Shadon = 1UL << 27,

    [OfficialLanguage(Language.Gorvikian)] // Shadoni nyelvjárás, de külön kezelik
    [OfficialReligion(Deity.Ranagol)] // A Kosfejű Úr (bár itt másképp tisztelik, mint Kránban)
    Gorvik = 1UL << 28,

    // --- A Sötét Dél és egyebek ---

    [OfficialLanguage(Language.Krannish)]
    [OfficialReligion(Deity.Ranagol)]
    Kran = 1UL << 29,

    // --- Független Városállamok ---

    [OfficialLanguage(Language.Pyarronian)] // A "Közös" hazája
    [OfficialReligion(Deity.Noir)] // Erionban sok a hit, de a "hercege" Noir
    Erion = 1UL << 30,

    [OfficialLanguage(Language.Pyarronian)] // A Tűz városa (közös/pyarroni)
    [OfficialReligion(Deity.Sogron)] // A Tűz városa
    Ordan = 1UL << 31,

    // --- Keleti szigetvilág ---

    [OfficialLanguage(Language.Enosukean)]
    Enosuke = 1UL << 32,

    [OfficialLanguage(Language.Hilar)]
    [OfficialLanguage(Language.Vanir)]
    Tarin = 1UL << 33,

    [OfficialLanguage(Language.Orc)]
    [OfficialReligion(Deity.Orwella)]
    [Description("Gro-Ugon")]
    GroUgon = 1UL << 34,

    [Description("Sheral")]
    Sheral = 1UL << 35,

    [Description("Elfendel")]
    Elfendel = 1UL << 36,

    [Description("Godora sea")]
    GodoraSea = 1UL << 37,

    [Description("Taba el-Ibara")]
    TabaElIbara = 1UL << 38,
}