using M.A.G.U.S.Enums;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public sealed class Slave : Aquirian
{
    public override int Strength => 2;
    public override int Stamina => 2;
    public override int Beauty => -4;

    public override Alignment? Alignment => Enums.Alignment.ChaosDeath;

    public override SpecialQualificationList SpecialQualifications
    {
        get
        {
            var result = base.SpecialQualifications;

            result.AddRange(
            [
                new Ultravision(60),
                //new IncreasedPainTolerance(),
                //new AquirWeaponAffinity(),
                //new PowerWordResistance(),   // hatalomszavak nem bénítják
                //new FearDrivenCruelty()
            ]);

            return result;
        }
    }

    public override string Name => "Slave";

    public override string GenerateCharacterName()
    {
        var start = new[] { "Idan", "Vra", "Khor", "Dree", "Zar", "Mek" };
        var middle = new[] { "a", "o", "e", "ra", "dre", "va" };
        var end = new[] { "teh", "vak", "nor", "gan", "reth" };

        return GenerateCharacterName(start, middle, end);
    }
}
