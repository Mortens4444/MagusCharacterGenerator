using M.A.G.U.S.Enums;
using M.A.G.U.S.Extensions;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications;
using Mtf.Extensions.Services;
using System.Text;

namespace M.A.G.U.S.Races;

public abstract class Race : ImageOwner, IRace
{
    protected readonly DiceThrow DiceThrow = new();
    protected static readonly Random random = new();

    public override string ToString() => Name;

    public virtual QualificationList Qualifications => [];

    public virtual PercentQualificationList PercentQualifications => [];

    public virtual SpecialQualificationList SpecialQualifications => [];

    public virtual int Strength => 0;

    public virtual int Quickness => 0;

    public virtual int Dexterity => 0;

    public virtual int Stamina => 0;

    public virtual int Health => 0;

    public virtual int Beauty => 0;

    public virtual int Intelligence => 0;

    public virtual int Willpower => 0;

    public virtual int Astral => 0;

    public int Bravery => 0;

    public int Erudition => 0;

    public int Detection => 0;

    public virtual Alignment? Alignment => null;

    public virtual string GenerateCharacterName()
    {
        var start = new[]
        {
            "Ar", "El", "Ka", "Lor", "Tha", "Bel", "Mar", "Fen", "Gal", "Rin", "Sir", "Var"
        };

        var middle = new[]
        {
            "an", "or", "il", "en", "ul", "ir", "mar", "eth", "on", "in", "ath"
        };

        var end = new[]
        {
            "is", "on", "ar", "ir", "en", "ael", "or", "uth", "as", "el"
        };

        var syllableCount = RandomProvider.GetSecureRandomInt(1, 3);
        var result = new StringBuilder();

        var s = start[random.Next(start.Length)];
        result.Append(s);

        for (var i = 0; i < syllableCount; i++)
        {
            var m = middle[random.Next(middle.Length)];
            result.Append(m);
        }

        var e = end[random.Next(end.Length)];
        result.Append(e);

        var name = result.ToString();
        return Char.ToUpperInvariant(name[0]) + name[1..];
    }

    protected static string GenerateCharacterName(char[] consonants, char[] vowels)
    {
        var length = RandomProvider.GetSecureRandomInt(3, 6);
        var result = new StringBuilder();

        for (var i = 0; i < length; i++)
        {
            if (i % 2 == 0)
            {
                var c = consonants[random.Next(consonants.Length)];
                result.Append(c);
            }
            else
            {
                var v = vowels[random.Next(vowels.Length)];
                result.Append(v);
            }
        }

        var name = result.ToString();
        return Char.ToUpperInvariant(name[0]) + name[1..];
    }

    public static string GenerateCharacterName(string[] start, string[] middle, string[] end)
    {
        var result = new StringBuilder();
        result.Append(start[random.Next(start.Length)]);

        var count = RandomProvider.GetSecureRandomInt(0, 2);
        for (var i = 0; i < count; i++)
        {
            result.Append(middle[random.Next(middle.Length)]);
        }

        result.Append(end[random.Next(end.Length)]);

        var name = result.ToString();
        return Char.ToUpperInvariant(name[0]) + name[1..];
    }
}
