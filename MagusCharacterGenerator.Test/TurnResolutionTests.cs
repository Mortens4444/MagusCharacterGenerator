using MAGUS.Classes.NonPlayableCharacters;
using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Turn;
using MAGUS.Interfaces;
using MAGUS.Models;
using MAGUS.Races;
using MAGUS.Utils;

namespace MAGUS.Test;

internal sealed class FakeCombatRollService : ICombatRollService
{
    private const int SafeLocationRoll = 5; // valid for both HitLocationSelector's 1D9 and 1D10 sub-rolls

    private readonly Queue<int>? sequence;

    public int FixedRoll { get; set; }

    /// <summary>Returns <paramref name="fixedRoll"/> for the 1D100 attack/aim roll, and a roll safely
    /// within HitLocationSelector's ranges for everything else (so callers don't need to reason
    /// about the hit-location sub-rolls that follow a successful attack).</summary>
    public FakeCombatRollService(int fixedRoll)
    {
        FixedRoll = fixedRoll;
    }

    /// <summary>Returns each value in sequence, one per call, regardless of throw type.</summary>
    public FakeCombatRollService(params int[] sequence)
    {
        FixedRoll = sequence.Length > 0 ? sequence[0] : 1;
        this.sequence = new Queue<int>(sequence);
    }

    public Task<int> RollAsync(ThrowType throwType, string title = "")
    {
        if (sequence != null)
        {
            return Task.FromResult(sequence.Count > 0 ? sequence.Dequeue() : FixedRoll);
        }

        return Task.FromResult(throwType == ThrowType._1D100 ? FixedRoll : SafeLocationRoll);
    }

    public Task<int> RollAsync(RollFormula formula, string title = "") => Task.FromResult(FixedRoll);

    public Task<int> RollAsync(DiceThrowFormula formula, string title) => Task.FromResult(FixedRoll);
}

[TestFixture]
public class TurnResolutionTests
{
    private static Character CreateCharacter(string name) =>
        new(new Settings(true), name, new Human(), new Craftsman());

    private static InitiativeEntry CreateInitiativeEntry(Attack attack, out Character attacker, out Character target)
    {
        attacker = CreateCharacter("Attacker");
        target = CreateCharacter("Target");

        return new InitiativeEntry
        {
            Attacker = new CombatantRef(attacker),
            Target = new CombatantRef(target),
            SelectedAttack = attack,
            BaseInitiative = 5
        };
    }

    private static Attack CreateAttack() => new MeleeAttack("Punch", 10, () => 5);

    [TestCase(1, true)]
    [TestCase(1, false)]
    [TestCase(100, true)]
    [TestCase(100, false)]
    public async Task AttackResolution_CreateAsync_ProducesResolution(int roll, bool manual)
    {
        var attack = CreateAttack();
        var entry = CreateInitiativeEntry(attack, out _, out _);
        var rollService = new FakeCombatRollService(roll);

        foreach (var direction in Enum.GetValues<AttackDirection>())
        {
            var resolution = await AttackResolution.CreateAsync(entry, rollService, "title", attack, direction, "hit", manual);
            Assert.That(resolution, Is.Not.Null);
            _ = resolution.Damage;
            resolution.ReduceDamge(1);
            _ = resolution.Impact;
            _ = resolution.BypassesArmor;
        }
    }

    [TestCase(1, true)]
    [TestCase(1, false)]
    [TestCase(100, true)]
    [TestCase(100, false)]
    public async Task AimResolution_CreateAsync_ProducesResolution(int roll, bool manual)
    {
        var attack = CreateAttack();
        var entry = CreateInitiativeEntry(attack, out var attacker, out var target);
        var rollService = new FakeCombatRollService(roll);

        foreach (var movement in Enum.GetValues<MovementType>())
        {
            foreach (var weather in Enum.GetValues<WeatherCondition>())
            {
                foreach (var direction in Enum.GetValues<AttackDirection>())
                {
                    var resolution = await AimResolution.CreateAsync(entry, 10, movement, weather, rollService, "title", attack, direction, "hit", manual);
                    Assert.That(resolution, Is.Not.Null);
                    _ = resolution.Damage;
                }
            }
        }
    }

    [Test]
    public async Task ForcedResolution_CreateAsync_ProducesResolution()
    {
        var attack = CreateAttack();
        var entry = CreateInitiativeEntry(attack, out _, out _);
        var rollService = new FakeCombatRollService(5);

        var resolution = await ForcedResolution.CreateAsync(entry, 12, AttackDirection.Front, rollService, "hit");
        Assert.That(resolution.IsSuccessful, Is.True);
        Assert.That(resolution.Damage, Is.EqualTo(12));
        resolution.ReduceDamge(100);
        Assert.That(resolution.Damage, Is.EqualTo(0));
    }
}

[TestFixture]
public class HitLocationSelectorTests
{
    [Test]
    public async Task GetLocationAsync_CoversAllRollOutcomes()
    {
        foreach (var direction in Enum.GetValues<AttackDirection>())
        {
            for (var outerRoll = 1; outerRoll <= 9; outerRoll++)
            {
                for (var innerRoll = 1; innerRoll <= 10; innerRoll++)
                {
                    var (location, sub) = await HitLocationSelector.GetLocationAsync(direction, new FakeCombatRollService(outerRoll, innerRoll), "title");
                    Assert.That(sub, Is.Not.Null);
                    _ = location;
                }
            }
        }
    }

    [Test]
    public void GetLocation_Synchronous_ReturnsResult()
    {
        var (location, sub) = HitLocationSelector.GetLocation(AttackDirection.Front);
        Assert.That(sub, Is.Not.Null);
        _ = location;
    }
}
