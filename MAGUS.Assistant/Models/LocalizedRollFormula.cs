using MAGUS.Enums;
using MAGUS.Models;
using Mtf.Extensions;
using Mtf.LanguageService;
using System.Reflection;

namespace MAGUS.Assistant.Models;

internal sealed class LocalizedRollFormula : RollFormula
{
    public LocalizedRollFormula(string formula, int modifier, bool specialTraining, string title = "Roll")
        : base(formula, modifier, specialTraining, title)
    {
    }

    public LocalizedRollFormula(ThrowType throwType, int modifier, bool specialTraining, string title = "Roll")
        : base(throwType, modifier, specialTraining, title)
    {
    }

    public LocalizedRollFormula(DiceThrowFormula diceThrowFormula, string title = "Roll")
        : base(diceThrowFormula, title)
    {
    }

    public LocalizedRollFormula(PropertyInfo? propertyInfo, string title = "Roll")
        : base(propertyInfo, title)
    {
    }

    public LocalizedRollFormula(RollFormula rollFormula, string title = "Roll")
        : base(rollFormula.ThrowType, rollFormula.Modifier, rollFormula.SpecialTraining, title)
    {
    }

    public string FullFormula
    {
        get
        {
            var modPart = Modifier != 0 ? $" + {Modifier}" : String.Empty;
            var specialPart = SpecialTraining ? $" + {Lng.Elem("Special Training")}" : String.Empty;
            return $"{Lng.Elem(ThrowType.GetDescription())}{modPart}{specialPart}";
        }
    }
}
