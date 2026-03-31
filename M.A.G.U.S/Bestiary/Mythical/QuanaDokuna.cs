using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class QuanaDokuna : Creature
{
    public QuanaDokuna()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Small;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AstralMagicResistance = 100;
        MentalMagicResistance = 100;
        PoisonResistance = Int32.MaxValue;

        Psi = new PsiPyarron(QualificationLevel.Master);
        PsiPoints = 120;

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.Chaos;
        ExperiencePoints = 1000; // Depends on the Game Master
    }

    public override string Name => "Quana Dokuna (Contemplative)";

    [DiceThrowModifier(0)]
    public override int GetDamage() => 0;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 100)];
}