using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.Models;
using MAGUS.Qualifications;
using Mtf.Extensions.Services;
using System.Text;

namespace MAGUS.Races;

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

    public virtual Size Size => Size.Human;

    public int Bravery => 0;

    public int Erudition => 0;

    public int Detection => 0;

    public virtual Alignment? Alignment => null;

    public virtual List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 6, speedLevel: SpeedLevel.Slowest),   // Séta ~1.2 m/s
        new Speed(TravelMode.OnLand, 17, speedLevel: SpeedLevel.Slow),     // Gyors gyaloglás ~1.7 m/s
        new Speed(TravelMode.OnLand, 30, speedLevel: SpeedLevel.Normal),   // Kocogás ~3.0 m/s
        new Speed(TravelMode.OnLand, 45, speedLevel: SpeedLevel.Fast),     // Futás ~4.5 m/s
        new Speed(TravelMode.OnLand, 110, speedLevel: SpeedLevel.Fastest), // Sprint ~11.0 m/s
        new Speed(TravelMode.InWater, 6, speedLevel: SpeedLevel.Slowest),  // Átlagos úszó ~0.6 m/s
        new Speed(TravelMode.InWater, 11, speedLevel: SpeedLevel.Slow),    // Jó úszó ~1.1 m/s
        new Speed(TravelMode.InWater, 21, speedLevel: SpeedLevel.Fast)     // Versenyúszó ~2.1 m/s
    ];

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
