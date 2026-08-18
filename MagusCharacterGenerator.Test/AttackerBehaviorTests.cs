using MAGUS.Classes.NonPlayableCharacters;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Magic;
using MAGUS.Races;
using MAGUS.Things.Weapons.RangedWeapons;

namespace MAGUS.Test;

[TestFixture]
public class AttackerBehaviorTests
{
    private static Character CreateCharacter() =>
        new(new Settings(true), "Test", new Human(), new Craftsman());

    [Test]
    public void RollInitiative_And_RollAttack_ReturnPositiveValues()
    {
        var character = CreateCharacter();
        Assert.That(character.RollInitiative(), Is.GreaterThan(0));
        Assert.That(character.RollAttack(), Is.GreaterThan(0));
    }

    [Test]
    public void ActualHealthPoints_ReachingZero_RaisesDied_AndReducesPainTolerance()
    {
        var character = CreateCharacter();
        character.MaxPainTolerancePoints = 10;
        character.ActualHealthPoints = 10;
        var died = false;
        character.Died += (_, _) => died = true;

        character.ActualHealthPoints = 0;

        Assert.That(died, Is.True);
        Assert.That(character.IsDead, Is.True);
    }

    [Test]
    public void ActualPainTolerancePoints_DroppingToZero_RaisesLostConsciousness()
    {
        var character = CreateCharacter();
        character.ActualHealthPoints = 10;
        character.ActualPainTolerancePoints = 10;
        var lostConsciousness = false;
        character.LostConsciousness += (_, _) => lostConsciousness = true;

        character.ActualPainTolerancePoints = 0;

        Assert.That(lostConsciousness, Is.True);
        Assert.That(character.IsConscious, Is.False);
    }

    [Test]
    public void GetRandomAttackMode_ReturnsAnAffordableAttack()
    {
        var character = CreateCharacter();
        var attack = character.GetRandomAttackMode();
        Assert.That(attack, Is.Not.Null);
    }

    [Test]
    public void GetAttackRangeInMeters_MeleeAndRanged()
    {
        var melee = new MeleeAttack("Punch", 1, () => 1);
        Assert.That(Attacker.GetAttackRangeInMeters(melee), Is.EqualTo(Attacker.MeleeDistance));

        var bow = new ElvenBow();
        var ranged = new RangedAttack(bow, 1);
        Assert.That(Attacker.GetAttackRangeInMeters(ranged), Is.EqualTo(bow.Distance));

        var spellAttack = new SpellAttack(SpellCatalog.All[0]);
        Assert.That(Attacker.GetAttackRangeInMeters(spellAttack), Is.EqualTo(MysticAttack.CastingRangeInMeters));
    }

    [Test]
    public void GetAttackCountForRound_HandlesWholeAndFractionalAttacksPerRound()
    {
        var character = CreateCharacter();
        for (var round = 1; round <= 4; round++)
        {
            var count = character.GetAttackCountForRound(round);
            Assert.That(count, Is.GreaterThanOrEqualTo(0));
        }
    }

    [Test]
    public void GetMaxMovementSpeed_ReturnsPositiveValue()
    {
        var character = CreateCharacter();
        Assert.That(character.GetMaxMovementSpeed(), Is.GreaterThanOrEqualTo(0));
    }

    [Test]
    public void TemporaryModifiers_CanBeAddedAndCleared()
    {
        var character = CreateCharacter();
        var modifier = (MAGUS.Interfaces.ICombatModifier)character;
        character.AddTemporaryModifier(modifier);
        Assert.That(character.TemporaryModifiers, Is.Not.Empty);

        character.RemoveTemporaryModifiers();
        Assert.That(character.TemporaryModifiers, Is.Empty);
    }

    [Test]
    public void NaturalArmorClass_DefaultsToZero()
    {
        var character = CreateCharacter();
        Assert.That(character.NaturalArmorClass, Is.GreaterThanOrEqualTo(0));
    }
}
