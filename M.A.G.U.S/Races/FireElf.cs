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
    public override sbyte Strength => -2;

    public override sbyte Speed => 1;

    public override sbyte Dexterity => 1;

    public override sbyte Stamina => -1;

    public override sbyte Beauty => 1;

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

    public override string Name => "Fire-elf";
}
