using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Things.Weapons;
using M.A.G.U.S.Things.Weapons.RangedWeapons;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class CwyvehKah : Creature
{
    public CwyvehKah()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Underground;

        AttackValue = 85;
        DefenseValue = 128;
        InitiateValue = 45;
        AimValue = 65; // 75

        AttacksPerRound = 1;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Claw", ThrowType._1D6), AttackValue),
            new RangedAttack(new HandCrossbow(), AimValue)
        ];

        HealthPoints = 12;
        PainTolerancePoints = 78;

        AstralMagicResistance = 34;
        MentalMagicResistance = 34;
        PoisonResistance = 8;

        Intelligence = Enums.Intelligence.High;

        Psi = new PsiKyrMethod();
        PsiPoints = 50; // vagy változó

        Alignment = Alignment.OrderDeath;
        ExperiencePoints = 350;
    }

    public override string Name => "Cwyveh-Kah";

    // TODO
    public override int GetNumberAppearing()
    {
        var baseNumber = DiceThrow._1D3() + 1; // minimum 2
        return baseNumber % 2 == 0 ? baseNumber : baseNumber + 1;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 130)];
}