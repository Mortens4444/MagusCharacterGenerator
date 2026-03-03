using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public sealed class Zauder : Race
{
    public override int Strength => 2;

    public override int Stamina => 4;

    public override int Intelligence => 5;

    public override int Beauty => -6;

    public override int Astral => 6;

    public override Alignment? Alignment => Enums.Alignment.ChaosDeath;

    public override QualificationList Qualifications
    {
        get
        {
            var result = base.Qualifications;

            result.AddRange(
            [
                new PsiPyarron(QualificationLevel.Master)
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
                new ShapeShiftingPerfectCopy(),
                new ItemMimicry(),
                new PoisonImmunity(),
                new AdvancedMentalResistance(),
                new AdvancedAstralResistance()
            ]);

            return result;
        }
    }

    public override string GenerateCharacterName()
    {
        var start = new[] { "Za", "Xa", "Thra", "Vau", "Qua", "Zhe" };
        var middle = new[] { "u", "au", "ae", "o", "io" };
        var end = new[] { "der", "th", "xil", "mor", "veth", "qor" };

        return GenerateCharacterName(start, middle, end);
    }
}