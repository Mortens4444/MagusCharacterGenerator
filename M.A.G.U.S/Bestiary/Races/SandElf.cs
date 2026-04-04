using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class SandElf : Creature
{
    public SandElf()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Desert;

        AttackValue = 120;
        DefenseValue = 170;
        InitiateValue = 50;
        AimValue = 65;

        AttacksPerRound = 2;

        HealthPoints = 12;
        PainTolerancePoints = 110;

        AstralMagicResistance = 45;
        MentalMagicResistance = 45;
        PoisonResistance = 10;

        Psi = new PsiPyarron();

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.Order;
        ExperiencePoints = 2650;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6(); // Weapon-dependent

    [DiceThrow(ThrowType._1D6)]
    public override int GetNumberAppearing() => DiceThrow._1D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 150)];

    public override string[] Images => ["desert_elf.png"];
}