using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class Ansinatis : Creature
{
    public Ansinatis()
    {
        Occurrence = Occurrence.VeryRare;
        InitiateValue = 35;
        Alignment = GetAlignment();

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Psi = new PsiPyarron(); // Only Telepathy, once a day for D10 + 2 turns
    }

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override int GetDamage() => 0;

    public override string[] Sounds => [];

    public override List<Speed> Speeds => [];

    public PossessionResult GetPossessionResult()
    {
        var throwResult = DiceThrow._1D100();
        var duration = DiceThrow._1D6();

        if (throwResult <= 35)
        {
            return new PossessionResult
            {
                Outcome = PossessionOutcome.Death,
                Duration = TimeSpan.FromHours(duration)
            };
        }

        if (throwResult <= 65)
        {
            return new PossessionResult
            {
                Outcome = PossessionOutcome.TemporaryConfusion,
                Duration = TimeSpan.FromDays(duration)
            };
        }

        if (throwResult <= 85)
        {
            return new PossessionResult
            {
                Outcome = PossessionOutcome.PermanentTakeover,
                Duration = TimeSpan.FromDays(duration)
            };
        }

        return new PossessionResult
        {
            Outcome = PossessionOutcome.DualSoul,
            Duration = TimeSpan.FromDays(duration * 7)
        };
    }

    private Alignment GetAlignment()
    {
        var throwResult = DiceThrow._1D100();

        if (throwResult <= 55)
        {
            return Random.Shared.Next(2) == 0 ? Alignment.Order : Alignment.Life;
        }

        if (throwResult <= 89)
        {
            return GetRandomAlignment();
        }

        if (throwResult <= 95)
        {
            var roll = Random.Shared.Next(3);
            return roll switch
            {
                0 => Alignment.OrderLife,
                1 => Alignment.OrderDeath,
                _ => Alignment.Life
            };
        }

        return Alignment.Death;
    }

    private static Alignment GetRandomAlignment()
    {
        var valid = new Alignment[]
        {
            Alignment.Life,
            Alignment.Death,
            Alignment.Chaos,
            Alignment.Order,
            Alignment.ChaosLife,
            Alignment.OrderLife,
            Alignment.ChaosDeath,
            Alignment.OrderDeath,
            Alignment.LifeChaos,
            Alignment.LifeOrder,
            Alignment.DeathChaos,
            Alignment.DeathOrder
        };

        return valid[Random.Shared.Next(valid.Length)];
    }
}