using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Specialities;
using Mtf.Extensions;

namespace M.A.G.U.S.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/fajok-k%C3%B6nyve-r62/
/// </summary>
public class ForestGiant : HalfGiant
{
    public override List<PercentQualification> PercentQualifications =>
    [
        new Sneaking(20),
        new Hiding(20)
    ];

    public override QualificationList Qualifications
    {
        get
        {
            var result = base.Qualifications;
            result.AddRange(
            [
                new ForestSurvival(QualificationLevel.Master),
                new TrackingConcealment(),
                new Craft(Profession.Carpenter, QualificationLevel.Master)
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
                new Infravision(50)
            ]);
            return result;
        }
    }

    public override string Name => "Half-giant (Forest giant)";
}
