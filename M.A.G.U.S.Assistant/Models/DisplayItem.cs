namespace M.A.G.U.S.Assistant.Models;

public class DisplayItem
{
    public object? Source { get; init; } // eredeti objektum
    public string Key { get; init; } = String.Empty; // pl. enum key vagy sign
    public string Title { get; init; } = String.Empty; // főcím (Name)
    public string Subtitle { get; init; } = String.Empty; // leírás / meaning
    public string RightText { get; init; } = String.Empty; // pl. Equivalent, Type, stb.

    public static DisplayItem FromLanguageItem(object languageItem)
    {
        if (languageItem is LanguageItem li)
        {
            return new DisplayItem
            {
                Source = li,
                Key = li.EnumKey ?? String.Empty,
                Title = li.Name ?? String.Empty,
                Subtitle = li.Description ?? String.Empty
            };
        }

        return new DisplayItem { Source = languageItem, Title = languageItem?.ToString() ?? String.Empty };
    }

    public static DisplayItem FromRune(object runeObj)
    {
        if (runeObj is GameSystem.Runes.Rune r)
        {
            return new DisplayItem
            {
                Source = r,
                Key = r.Sign.ToString() ?? String.Empty,
                Title = r.Name ?? String.Empty,
                Subtitle = r.Meaning ?? String.Empty,
                RightText = r.Equivalent ?? String.Empty
            };
        }

        return new DisplayItem { Source = runeObj, Title = runeObj?.ToString() ?? String.Empty };
    }

    public static DisplayItem FromGemstone(object gemstoneObj)
    {
        if (gemstoneObj is GameSystem.Gemstones.Gemstone g)
        {
            return new DisplayItem
            {
                Source = g,
                Key = String.Empty,
                Title = g.Name ?? String.Empty,
                Subtitle = g.Description ?? String.Empty,
                RightText = String.Empty
            };
        }

        return new DisplayItem { Source = gemstoneObj, Title = gemstoneObj?.ToString() ?? String.Empty };
    }
}
