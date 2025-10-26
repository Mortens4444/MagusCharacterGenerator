using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/fajok-k%C3%B6nyve-r62/
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/feenhar-r64/
/// Bestiárium 99. oldal
/// </summary>
public class Feenhar : Race
{
    public override sbyte Dexterity => 1;

    public override sbyte Speed => 1;

    public override sbyte Beauty => -2;

    public override sbyte Astral => -1;

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Flight(),
        new KeenSight(2.5),
        new CantLearnPsi(),
        new Telepathy(),
        new GoodArcher(15),
        new Nightvision(),
        new SummonAirElemental(),
        new PoisonResistanceEqualsHealth(),
        new ExtraMagicResistanceOnLevelUp(5),
        new SummonBigBirds(),
        new SummonBirds()
    ];
}
