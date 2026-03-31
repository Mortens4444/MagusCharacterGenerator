using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class Wesen : Creature
{
    public Wesen()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Big;
        PlacesOfOccurrence = TerrainType.Cave | TerrainType.DeepUnderground | TerrainType.Forest;

        AttackValue = 60;
        DefenseValue = 90; // Csáp VÉ-je 100
        InitiateValue = 20;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Tentacle strike", ThrowType._1D6), AttackValue)
        ];

        HealthPoints = 42;
        PainTolerancePoints = 88;

        AstralMagicResistance = 40;
        MentalMagicResistance = 40;
        PoisonResistance = 8;

        Psi = new PsiPyarron();
        PsiPoints = 40;

        Intelligence = Enums.Intelligence.Low;
        Alignment = Alignment.Life;
        ExperiencePoints = 300;
    }

    public override double AttacksPerRound => 6;

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100)];
}