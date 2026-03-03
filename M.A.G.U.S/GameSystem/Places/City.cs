using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Languages;
using System.ComponentModel;

namespace M.A.G.U.S.GameSystem.Places;

[Flags]
public enum City
{
    Unknown = 0,

    [OfficialLanguage(Language.Pyarronian)]
    Pyarron = 1 << 0,

    [OfficialLanguage(Language.Toronian)]
    Toron = 1 << 1,

    [OfficialLanguage(Language.Toronian)]
    Ordan = 1 << 2,

    [OfficialLanguage(Language.Doranian)]
    Doran = 1 << 3,

    [OfficialLanguage(Language.Erven)]
    Erion = 1 << 4,

    [OfficialLanguage(Language.Pyarronian)]
    Erigow = 1 << 5,

    // Pyarroni államok
    [OfficialLanguage(Language.Shadonian)]
    Shadon = 1 << 6,

    [OfficialLanguage(Language.Toronian)]
    Abasis = 1 << 7,

    // Északi Szövetség
    [OfficialLanguage(Language.Gorvikian)]
    Gorvik = 1 << 8,

    [OfficialLanguage(Language.Tiadlanian)]
    Tiadlan = 1 << 9,

    [OfficialLanguage(Language.Enosukean)]
    Enosuke = 1 << 10,

    // Délvidék / Dzsad környék
    Alidax = 1 << 11,

    TierNanGorduin = 1 << 12, // Darton híres helye

    Abesar = 1 << 13,

    // Toron környéke
    Allanor = 1 << 14,

    Evervis = 1 << 15,

    // Egyéb ikonikus helyek
    Riegoy = 1 << 16,

    [Description("Thon-nion")] // A Nap Első Titkos városa (amund) - elpusztult
    Sonnion = 1 << 17,
    
    [Description("Thalatheia")] // Refis városa (amund) - elpusztult
    Talasea = 1 << 18
}
