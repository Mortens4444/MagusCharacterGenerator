﻿using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.Bestiary;
using M.A.G.U.S.GameSystem.PoisonsAndIllnesses;
using M.A.G.U.S.GameSystem.Runes;
using M.A.G.U.S.Things;
using M.A.G.U.S.Things.Gemstones;
using M.A.G.U.S.Things.MagicalObjects;
using Mtf.LanguageService;

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
        if (runeObj is Rune r)
        {
            return new DisplayItem
            {
                Source = r,
                Key = r.Sign.ToString() ?? String.Empty,
                Title = $"{r.Sign} - {r.Name}",
                Subtitle = r.Meaning ?? String.Empty,
                RightText = r.Equivalent ?? String.Empty
            };
        }

        return new DisplayItem { Source = runeObj, Title = runeObj?.ToString() ?? String.Empty };
    }

    public static DisplayItem FromGemstone(object gemstoneObj)
    {
        if (gemstoneObj is Gemstone g)
        {
            return new DisplayItem
            {
                Source = g,
                Key = String.Empty,
                Title = g.Name ?? String.Empty,
                Subtitle = g.Description ?? String.Empty,
                RightText = g.Price.ToTranslatedString()
            };
        }

        return new DisplayItem { Source = gemstoneObj, Title = gemstoneObj?.ToString() ?? String.Empty };
    }

    public static DisplayItem FromMagicalObject(object magicalObj)
    {
        if (magicalObj is MagicalObject mo)
        {
            return new DisplayItem
            {
                Source = mo,
                Key = String.Empty,
                Title = mo.Name ?? String.Empty,
                Subtitle = $"{mo.ManaPoints} {Lng.Elem("MP")}",
                RightText = mo.Price?.ToTranslatedString() ?? String.Empty
            };
        }

        return new DisplayItem { Source = magicalObj, Title = magicalObj?.ToString() ?? String.Empty };
    }

    public static DisplayItem FromPoison(object poisonObj)
    {
        if (poisonObj is Poison p)
        {
            return new DisplayItem
            {
                Source = p,
                Key = String.Empty,
                Title = p.Name ?? String.Empty,
                Subtitle = p.Description ?? String.Empty,
                RightText = p.Price.ToTranslatedString()
            };
        }

        return new DisplayItem { Source = poisonObj, Title = poisonObj?.ToString() ?? String.Empty };
    }

    public static DisplayItem FromThing(object thingObj)
    {
        if (thingObj is Thing t)
        {
            return new DisplayItem
            {
                Source = t,
                Key = String.Empty,
                Title = t.Name ?? String.Empty,
                Subtitle = $"{t.Weight} {Lng.Elem("Kg")}",
                RightText = t.Price?.ToTranslatedString() ?? String.Empty
            };
        }

        return new DisplayItem { Source = thingObj, Title = thingObj?.ToString() ?? String.Empty };
    }

    public static DisplayItem FromCreature(object creatureObj)
    {
        if (creatureObj is Creature c)
        {
            return new DisplayItem
            {
                Source = c,
                Key = String.Empty,
                Title = c.Name ?? String.Empty,
                Subtitle = $"{Lng.Elem("Speed")} {c.Speed}",
                RightText = Lng.Elem(c.Occurrence.ToString())
            };
        }

        return new DisplayItem { Source = creatureObj, Title = creatureObj?.ToString() ?? String.Empty };
    }
}
