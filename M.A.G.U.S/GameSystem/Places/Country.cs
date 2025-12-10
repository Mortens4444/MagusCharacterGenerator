using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Languages;

namespace M.A.G.U.S.GameSystem.Places;

public enum Country
{
    // --- Északi Szövetség és vonzáskörzete ---

    [OfficialLanguage(Language.Erven)]
    [OfficialReligion(Deity.Kyel)]
    Erigow,

    [OfficialLanguage(Language.Tiadlanian)]
    [OfficialReligion(Deity.Arel)]
    Tiadlan,

    [OfficialLanguage(Language.Ilanorian)]
    [OfficialReligion(Deity.Arel)]
    Ilanor,

    [OfficialLanguage(Language.Erven)]
    Haonwell,

    [OfficialLanguage(Language.Doranian)]
    [OfficialReligion(Deity.Adron)] // Doran a varázslók városa, Adron a fő patrónus
    Doran,

    [OfficialLanguage(Language.Dwoon)]
    Dwoon,

    // --- Toroni Szövetség ---

    [OfficialLanguage(Language.Toronian)]
    [OfficialReligion(Deity.Tharr)]
    Toron,

    [OfficialLanguage(Language.Toronian)]
    [OfficialReligion(Deity.Domvik)] // Bár sokszínű, Domvik (és a pyar hit) elterjedt, de politikailag semlegesebb
    Abaszisz,

    // --- Déli államok (Pyarroni szféra) ---

    [OfficialLanguage(Language.Pyarronian)]
    [OfficialReligion(Deity.Dreina)] // Pyarron államának feje és védnöke Dreina
    Pyarron,

    [OfficialLanguage(Language.Pyarronian)]
    Predoc,

    [OfficialLanguage(Language.Pyarronian)]
    Ediomad,

    [OfficialLanguage(Language.Shadonian)] // Bár Yllinorban keveredik, de Shadoni alapok + nomád
    [OfficialReligion(Deity.Arel)] // Yllinorban Chei Király miatt Arel a fő
    Yllinor,

    [OfficialLanguage(Language.Pyarronian)] // Szigorúan véve Pyarroni befolyás
    Syburr,

    // --- Shadon és szakadárjai ---

    [OfficialLanguage(Language.Shadonian)]
    [OfficialReligion(Deity.Domvik)] // Az Egyetlen
    Shadon,

    [OfficialLanguage(Language.Gorvikian)] // Shadoni nyelvjárás, de külön kezelik
    [OfficialReligion(Deity.Ranagol)] // A Kosfejű Úr (bár itt másképp tisztelik, mint Kránban)
    Gorvik,

    // --- A Sötét Dél és egyebek ---

    [OfficialLanguage(Language.Kranich)]
    [OfficialReligion(Deity.Ranagol)]
    Kran,

    // --- Független Városállamok ---

    [OfficialLanguage(Language.Pyarronian)] // A "Közös" hazája
    [OfficialReligion(Deity.Noir)] // Erionban sok a hit, de a "hercege" Noir
    Erion,

    [OfficialLanguage(Language.Pyarronian)] // A Tűz városa (közös/pyarroni)
    [OfficialReligion(Deity.Sogron)] // A Tűz városa
    Ordan,

    // --- Keleti szigetvilág ---

    [OfficialLanguage(Language.Enosukean)]
    Enosuke
}
