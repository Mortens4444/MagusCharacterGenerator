using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Specialities;
using System.Text;

namespace M.A.G.U.S.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/fajok-k%C3%B6nyve-r62/
/// </summary>
public abstract class HalfGiant : Race
{
    public override int Strength => 3;

    public override int Stamina => 2;

    public override int Health => 3;

    public override int Beauty => -1;

    public override int Intelligence => -1;

    public override int Quickness => -1;

    public override int Astral => -3;

    public override QualificationList Qualifications =>
    [
        new Running(),
        new HuntingAndFishing(QualificationLevel.Master)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new DoubledPainToleranceBase(),
        new AdditionalLifePoints(3),
    ];

    public override string GenerateCharacterName()
    {
        var start = new[] { "Gro", "Tor", "Mau", "Bru", "Kar", "Vor" };
        var middle = new[] { "gor", "thar", "mur", "gran", "dor" };
        var end = new[] { "un", "or", "ath", "um", "ar" };

        var result = new StringBuilder();
        result.Append(start[random.Next(start.Length)]);

        if (random.Next(2) == 0)
        {
            result.Append(middle[random.Next(middle.Length)]);
        }

        result.Append(end[random.Next(end.Length)]);

        var name = result.ToString();
        return Char.ToUpperInvariant(name[0]) + name[1..];
    }
}
