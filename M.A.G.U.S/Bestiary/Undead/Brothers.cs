using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class Brothers : LivingDead
{
    private readonly LivingDead baseCreature;

    public Brothers()
    {
        baseCreature = new Zombie();

        Occurrence = Occurrence.Rare;
        Size = baseCreature.Size;
        PlacesOfOccurrence = baseCreature.PlacesOfOccurrence;

        AttackValue = baseCreature.AttackValue + 5;
        DefenseValue = baseCreature.DefenseValue + 5;
        InitiateValue = baseCreature.InitiateValue + 5;
        AimValue = baseCreature.AimValue;

        HealthPoints = baseCreature.HealthPoints;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = baseCreature.Intelligence; // + 1D3
        Alignment = baseCreature.Alignment;

        ExperiencePoints = baseCreature.ExperiencePoints;
        NecrographyDepartment = baseCreature.NecrographyDepartment;
    }

    public override string Name => "Brothers";

    [DiceThrow(ThrowType._1D4)]
    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => DiceThrow._1D4() + 1; // 2-5

    public override int GetDamage() => baseCreature.GetDamage();

    public override List<Speed> Speeds => baseCreature.Speeds;

    public override double AttacksPerRound => baseCreature.AttacksPerRound;
}