using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Languages;
using System.ComponentModel;

namespace M.A.G.U.S.GameSystem.Places;

public enum City
{
    [OfficialLanguage(Language.Pyarronian)]
    Pyarron,

    [OfficialLanguage(Language.Toronian)]
    Toron,

    [OfficialLanguage(Language.Toronian)]
    Ordan,

    [OfficialLanguage(Language.Doranian)]
    Doran,

    [OfficialLanguage(Language.Erven)]
    Erion,

    [OfficialLanguage(Language.Pyarronian)]
    Erigow,

    // Pyarroni államok
    [OfficialLanguage(Language.Shadonian)]
    Shadon,

    [OfficialLanguage(Language.Toronian)]
    Abasis,
    //KránPokolkapu, // ha túl extrém, kiveszem
    //DartonKikoto,  // Darton-papok központi városa, opcionális

    // Északi Szövetség
    [OfficialLanguage(Language.Gorvikian)]
    Gorvik,
    [OfficialLanguage(Language.Tiadlanian)]
    Tiadlan,
    [OfficialLanguage(Language.Enosukean)]
    Enosuke,

    // Délvidék / Dzsad környék
    Alidax,
    TierNanGorduin, // Darton híres helye
    Abesar,

    // Toron környéke
    Allanor,
    Evervis,

    // Egyéb ikonikus helyek
    Riegoy,
    //KranKozpont,  // óvatosan kezelendő

    [Description("Thon-nion")] // A Nap Első Titkos városa (amund) - elpusztult
    Sonnion,
    
    [Description("Thalatheia")] // Refis városa (amund) - elpusztult
    Talasea
}
