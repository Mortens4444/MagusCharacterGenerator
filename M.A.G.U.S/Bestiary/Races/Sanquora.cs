using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Things.Weapons.CrushingWeapons;
using M.A.G.U.S.Things.Weapons.RangedWeapons;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class Sanquora : Creature
{
    public Sanquora()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Forest | TerrainType.Mountains;

        AttackValue = 70;
        DefenseValue = 145;
        InitiateValue = 45;
        AimValue = 25;

        HealthPoints = 12;
        PainTolerancePoints = 45;
        
        AttackModes =
        [
            new MeleeAttack(new Warhammer(), AttackValue),
            new MeleeAttack(new TwoHandedMace(), AttackValue),
            new MeleeAttack(new ShortSword(), AttackValue),
            new MeleeAttack(new Longsword(), AttackValue),
            new RangedAttack(new Shortbow(), AimValue),
            new RangedAttack(new Longbow(), AimValue)
        ];

        AstralMagicResistance = 5;//42;
        MentalMagicResistance = 4;//42;
        PoisonResistance = 9;

        Psi = new PsiPyarron();
        PsiPoints = 25;

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 500;
    }

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100)];
}