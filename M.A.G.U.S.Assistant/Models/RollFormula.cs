using M.A.G.U.S.GameSystem.Attributes;
using Mtf.Extensions;
using Mtf.LanguageService;
using System.Text.RegularExpressions;

namespace M.A.G.U.S.Assistant.Models;

internal class RollFormula
{
    private string formula = String.Empty;

    public string Title { get; set; } = "Roll";

    public required string Formula
    {
        get => formula;
        set
        {
            value = Regex.Replace(value, @" \((2x)\)$", "_2_Times", RegexOptions.IgnoreCase);
            formula = Regex.IsMatch(value, @"^(1?D)", RegexOptions.IgnoreCase) ? $"_1{value}" : value.StartsWith('_') ? value : $"_{value}";
            ThrowType = Enum.Parse<ThrowType>(formula);
        }
    }

    public ThrowType ThrowType { get; private set; }

    public int Modifier { get; set; }

    public bool DefaultToAuto { get; set; } = true;

    public bool SpecialTraining { get; set; }

    public string FullFormula => $"{Lng.Elem(ThrowType.GetDescription())} + {Modifier}";
}
