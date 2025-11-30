using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.Bestiary;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.PoisonsAndIllnesses;
using M.A.G.U.S.GameSystem.Runes;
using M.A.G.U.S.Things;
using M.A.G.U.S.Things.Gemstones;
using M.A.G.U.S.Things.MagicalObjects;
using Mtf.LanguageService;
using System.ComponentModel;

namespace M.A.G.U.S.Assistant.Models;

internal partial class DisplayItem : INotifyPropertyChanged
{
    public object? Source { get; init; }
    
    public string Key
    {
        get
        {
            return Source switch
            {
                Rune rune => rune.Sign.ToString() ?? String.Empty,
                LanguageItem languageItem => languageItem.EnumKey ?? String.Empty,
                _ => String.Empty
            };
        }
    }

    public string Title
    {
        get
        {
            return Source switch
            {
                LanguageItem languageItem => languageItem.Name ?? String.Empty,
                Rune rune => $"{rune.Sign} - {rune.Name}",
                Gemstone gemstone => gemstone.Name ?? String.Empty,
                Creature creature => creature.Name ?? String.Empty,
                MagicalObject magicalObject => magicalObject.Name ?? String.Empty,
                Poison poison => poison.Name ?? String.Empty,
                Thing thing => thing.Name ?? String.Empty,
                _ => String.Empty
            };
        }
    }

    public string Subtitle
    {
        get
        {
            return Source switch
            {
                MagicalObject magicalObject => $"{magicalObject.ManaPoints} {Lng.Elem("MP")}",
                Poison poison => poison.Description,
                LanguageItem languageItem => languageItem.Description ?? String.Empty,
                Gemstone gemstone => gemstone.Description ?? String.Empty,
                Thing thing => $"{thing.Weight} {Lng.Elem("Kg")}",
                Rune rune => rune.Equivalent ?? String.Empty,
                Creature creature => $"{Lng.Elem("Speed")} {creature.Speed}",
                _ => String.Empty
            };
        }
    }

    public string RightText
    {
        get
        {
            return Source switch
            {
                Gemstone gemstone => gemstone.MultipliedPrice.ToTranslatedString() ?? String.Empty,
                Thing thing => thing.MultipliedPrice?.ToTranslatedString() ?? String.Empty,
                Rune rune => rune.Meaning ?? String.Empty,
                Creature creature => Lng.Elem(creature.Occurrence.ToString()),
                _ => String.Empty
            };
        }
    }

    public Character? Character { get; init; }

    public bool Enabled
    {
        get
        {
            if (Source is Thing thing)
            {
                return Character?.Money is null || thing.MultipliedPrice is null || thing.MultipliedPrice <= Character.Money;
            }
            return true;
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    public static DisplayItem FromObject(object obj)
    {
        return new DisplayItem
        {
            Source = obj
        };
    }

    public static DisplayItem FromObject(object obj, Character character)
    {
        return new DisplayItem
        {
            Source = obj,
            Character = character
        };
    }
}
