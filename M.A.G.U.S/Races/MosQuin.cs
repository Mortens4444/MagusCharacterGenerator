using M.A.G.U.S.Enums;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public sealed class MosQuin : Aquirian
{
    public override int Strength => 0;

    public override int Stamina => 1;

    public override int Dexterity => -1;

    public override int Intelligence => 4;

    public override int Beauty => -5;

    public override int Astral => 5;

    public override Alignment? Alignment => Enums.Alignment.ChaosDeath;

    public override SpecialQualificationList SpecialQualifications =>
    [
        new AquirianPowerWords(),
        new ManaReservoir(100, 10),
        new FastCasting(),
        new OneSpellPerRound()
    ];

    public override string Name => "Mos-quin";

    public override string GenerateCharacterName()
    {
        var start = new[]
        {
            "Mos", "Quin", "Zhar", "Ssath", "Krin", "Vaer"
        };

        var middle = new[]
        {
            "o", "a", "i", "u", "ss", "zh"
        };

        var end = new[]
        {
            "quin", "sath", "ra", "xis", "mor", "vek"
        };

        return GenerateCharacterName(start, middle, end);
    }
}