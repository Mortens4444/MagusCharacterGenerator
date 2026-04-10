using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Languages;
using System.ComponentModel;

namespace M.A.G.U.S.GameSystem.Places;

[Flags]
public enum Country
{
    Unknown = 0,

    // --- Északi Szövetség és vonzáskörzete ---

    [OfficialLanguage(Language.Erven)]
    [OfficialReligion(Deity.Kyel)]
    Erigow = 1 << 0,

    [OfficialLanguage(Language.Tiadlanian)]
    [OfficialReligion(Deity.Arel)]
    Tiadlan = 1 << 1,

    [OfficialLanguage(Language.Ilanorian)]
    [OfficialReligion(Deity.Arel)]
    Ilanor = 1 << 2,

    [OfficialLanguage(Language.Erven)]
    Haonwell = 1 << 3,

    [OfficialLanguage(Language.Doranian)]
    [OfficialReligion(Deity.Adron)] // Doran a varázslók városa, Adron a fő patrónus
    Doran = 1 << 4,

    [OfficialLanguage(Language.Dwoon)]
    Dwoon = 1 << 5,

    [OfficialLanguage(Language.Pyarronian)]
    [Description("Dwyll Union")]
    DwyllUnion,

    // --- Toroni Szövetség ---

    [OfficialLanguage(Language.Toronian)]
    [OfficialReligion(Deity.Tharr)]
    Toron = 1 << 6,

    [OfficialLanguage(Language.Toronian)]
    [OfficialReligion(Deity.Domvik)] // Bár sokszínű, Domvik (és a pyar hit) elterjedt, de politikailag semlegesebb
    Abasis = 1 << 7,

    // --- Déli államok (Pyarroni szféra) ---

    [OfficialLanguage(Language.Pyarronian)]
    [OfficialReligion(Deity.Dreina)] // Pyarron államának feje és védnöke Dreina
    Pyarron = 1 << 8,

    [OfficialLanguage(Language.Pyarronian)]
    Predoc = 1 << 9,

    [OfficialLanguage(Language.Pyarronian)]
    Ediomad = 1 << 10,

    [OfficialLanguage(Language.Shadonian)] // Bár Yllinorban keveredik, de Shadoni alapok + nomád
    [OfficialReligion(Deity.Arel)] // Yllinorban Chei Király miatt Arel a fő
    Yllinor = 1 << 11,

    [OfficialLanguage(Language.Pyarronian)] // Szigorúan véve Pyarroni befolyás
    Syburr = 1 << 12,

    // --- Shadon és szakadárjai ---

    [OfficialLanguage(Language.Shadonian)]
    [OfficialReligion(Deity.Domvik)] // Az Egyetlen
    Shadon = 1 << 13,

    [OfficialLanguage(Language.Gorvikian)] // Shadoni nyelvjárás, de külön kezelik
    [OfficialReligion(Deity.Ranagol)] // A Kosfejű Úr (bár itt másképp tisztelik, mint Kránban)
    Gorvik = 1 << 14,

    // --- A Sötét Dél és egyebek ---

    [OfficialLanguage(Language.Krannish)]
    [OfficialReligion(Deity.Ranagol)]
    Kran = 1 << 15,

    // --- Független Városállamok ---

    [OfficialLanguage(Language.Pyarronian)] // A "Közös" hazája
    [OfficialReligion(Deity.Noir)] // Erionban sok a hit, de a "hercege" Noir
    Erion = 1 << 16,

    [OfficialLanguage(Language.Pyarronian)] // A Tűz városa (közös/pyarroni)
    [OfficialReligion(Deity.Sogron)] // A Tűz városa
    Ordan = 1 << 17,

    // --- Keleti szigetvilág ---

    [OfficialLanguage(Language.Enosukean)]
    Enosuke = 1 << 18,

    [OfficialLanguage(Language.Hilar)]
    [OfficialLanguage(Language.Vanir)]
    Tarin = 1 << 19,

    [OfficialLanguage(Language.Orc)]
    [OfficialReligion(Deity.Orwella)]
    [Description("Gro-Ugon")]
    GroUgon = 1 << 20,

    [Description("Sheral")]
    Sheral = 1 << 21,

    [Description("Elfendel")]
    Elfendel = 1 << 22,

    [Description("Godora sea")]
    GodoraSea = 1 << 23,

    [Description("Taba el-Ibara")]
    TabaElIbara = 1 << 24,
}
