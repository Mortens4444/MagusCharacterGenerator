using M.A.G.U.S.Enums;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public sealed class Trueblood : Aquirian
{
    public override int Strength => -2;

    public override int Stamina => -1;

    public override int Intelligence => 4;

    public override int Beauty => -6;

    public override int Astral => 4;

    public override Alignment? Alignment => Enums.Alignment.ChaosDeath;

    public override SpecialQualificationList SpecialQualifications
    {
        get
        {
            var result = base.SpecialQualifications;
            result.AddRange(
            [
                new AquirianPowerWords(),
                new Ultravision(0),
                new AstralMagicImmunity(),
                new MentalMagicImmunity(),
                new PoisonImmunity(),
                new SoulShatteringSpellcasting()
            ]);
            return result;
        }
    }

    public override string GenerateCharacterName()
    {
        var start = new[] { "Ra", "Cha", "Ni", "Va", "Zha", "Thae" };
        var middle = new[] { "a", "o", "aa", "ei", "u" };
        var end = new[] { "t", "gan", "raad", "niigan", "maad" };

        return GenerateCharacterName(start, middle, end);
    }
}