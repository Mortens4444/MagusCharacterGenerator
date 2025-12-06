using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/elf-t%C5%B1zelf-alfaj-r58/
/// </summary>
public class FireElf : Race, IUseRangedWeapons
{
    public override int Strength => -2;

    public override int Quickness => 1;

    public override int Dexterity => 1;

    public override int Stamina => -1;

    public override int Beauty => 1;

    public override QualificationList Qualifications =>
    [
        new AnimalTraining(),
        new ForestSurvival(QualificationLevel.Master),
        new Running(QualificationLevel.Master),
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new KeenHearing(1.5),
        new KeenSight(2),
        new Infravision(30),
        new ResistanceToNecromancy(-8),
        new GoodArcher(15),
        new FireMagic()
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

    public override string Name => "Fire-elf";
}
