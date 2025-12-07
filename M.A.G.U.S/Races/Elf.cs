using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public class Elf : Race, IUseRangedWeapons
{
    public override int Strength => -2;

    public override int Quickness => 1;

    public override int Dexterity => 1;

    public override int Stamina => -1;

    public override int Beauty => 1;

    public override Alignment? Alignment => Enums.Alignment.OrderLife;

    public override QualificationList Qualifications =>
    [
        new Running(QualificationLevel.Master),
        new ForestSurvival(QualificationLevel.Master),
        new AnimalTraining(QualificationLevel.Master),
        new HuntingAndFishing(QualificationLevel.Master),
        new TrackingConcealment(QualificationLevel.Master)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new KeenHearing(2),
        new KeenSight(2.5),
        new Infravision(50),
        new ResistanceToNecromancy(-8),
        new GoodArcher(20)
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
}
