using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Languages;
using System.ComponentModel;

namespace MAGUS.GameSystem.Places;

// ulong (not the implicit int default) because the 2026 expansion below - every settlement with its
// own dedicated city map/description page on the community-maintained kalandozok.hu/ynev/ map, see
// CityCoordinates.cs - pushed well past the 31 flag bits a signed int can hold. Country already uses
// the same : ulong pattern for the same reason.
[Flags]
public enum City : ulong
{
    Unknown = 0,

    [OfficialLanguage(Language.Pyarronian)]
    Pyarron = 1UL << 0,

    [OfficialLanguage(Language.Toronian)]
    Toron = 1UL << 1,

    [OfficialLanguage(Language.Toronian)]
    Ordan = 1UL << 2,

    [OfficialLanguage(Language.Doranian)]
    Doran = 1UL << 3,

    [OfficialLanguage(Language.Erven)]
    Erion = 1UL << 4,

    [OfficialLanguage(Language.Pyarronian)]
    Erigow = 1UL << 5,

    // Pyarroni államok
    [OfficialLanguage(Language.Shadonian)]
    Shadon = 1UL << 6,

    [OfficialLanguage(Language.Toronian)]
    Abasis = 1UL << 7,

    // Északi Szövetség
    [OfficialLanguage(Language.Gorvikian)]
    Gorvik = 1UL << 8,

    [OfficialLanguage(Language.Tiadlanian)]
    Tiadlan = 1UL << 9,

    [OfficialLanguage(Language.Enosukean)]
    Enosuke = 1UL << 10,

    // Délvidék / Dzsad környék
    Alidax = 1UL << 11,

    TierNanGorduin = 1UL << 12, // Darton híres helye

    Abesar = 1UL << 13,

    // Toron környéke
    Allanor = 1UL << 14,

    Evervis = 1UL << 15,

    // Egyéb ikonikus helyek
    Riegoy = 1UL << 16,

    [Description("Thon-nion")] // A Nap Első Titkos városa (amund) - elpusztult
    Sonnion = 1UL << 17,

    [Description("Thalatheia")] // Refis városa (amund) - elpusztult
    Talasea = 1UL << 18,

    // --- 2026-os bővítés: minden olyan település, aminek saját várostérkép/leírás oldala van a
    // kalandozok.hu/ynev/ közösségi térképén - lásd CityCoordinates.cs a koordináták forrásához.
    // Nincs OfficialLanguage/Country hozzárendelve, mert ehhez nem volt megbízható forrásunk - ha egy
    // adott városhoz kell, azt majd külön, igény szerint pótoljuk.
    Amaro = 1UL << 19,
    Arascor = 1UL << 20,
    Arshur = 1UL << 21,
    Baraadheik = 1UL << 22,
    Bolk = 1UL << 23,
    Caedon = 1UL << 24,
    Davalon = 1UL << 25,

    [Description("El Hamed")]
    ElHamed = 1UL << 26,

    [Description("El Zashra")]
    ElZashra = 1UL << 27,

    Elya = 1UL << 28,
    Emarion = 1UL << 29,
    Eren = 1UL << 30,

    [Description("Erk medence")]
    ErkMedence = 1UL << 31,

    Garhudda = 1UL << 32,
    Ghastal = 1UL << 33,
    Haonwell = 1UL << 34,
    Haralk = 1UL << 35,
    Ifin = 1UL << 36,

    [Description("Jem-Irre")]
    Jemirre = 1UL << 37,

    Kalaril = 1UL << 38,
    Laorgan = 1UL << 39,
    Lavandron = 1UL << 40,
    Mezrud = 1UL << 41,
    Nastral = 1UL << 42,
    Nurween = 1UL << 43,

    [Description("Ó-Pyarron")] // Pyarron régi, ma jórészt romos fővárosa - nem tévesztendő össze a mai fővárossal (City.Pyarron = Új-Pyarron)
    OPyarron = 1UL << 44,

    Odra = 1UL << 45,
    Qunzais = 1UL << 46,
    Roxen = 1UL << 47,

    [Description("Sel Duriem")]
    SelDuriem = 1UL << 48,

    [Description("Sinog Kul")]
    SinogKul = 1UL << 49,

    Sushtar = 1UL << 50,
    Syburr = 1UL << 51,
    Tadzeh = 1UL << 52,
    Tagreosz = 1UL << 53,
    Terragin = 1UL << 54,
    Tervin = 1UL << 55,
    Triyang = 1UL << 56,
    Tuurian = 1UL << 57,
    Varreon = 1UL << 58
}
