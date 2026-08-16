using MAGUS.Bestiary;
using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Magic.Spells.Witch;
using MAGUS.Interfaces;
using MAGUS.Models;

namespace MAGUS.Test;

[TestFixture]
public class MysticAttackTest
{
    private sealed class TestCreature : Creature
    {
        public TestCreature(List<Attack> attackModes, int psiPoints = 0, int manaPoints = 0)
        {
            AttackModes = attackModes;
            PsiPoints = psiPoints;
            ManaPoints = manaPoints;
        }

        public override int GetNumberAppearing() => 1;

        public override int GetDamage() => 0;

        public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 10)];
    }

    private sealed class TestDiscipline(int castingTimeInSegments = 1) : IPsiDiscipline
    {
        public string Name => "Test discipline";
        public int? Power => 10;
        public int PsiPointCost => 1;
        public MagicResistanceType ResistanceType => MagicResistanceType.Astral;
        public int CastingTimeInSegments => castingTimeInSegments;
        public int DurationInRounds => 1;
        public int GetDamage() => 1;
    }

    [Test]
    public void MaxCastsPerRound_IsTenForOneSegmentCastingTime()
    {
        var attack = new PsiAttack(new TestDiscipline(castingTimeInSegments: 1));

        Assert.That(attack.MaxCastsPerRound, Is.EqualTo(10));
    }

    [Test]
    public void MaxCastsPerRound_IsFiveForTwoSegmentCastingTime()
    {
        var attack = new PsiAttack(new TestDiscipline(castingTimeInSegments: 2));

        Assert.That(attack.MaxCastsPerRound, Is.EqualTo(5));
    }

    [Test]
    public void WitchsCurse_LastsThreeRounds()
    {
        var spell = new WitchsCurse();

        Assert.That(spell.DurationInRounds, Is.EqualTo(3));
    }

    [Test]
    public void GetRandomAttackMode_SkipsPsiAttack_WhenNotEnoughPsiPoints()
    {
        var fallback = new MeleeAttack("Claw", 0, () => 1);
        var creature = new TestCreature([new PsiAttack(new TestDiscipline()), fallback], psiPoints: 0);

        for (var i = 0; i < 20; i++)
        {
            Assert.That(creature.GetRandomAttackMode(), Is.SameAs(fallback));
        }
    }

    [Test]
    public void GetRandomAttackMode_CanPickPsiAttack_WhenEnoughPsiPoints()
    {
        var psiAttack = new PsiAttack(new TestDiscipline());
        var creature = new TestCreature([psiAttack], psiPoints: 5);

        Assert.That(creature.GetRandomAttackMode(), Is.SameAs(psiAttack));
    }
}
