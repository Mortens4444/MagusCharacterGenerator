using MAGUS.Enums;
using MAGUS.GameSystem.Languages;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Laical;
using MAGUS.Qualifications.Scientific;
using MAGUS.Qualifications.Specialities;

namespace MAGUS.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/fajok-k%C3%B6nyve-r62/
/// </summary>
public class SeeGiant : HalfGiant
{
    public override Alignment? Alignment => Enums.Alignment.DeathChaos;

    public override Size Size => Size.About_8_meters;

    public override QualificationList Qualifications
    {
        get
        {
            var result = base.Qualifications;
            result.AddRange(
            [
                new AncientTongueLore(AntientLanguage.Voul),
                new SwampSurvival(QualificationLevel.Master),
				new SeaSurvival(QualificationLevel.Master),
                new Swimming(QualificationLevel.Master)
            ]);
            return result;
        }
    }

    public override SpecialQualificationList SpecialQualifications
    {
        get
        {
            var result = base.SpecialQualifications;
            result.AddRange(
            [
                new Infravision(40),
                new BetterResistanceToFire(50),
            ]);
            return result;
        }
    }

    public override string Name => "Half-giant (see giant)";

    public override string[] Images => ["see_giant.png"];
}
