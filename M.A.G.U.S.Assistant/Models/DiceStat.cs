using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Models;

internal class DiceStat
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
            var normalizedFormula = Formula.EndsWith("_2_Times", StringComparison.Ordinal)
                ? Formula[..Formula.IndexOf("_2_Times", StringComparison.Ordinal)] + " " + Lng.Elem("(2 times)")
                : Formula;
            return $"{Lng.Elem(normalizedFormula)}{modPart}{specialPart}";
        }
    }

    public string DisplayLine => $"{Name} {DisplayFormula} = {Value}";
}
