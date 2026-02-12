using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using Mtf.Extensions;
using Mtf.LanguageService.MAUI;
using Mtf.Maui.Controls.Messages;
using System.Globalization;
using System.Reflection;

namespace M.A.G.U.S.Assistant.Services;

internal static class DiceThrowFormatter
{
    public static string FormatResult(MemberInfo? member, object? value)
    {
        if (member == null)
        {
            return FormatValue(value);
        }

        var throwAttr = member.GetCustomAttribute<DiceThrowAttribute>();
        if (throwAttr == null)
        {
            return FormatValue(value);
        }

        var modAttr = member.GetCustomAttribute<DiceThrowModifierAttribute>();
        var throwType = throwAttr.DiceThrowType;
        return FormatResult(value, throwType, modAttr?.Modifier ?? 0);
    }

    public static string FormatResult(object? value, ThrowType throwType, int modifier = 0)
    {
        var desc = Lng.Elem(throwType.GetDescription());
        var valueText = FormatValue(value);
        if (modifier != 0)
        {
            return $"{desc} + {modifier} = {valueText}";
        }
        return $"{desc} = {valueText}";
    }

    public static string FormatResult(MemberInfo? member, Func<object?> valueProvider)
    {
        if (valueProvider == null)
        {
            return FormatResult(member, null);
        }

        object? v = null;
        try
        {
            v = valueProvider();
        }
        catch (Exception ex)
        {
#if DEBUG
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
#endif
        }
        return FormatResult(member, v);
    }

    private static string FormatValue(object? value)
    {
        if (value == null)
        {
            return String.Empty;
        }

        return value switch
        {
            IFormattable f => f.ToString(null, CultureInfo.InvariantCulture),
            _ => value.ToString() ?? String.Empty
        };
    }
}
