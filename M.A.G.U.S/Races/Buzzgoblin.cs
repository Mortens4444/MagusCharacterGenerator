using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Percentages;
using Mtf.Extensions;

namespace M.A.G.U.S.Races;

public sealed class Buzzgoblin : Race
{
    public override int Strength => 0;

    public override int Stamina => 1;

    public override int Intelligence => 0;

    public override int Beauty => -3;

    public override int Astral => 0;

    public override Alignment? Alignment => Enums.Alignment.Chaos;

    public override PercentQualificationList PercentQualifications
    {
        get
        {
            var result = base.PercentQualifications;
            result.AddRange(

            [
                new Sneaking(70),
                new Hiding(70),
                new TrapDetection(70),
                new Climbing(70),
                new Falling(70)
            ]);

            return result;
        }
    }

    public override QualificationList Qualifications
    {
        get
        {
            var result = base.Qualifications;
            result.AddRange(

            [
                new ForestSurvival(QualificationLevel.Master),
                new HuntingAndFishing(QualificationLevel.Master),
                new TrackingConcealment(QualificationLevel.Master),
                new Onomatopoeia(QualificationLevel.Master),
                new TrapSetting(QualificationLevel.Master),
                new Running(QualificationLevel.Master),
            ]);
            return result;
        }
    }

    //public override SpecialQualificationList SpecialQualifications
    //{
    //    get
    //    {
    //        var result = base.SpecialQualifications;
    //        result.AddRange(
    //        [
    //        ]);
    //        return result;
    //    }
    //}

    public override string Name => "Buzzgoblin";

    public override string GenerateCharacterName()
    {
        var start = new[] { "Bu", "Za", "Gro", "Ka", "Mu", "Ra" };
        var middle = new[] { "zg", "rr", "kk", "tt", "bb" };
        var end = new[] { "lin", "gob", "tak", "ruk", "mok" };

        return GenerateCharacterName(start, middle, end);
    }
}