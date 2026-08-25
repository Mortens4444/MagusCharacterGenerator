using MAGUS.Enums;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Models;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Laical;
using MAGUS.Qualifications.Scientific;
using MAGUS.Qualifications.Specialities;

namespace MAGUS.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/fajok-k%C3%B6nyve-r62/
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/feenhar-r64/
/// Bestiárium 99. oldal
/// </summary>
public class Feenhar : Race
{
    public override int Dexterity => 1;

    public override int Quickness => 1;

    public override int Beauty => -2;

    public override int Astral => -1;

    public override Alignment? Alignment => Enums.Alignment.OrderDeath;

    public override List<Speed> Speeds => [.. base.Speeds, new Speed(TravelMode.InTheAir, 60)];

    public override QualificationList Qualifications =>
    [
        new HuntingAndFishing(QualificationLevel.Base),
        new Painting(QualificationLevel.Base),
        new Drawing(QualificationLevel.Base),
        new Sculptury(QualificationLevel.Base),
        new Architecture(QualificationLevel.Base)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Flight(),
        new KeenSight(2.5),
        new CantLearnPsi(),
        new Telepathy(),
        new GoodArcher(15),
        new Ultravision(15),
        //new Nightvision(),
        new SummonAirElemental(),
        new PoisonResistanceEqualsHealth(),
        new ExtraMagicResistanceOnLevelUp(5),
        new SummonBigBirds(),
        new SummonBirds()
    ];
}
