using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Demons;

public sealed class Daronne : Creature
{
    //Különös, misztikus kapcsolat áll fenn a daronne-ok és az ősföld elemi síkja között.Ez a kapcsolat nem közvetlen,
    //csak az ősföld paraelemére, a sötétségre terjed ki. A daronne valós alakját csak kevesen pillanthatják meg,
    //mert állandóan 20E erősségű, 5 m sugarú elemi sötétségkupola övezi. (lásd mozaikmágia - elemi formák) Ez természetesen
    //az infra- és ultralátást is lehetetlenné teszi. Ebben a mágikus sötétségben mindenki a „harc vakon"
    //módosítókkal harcolhat csak - természetesen a vakharc Képzettség csökkenti a levonásokat.
    public Daronne()
    {
        Occurrence = Occurrence.Summoned;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 100;
        DefenseValue = 160;
        InitiateValue = 30;
        AimValue = 0;

        AttacksPerRound = 2;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Shadow Tail", ThrowType._2D10), AttackValue),
            new MeleeAttack(new BodyPart("Claw", ThrowType._1D10), AttackValue)
        ];

        HealthPoints = 20;
        PainTolerancePoints = 48;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Outstanding;

        Psi = new PsiKyrMethod();
        PsiPoints = 80;

        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 1550;
    }

    public override string Name => "Daronne (The Shadow)";

    public override string[] Images => ["daronne.png"];

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    [DiceThrow(ThrowType._2D10)]
    public override int GetDamage() => DiceThrow._2D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 180)];
}