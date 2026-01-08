using M.A.G.U.S.GameSystem.Attributes;
using Mtf.Extensions;
using Mtf.LanguageService.MAUI;
using System.Reflection;
using System.Text.RegularExpressions;

namespace M.A.G.U.S.Assistant.Models;

internal class RollFormula
{
    public RollFormula(string formula, int modifier, bool specialTraining, string title = "Roll")
    {
        Title = title;
        formula = Regex.Replace(formula, @" \((2x)\)$", "_2_Times", RegexOptions.IgnoreCase);
        Formula = Regex.IsMatch(formula, @"^(1?D)", RegexOptions.IgnoreCase) ? $"_1{formula}" : formula.StartsWith('_') ? formula : $"_{formula}";
        ThrowType = Enum.Parse<ThrowType>(formula);
        Modifier = modifier;
        SpecialTraining = specialTraining;
    }

    public RollFormula(ThrowType throwType, int modifier, bool specialTraining, string title = "Roll")
    {
        Title = title;
        Formula = throwType.GetDescription();
        ThrowType = throwType;
        Modifier = modifier;
        SpecialTraining = specialTraining;
    }

    public RollFormula(PropertyInfo? propertyInfo, string title = "Roll")
    {
        ArgumentNullException.ThrowIfNull(propertyInfo);

        var throwAttr = propertyInfo.GetCustomAttribute<DiceThrowAttribute>()!;
        var modAttr = propertyInfo.GetCustomAttribute<DiceThrowModifierAttribute>();
        var hasSpecialTraining = propertyInfo.GetCustomAttribute<SpecialTrainingAttribute>() != null;

        Title = title;
        ThrowType = throwAttr.DiceThrowType;
        Formula = ThrowType.GetDescription();
        Modifier = modAttr?.Modifier ?? 0;
        SpecialTraining = hasSpecialTraining;
    }

    public string Title { get; private set; }

    public string Formula { get; private set; }

    public ThrowType ThrowType { get; private set; }

    public int Modifier { get; private set; }

    public bool SpecialTraining { get; private set; }

    public bool DefaultToAuto { get; set; } = true;

    public string FullFormula => $"{Lng.Elem(ThrowType.GetDescription())} + {Modifier}";
}
