using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Specialities;
using System.Text;

namespace M.A.G.U.S.Races;

public class Dwarf : Race
{
    public override sbyte Strength => 1;

    public override sbyte Stamina => 1;

    public override sbyte Health => 1;

    public override sbyte Beauty => -2;

    public override sbyte Intelligence => -1;

    public override sbyte Astral => -1;

    public override List<PercentQualification> PercentQualifications =>
    [
        new TrapDetection(35),
        new SecretDoorSearch(30)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Infravision(30),
        new PerfectSenseOfTime(),
        new UndergroundMasters(2),
        new GoodBuildingAgeGuess()
    ];

    public override string GenerateCharacterName()
    {
        var start = new[] { "Br", "Gr", "Thr", "Dur", "Gor", "Thal" };
        var middle = new[] { "im", "un", "ar", "orn", "grim", "dur" };
        var end = new[] { "in", "ar", "orn", "grum", "dal", "rak" };

        var result = new StringBuilder();
        result.Append(start[random.Next(start.Length)]);

        if (random.Next(2) == 1)
        {
            result.Append(middle[random.Next(middle.Length)]);
        }

        result.Append(end[random.Next(end.Length)]);

        var name = result.ToString();
        return Char.ToUpperInvariant(name[0]) + name[1..];
    }
}
