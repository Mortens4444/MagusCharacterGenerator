using MAGUS.Enums;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Percentages;
using MAGUS.Qualifications.Specialities;

namespace MAGUS.Races;

public sealed class DarkElf : Aquirian
{
    public override int Strength => 2;

    public override int Stamina => 2;

    public override int Quickness => 4;

    public override int Dexterity => 4;

    public override int Intelligence => 3;

    public override int Beauty => 1;

    public override int Astral => 2;

    public override Alignment? Alignment => Enums.Alignment.ChaosDeath;

    public override PercentQualificationList PercentQualifications =>
    [
        new Sneaking(120),
        new Climbing(80),
        new Jumping(80),
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new PoisonImmunity(),
        new Ultravision(300),
        new KeenHearing(5),
        //new HighAgility(18, 18),
        new AquirianPowerWords(),
    ];

    public override string Name => "Dark elf";

    public override string GenerateCharacterName()
    {
        var start = new[]
        {
            "Gor", "Dra", "Zha", "Thal", "Vri", "Kha", "Sha"
        };

        var middle = new[]
        {
            "ra", "vi", "zu", "ka", "on", "el"
        };

        var end = new[]
        {
            "th", "n", "r", "s", "k", "x"
        };

        return GenerateCharacterName(start, middle, end);
    }
}
