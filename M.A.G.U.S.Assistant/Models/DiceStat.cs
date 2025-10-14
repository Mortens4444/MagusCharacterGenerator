using Mtf.LanguageService;

namespace M.A.G.U.S.Assistant.Models;

public class DiceStat
{
    public string Name { get; set; }
    public string Formula { get; set; }
    public int Modifier { get; set; }
    public bool HasSpecialTraining { get; set; }
    public object Value { get; set; }

    public string DisplayFormula
    {
        get
        {
            var modPart = Modifier != 0 ? $" + {Modifier}" : String.Empty;
            var specialPart = HasSpecialTraining ? $" + {Lng.Elem("Special Training")}" : String.Empty;
            return $"{Formula}{modPart}{specialPart}";
        }
    }

    public string DisplayLine => $"{Name} {DisplayFormula} = {Value}";
}
