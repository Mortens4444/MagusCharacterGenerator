using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/%C3%A9ji-elf-r54/
/// </summary>
public class NightElf : Race, IUseRangedWeapons
{
    public override int Strength => -1;

    public override int Quickness => 3;

    public override int Dexterity => 3;

    public int AimValue { get; set; } = 10;

    public override SpecialQualificationList SpecialQualifications =>
    [
        new KeenHearing(1.5),
        new KeenSight(1.5),
        new Ultravision(10),
        new Invisibility(),
    ];

    public override List<PercentQualification> PercentQualifications =>
    [
        new Sneaking(10),
        new Climbing(10),
        new Hiding(10)
    ];

    public override string GenerateCharacterName()
    {
        var start = new[]
        {
            "Ae", "Ela", "Iri", "Lia", "Sera", "Eli", "Ari", "Nae", "Yri", "Lora"
        };

        var middle = new[]
        {
            "li", "ne", "ri", "ya", "el", "ien", "ara", "ira", "the"
        };

        var end = new[]
        {
            "el", "iel", "ion", "ir", "iel", "wyn", "riel", "anor"
        };

        return GenerateCharacterName(start, middle, end);
    }

    public override string Name => "Night-elf";
}
