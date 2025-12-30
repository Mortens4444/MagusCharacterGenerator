using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Things.Weapons.CrushingWeapons;
using M.A.G.U.S.Things.Weapons.RangedWeapons;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class DreamCrystal : Creature
{
    public DreamCrystal()
    {
        // Willpower 14 + k6
        Occurrence = Occurrence.VeryRare;
        Size = Size.Maximum_1_meter;

        AttackModes =
        [
            new MentalAttack("Magic or Psi", 55, 5, 10), // Attack with magic has InitiateValue = 55,
            new MeleeAttack(new Warhammer(), AttackValue),
            new MeleeAttack(new TwoHandedMace(), AttackValue),
            new MeleeAttack(new ShortSword(), AttackValue),
            new MeleeAttack(new Longsword(), AttackValue),
            new RangeAttack(new Shortbow(), AimValue),
            new RangeAttack(new Longbow(), AimValue)

        ];
        AttackValue = 35;
        DefenseValue = 96;
        InitiateValue = 25;
        AimValue = 4;
        HealthPoints = 20;
        AstralMagicResistance = 140;
        MentalMagicResistance = 170;
        Psi = new PsiKyrMethod();
        PsiPoints = 70;
        PoisonResistance = Int32.MaxValue;
        Intelligence = Enums.Intelligence.Outstanding;
        ManaPoints = 100;
        Alignment = Enums.Alignment.Various;
        ExperiencePoints = 7500;
    }

    public override string Name => "Dream crystal";

    public override int GetDamage() => 0;

    [DiceThrow(ThrowType._1D3)]
    public override int GetNumberAppearing() => DiceThrow._1D3();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100)];
}
