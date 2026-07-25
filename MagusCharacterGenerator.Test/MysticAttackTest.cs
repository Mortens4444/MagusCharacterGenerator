using M.A.G.U.S.Bestiary;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Magic.Spells.Witch;
using M.A.G.U.S.GameSystem.Psi.Disciplines.Kyr;
using M.A.G.U.S.GameSystem.Psi.Disciplines.Pyarron;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Test;

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

    [Test]
    public void MaxCastsPerRound_IsTenForOneSegmentCastingTime()
    {
        var attack = new PsiAttack(new MindBlast()); // CastingTimeInSegments == 1

        Assert.That(attack.MaxCastsPerRound, Is.EqualTo(10));
    }

    [Test]
    public void MaxCastsPerRound_IsFiveForTwoSegmentCastingTime()
    {
        var attack = new PsiAttack(new PsychicLance()); // CastingTimeInSegments == 2

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
        var creature = new TestCreature([new PsiAttack(new MindBlast()), fallback], psiPoints: 0);

        for (var i = 0; i < 20; i++)
        {
            Assert.That(creature.GetRandomAttackMode(), Is.SameAs(fallback));
        }
    }

    [Test]
    public void GetRandomAttackMode_CanPickPsiAttack_WhenEnoughPsiPoints()
    {
        var psiAttack = new PsiAttack(new MindBlast());
        var creature = new TestCreature([psiAttack], psiPoints: 5);

        Assert.That(creature.GetRandomAttackMode(), Is.SameAs(psiAttack));
    }
}
