using MAGUS.Enums;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Laical;
using MAGUS.Qualifications.Percentages;
using MAGUS.Qualifications.Scientific;
using MAGUS.Qualifications.Specialities;
using System.Text;

namespace MAGUS.Races;

public class Khal : Race
{
    public override int Strength => 3;

    public override int Quickness => 2;

    public override int Dexterity => 1;

    public override int Stamina => 2;

    public override int Health => 3;

    public override int Willpower => -1;

    public override int Astral => -5;

    public override Alignment? Alignment => Enums.Alignment.Death;

    public override QualificationList Qualifications =>
    [
        new ForestSurvival(),
        new HuntingAndFishing(),
        new WeatherDivination(),
        new Swimming(),
        new Running(QualificationLevel.Master),
        new Demonology()
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new KeenSight(2),
        new KeenHearing(2),
        new KeenSmell(5),
        new CanOnlyLearnPyarronPsi()
    ];

    public override PercentQualificationList PercentQualifications =>
    [
        new SenseOfDanger(20),
        new SenseOfMortalPeril(40),
    ];

    public override string GenerateCharacterName()
    {
        var start = new[] { "Ka", "Sha", "Rha", "Ma", "Kha", "Tha" };
        var middle = new[] { "ruk", "zar", "mar", "hak", "gath", "rhun" };
        var end = new[] { "ar", "ok", "an", "ur", "ath" };

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
