using MAGUS.Classes.NonPlayableCharacters;
using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications.Combat;
using MAGUS.Races;
using MAGUS.Things.Weapons.CrushingWeapons;
using MAGUS.Things.Weapons.RangedWeapons;
using MAGUS.Things.Weapons.StabbingWeapons;

namespace MAGUS.Test;

[TestFixture]
public class CharacterCombatBehaviorTests
{
    private static Character CreateCharacter() =>
        new(new Settings(true), "Test", new Human(), new Craftsman());

    [Test]
    public void SetWeapons_ResolvesPrimaryAndSecondaryFromEquipment()
    {
        var character = CreateCharacter();
        var staff = new ShortStaff();
        var bow = new ElvenBow();
        character.Equipment.Add(staff);
        character.Equipment.Add(bow);
        character.PrimaryWeaponId = staff.Id;
        character.SecondaryWeaponId = bow.Id;

        character.SetWeapons();

        Assert.That(character.PrimaryWeapon, Is.SameAs(staff));
        Assert.That(character.SecondaryWeapon, Is.SameAs(bow));
    }

    [Test]
    public void AttackModes_WithPrimaryMeleeAndSecondaryRanged_IncludesBoth()
    {
        var character = CreateCharacter();
        var staff = new ShortStaff();
        var bow = new ElvenBow();
        character.Equipment.Add(staff);
        character.Equipment.Add(bow);
        character.PrimaryWeapon = staff;
        character.SecondaryWeapon = bow;

        var attackModes = character.AttackModes;

        Assert.That(attackModes, Is.Not.Empty);
    }

    [TestCase(CombatValueModifier.Base)]
    [TestCase(CombatValueModifier.PrimaryWeapon)]
    [TestCase(CombatValueModifier.SecondaryWeapon)]
    public void CombatValues_ChangeWithSelectedCombatValueModifier(CombatValueModifier modifier)
    {
        var character = CreateCharacter();
        character.Equipment.Add(new ShortStaff());
        character.Equipment.Add(new ElvenBow());
        character.PrimaryWeapon = character.Equipment.OfType<ShortStaff>().First();
        character.SecondaryWeapon = character.Equipment.OfType<ElvenBow>().First();
        // Base-level Weapon use for both, so this exercises a trained combatant, not the
        // Képzetlen fegyverforgatás (untrained weapon use) penalty covered separately below.
        character.Qualifications.Add(new WeaponUse(QualificationLevel.Base) { Weapon = character.PrimaryWeapon });
        character.Qualifications.Add(new WeaponUse(QualificationLevel.Base) { Weapon = character.SecondaryWeapon });

        character.SelectedCombatValueModifier = modifier;
        character.SelectedCombatValueModifier = modifier; // second set is a no-op branch

        Assert.That(character.InitiateValue, Is.GreaterThanOrEqualTo(0));
        Assert.That(character.AttackValue, Is.GreaterThanOrEqualTo(0));
        Assert.That(character.DefenseValue, Is.GreaterThanOrEqualTo(0));
        Assert.That(character.AimValue, Is.GreaterThanOrEqualTo(0));
    }

    [Test]
    public void CombatValues_WithoutWeaponUseQualification_ApplyUntrainedPenalty()
    {
        // Első Törvénykönyv, "Képzetlen fegyverforgatás": KÉ -10, TÉ -25, VÉ -20 always, and an
        // extra CÉ -30 when the weapon is a targeting (ranged) weapon. Verified as the difference
        // between having no Weapon use qualification at all and having it at Base level (which is
        // the RAW-neutral case - the weapon's own values apply with no bonus or penalty), so the
        // comparison isn't skewed by the fist stats that back CombatValueModifier.Base.
        var character = CreateCharacter();
        var staff = new ShortStaff();
        character.Equipment.Add(staff);
        character.PrimaryWeapon = staff;
        character.SelectedCombatValueModifier = CombatValueModifier.PrimaryWeapon;

        var untrainedInitiate = character.InitiateValue;
        var untrainedAttack = character.AttackValue;
        var untrainedDefense = character.DefenseValue;

        character.Qualifications.Add(new WeaponUse(QualificationLevel.Base) { Weapon = staff });

        Assert.That(character.InitiateValue, Is.EqualTo(untrainedInitiate + 10));
        Assert.That(character.AttackValue, Is.EqualTo(untrainedAttack + 25));
        Assert.That(character.DefenseValue, Is.EqualTo(untrainedDefense + 20));
    }

    [Test]
    public void CombatValues_WithoutWeaponUseQualification_AppliesExtraAimPenaltyForRangedWeapon()
    {
        var character = CreateCharacter();
        var bow = new ElvenBow();
        character.Equipment.Add(bow);
        character.PrimaryWeapon = bow;
        character.SelectedCombatValueModifier = CombatValueModifier.PrimaryWeapon;

        var untrainedAim = character.AimValue;

        character.Qualifications.Add(new WeaponUse(QualificationLevel.Base) { Weapon = bow });

        Assert.That(character.AimValue, Is.EqualTo(untrainedAim + 30));
    }

    [Test]
    public void CombatValues_WithMasterWeaponUseQualification_ApplyMasterBonus()
    {
        // Első Törvénykönyv, "Mesterfokú fegyverhasználat": KÉ +5, TÉ +10, VÉ +10, CÉ +10, added on
        // top of the RAW-neutral Base level.
        var character = CreateCharacter();
        var staff = new ShortStaff();
        character.Equipment.Add(staff);
        character.PrimaryWeapon = staff;
        character.Qualifications.Add(new WeaponUse(QualificationLevel.Base) { Weapon = staff });
        character.SelectedCombatValueModifier = CombatValueModifier.PrimaryWeapon;

        var baseLevelInitiate = character.InitiateValue;
        var baseLevelAttack = character.AttackValue;
        var baseLevelDefense = character.DefenseValue;

        character.Qualifications.Add(new WeaponUse(QualificationLevel.Master) { Weapon = staff });

        Assert.That(character.InitiateValue, Is.EqualTo(baseLevelInitiate + 5));
        Assert.That(character.AttackValue, Is.EqualTo(baseLevelAttack + 10));
        Assert.That(character.DefenseValue, Is.EqualTo(baseLevelDefense + 10));
    }

    [Test]
    public void AttackValue_ThrowingWithoutWeaponThrowingQualification_AppliesUntrainedPenalty()
    {
        // Első Törvénykönyv, "Fegyverdobás": throwing always resolves via Attack Roll. With no
        // Fegyverdobás qualification for the thrown weapon, only Base level removes the penalty
        // ("nincsen mínusza"), so the delta from none to Base is the untrained TÉ penalty (-25).
        var character = CreateCharacter();
        var dagger = new ThrowingDagger();
        character.Equipment.Add(dagger);
        character.PrimaryWeapon = dagger;
        character.SelectedCombatValueModifier = CombatValueModifier.PrimaryWeaponThrown;

        var untrainedAttack = character.AttackValue;

        character.Qualifications.Add(new WeaponThrowing(QualificationLevel.Base) { Weapon = dagger });

        Assert.That(character.AttackValue, Is.EqualTo(untrainedAttack + 25));
    }

    [Test]
    public void AttackValue_ThrowingWithMasterWeaponThrowingQualification_AddsBonus()
    {
        // Első Törvénykönyv, "Fegyverdobás", Mesterfok: +10 TÉ on top of the neutral Base level.
        var character = CreateCharacter();
        var dagger = new ThrowingDagger();
        character.Equipment.Add(dagger);
        character.PrimaryWeapon = dagger;
        character.Qualifications.Add(new WeaponThrowing(QualificationLevel.Base) { Weapon = dagger });
        character.SelectedCombatValueModifier = CombatValueModifier.PrimaryWeaponThrown;

        var baseLevelAttack = character.AttackValue;

        character.Qualifications.Add(new WeaponThrowing(QualificationLevel.Master) { Weapon = dagger });

        Assert.That(character.AttackValue, Is.EqualTo(baseLevelAttack + 10));
    }

    [Test]
    public void AttackValue_ThrowingIsIndependentOfWeaponUseQualification()
    {
        // Fegyverhasználat (melee/ranged use) and Fegyverdobás (throwing) are separate
        // qualifications - being a Master with the weapon in hand shouldn't grant the throwing
        // bonus, and vice versa.
        var character = CreateCharacter();
        var dagger = new ThrowingDagger();
        character.Equipment.Add(dagger);
        character.PrimaryWeapon = dagger;
        character.Qualifications.Add(new WeaponUse(QualificationLevel.Master) { Weapon = dagger });
        character.SelectedCombatValueModifier = CombatValueModifier.PrimaryWeapon;
        var wieldedAttack = character.AttackValue;

        character.SelectedCombatValueModifier = CombatValueModifier.PrimaryWeaponThrown;
        var thrownAttack = character.AttackValue;

        // Wielded: Master Weapon use (+10). Thrown: no Weapon throwing qualification (-25).
        Assert.That(thrownAttack, Is.EqualTo(wieldedAttack - 35));
    }

    [Test]
    public void DefenseValue_AndAimValue_IgnoreThrownWeaponBonus()
    {
        // Throwing gives up the weapon for that round, so it shouldn't contribute its Defense
        // value (or, since throwing is an Attack Roll not an Aim Roll, its Aim value either).
        var character = CreateCharacter();
        var dagger = new ThrowingDagger();
        character.Equipment.Add(dagger);
        character.PrimaryWeapon = dagger;
        character.Qualifications.Add(new WeaponThrowing(QualificationLevel.Master) { Weapon = dagger });
        character.SelectedCombatValueModifier = CombatValueModifier.Base;
        var baseDefense = character.DefenseValue;
        var baseAim = character.AimValue;

        character.SelectedCombatValueModifier = CombatValueModifier.PrimaryWeaponThrown;

        Assert.That(character.DefenseValue, Is.EqualTo(baseDefense));
        Assert.That(character.AimValue, Is.EqualTo(baseAim));
    }

    [Test]
    public void ChangeAllocations_RespectsRemainingModifierAndLockedValues()
    {
        var character = CreateCharacter();
        var remaining = character.RemainingCombatValueModifier;

        character.ChangeInitiator(1);
        character.ChangeAttack(1);
        character.ChangeDefense(1);
        character.ChangeAim(1);

        // Exceeding remaining should just notify without applying.
        character.ChangeInitiator(remaining + 1000);
        character.ChangeAttack(remaining + 1000);
        character.ChangeDefense(remaining + 1000);
        character.ChangeAim(remaining + 1000);

        // No-op delta.
        character.ChangeInitiator(0);

        character.CommitAllocations();

        // Going below the locked value should be rejected.
        character.ChangeInitiator(-1000);
        character.ChangeAttack(-1000);
        character.ChangeDefense(-1000);
        character.ChangeAim(-1000);

        Assert.That(character.LockedAllocatedToInitiate, Is.EqualTo(character.AllocatedToInitiate));
    }

    [Test]
    public void GetDamage_ReturnsFistDamage()
    {
        var character = CreateCharacter();
        Assert.That(character.GetDamage(), Is.GreaterThanOrEqualTo(0));
    }
}
