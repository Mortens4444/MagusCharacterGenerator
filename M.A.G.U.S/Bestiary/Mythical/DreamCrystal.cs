using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Magic.Spells.Mosaic;
using M.A.G.U.S.GameSystem.Psi.Disciplines.Kyr;
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
        PlacesOfOccurrence = TerrainType.Cave;

        AttackModes =
        [
            new PsiAttack(new MindBlast()),
            new SpellAttack(new MagicMissile()),
            new MeleeAttack(new Warhammer(), AttackValue),
            new MeleeAttack(new TwoHandedMace(), AttackValue),
            new MeleeAttack(new ShortSword(), AttackValue),
            new MeleeAttack(new Longsword(), AttackValue),
            new RangedAttack(new Shortbow(), AimValue),
            new RangedAttack(new Longbow(), AimValue)
        ];

        AttackValue = 35;
        DefenseValue = 96;
        InitiateValue = 25;
        AimValue = 4;

        HealthPoints = 20;

        AstralMagicResistance = 140;
        MentalMagicResistance = 170;
        PoisonResistance = Int32.MaxValue;

        Psi = new PsiKyrMethod();
        PsiPoints = 70;
        ManaPoints = 100;

        Intelligence = Enums.Intelligence.Outstanding;
        Alignment = Alignment.Various;
        ExperiencePoints = 7500;
    }

    public override string Name => "Dream crystal";

    [DiceThrowModifier(0)]
    public override int GetDamage() => 0;

    [DiceThrow(ThrowType._1D3)]
    public override int GetNumberAppearing() => DiceThrow._1D3();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100)];
}
