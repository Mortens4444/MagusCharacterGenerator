using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Qualifications;
using Mtf.Extensions.Services;
using System.Text;

namespace M.A.G.U.S.Races;

public abstract class Race : IRace
{
    protected readonly DiceThrow DiceThrow = new();
    protected static readonly Random random = new();

    public virtual string Name => GetType().Name;

    public override string ToString() => Name;

    public virtual QualificationList Qualifications => [];

    public virtual List<PercentQualification> PercentQualifications => [];

    public virtual SpecialQualificationList SpecialQualifications => [];

    public virtual sbyte Strength => 0;

    public virtual sbyte Quickness => 0;

    public virtual sbyte Dexterity => 0;

    public virtual sbyte Stamina => 0;

    public virtual sbyte Health => 0;

    public virtual sbyte Beauty => 0;

    public virtual sbyte Intelligence => 0;

    public virtual sbyte Willpower => 0;

    public virtual sbyte Astral => 0;

    public sbyte Bravery => 0;

    public sbyte Erudition => 0;

    public sbyte Detection => 0;

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

        var syllableCount = RandomProvider.GetSecureRandomShort(1, 3);
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
        var length = RandomProvider.GetSecureRandomShort(3, 6);
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

        var count = RandomProvider.GetSecureRandomShort(0, 2);
        for (var i = 0; i < count; i++)
        {
            result.Append(middle[random.Next(middle.Length)]);
        }

        result.Append(end[random.Next(end.Length)]);

        var name = result.ToString();
        return Char.ToUpperInvariant(name[0]) + name[1..];
    }
}
