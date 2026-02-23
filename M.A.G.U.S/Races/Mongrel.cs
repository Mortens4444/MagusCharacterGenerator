using M.A.G.U.S.Enums;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public sealed class Mongrel : Aquirian
{
    public override int Beauty => -3;

    public override Alignment? Alignment => Enums.Alignment.ChaosDeath;

    public override QualificationList Qualifications
    {
        get
        {
            var result = base.Qualifications;
            result.AddRange(
            [
                new PsiAntientWay()
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
                new Ultravision(120),
                new AstralMagicImmunity(),
                new MentalMagicImmunity(),
                new PoisonImmunity(),
                new Mute(),
                new SignLanguage(),
                new SilentMovement()
            ]);
            return result;
        }
    }

    public override string Name => "Mongrel (Ochak Va'Maadad)";

    public override string[] Images => ["mongrel.png"];

    public override string GenerateCharacterName()
    {
        var start = new[] { "Och", "Va", "Kha", "Gor", "Sza", "Mor" };
        var middle = new[] { "ak", "ma", "ra", "ul", "en", "da" };
        var end = new[] { "ad", "dad", "th", "gash", "kor", "vak" };

        return GenerateCharacterName(start, middle, end);
    }
}