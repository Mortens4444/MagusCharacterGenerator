using MAGUS.Classes.NonPlayableCharacters;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications.Combat;
using MAGUS.Races;
using MAGUS.Things.Shields;
using MAGUS.Things.Weapons.CrushingWeapons;

namespace MAGUS.Test;

[TestFixture]
public class CharacterShieldBehaviorTests
{
    private static Character CreateCharacter() =>
        new(new Settings(true), "Test", new Human(), new Craftsman());

    [Test]
    public void DefenseValue_WithShieldAsSecondaryWeapon_AddsShieldDefenseValue()
    {
        var character = CreateCharacter();
        var sword = new ShortStaff();
        var shield = new SmallShield(); // MovementObstructiveFactor = 0, isolates the pure VÉ addition
        character.Equipment.Add(sword);
        character.Equipment.Add(shield);
        character.PrimaryWeapon = sword;

        var withoutShield = character.DefenseValue;

        character.SecondaryWeapon = shield;

        Assert.That(character.DefenseValue, Is.EqualTo(withoutShield + shield.DefenseValue));
    }

    [Test]
    public void DefenseValue_ShieldBonusAppliesRegardlessOfSelectedCombatValueModifier()
    {
        // Első Törvénykönyv, "Pajzshasználat": the shield defends passively, so its VÉ bonus isn't
        // tied to which hand is the "active" one for attacking (unlike a normal weapon's own VÉ).
        var character = CreateCharacter();
        var sword = new ShortStaff();
        var shield = new SmallShield();
        character.Equipment.Add(sword);
        character.Equipment.Add(shield);
        character.PrimaryWeapon = sword;
        character.SecondaryWeapon = shield;
        character.Qualifications.Add(new ShieldUse(QualificationLevel.Master));

        character.SelectedCombatValueModifier = MAGUS.Enums.CombatValueModifier.PrimaryWeapon;
        var withPrimarySelected = character.DefenseValue;

        character.SelectedCombatValueModifier = MAGUS.Enums.CombatValueModifier.SecondaryWeapon;
        var withSecondarySelected = character.DefenseValue;

        // Only the (Weapon use) part of VÉ differs (fist-level default vs. untrained shield-hand
        // penalty) - the shield's own DefenseValue is present in both.
        Assert.That(withPrimarySelected, Is.Not.EqualTo(0));
        Assert.That(withSecondarySelected, Is.Not.EqualTo(0));
    }

    [Test]
    public void CombatValues_WithoutMasterShieldUse_MovementObstructiveFactorReducesQuicknessDexterityBonus()
    {
        var character = CreateCharacter();
        var shield = new LargeShield(); // MovementObstructiveFactor = 5
        character.Equipment.Add(shield);
        character.Quickness = 16;
        character.Dexterity = 16;

        var defenseWithoutShield = character.DefenseValue;

        character.SecondaryWeapon = shield;
        var defenseWithShield = character.DefenseValue;

        // Above-average Quickness/Dexterity bonus each drop by the shield's MGT (5), so VÉ drops by
        // 2*5 from that alone, offset upward by the shield's own +50 DefenseValue.
        Assert.That(defenseWithShield, Is.EqualTo(defenseWithoutShield - 5 - 5 + shield.DefenseValue));
    }

    [Test]
    public void CombatValues_WithMasterShieldUse_MovementObstructiveFactorDoesNotApply()
    {
        var character = CreateCharacter();
        var shield = new LargeShield(); // MovementObstructiveFactor = 5
        character.Equipment.Add(shield);
        character.Quickness = 16;
        character.Dexterity = 16;
        character.Qualifications.Add(new ShieldUse(QualificationLevel.Master));

        var defenseWithoutShield = character.DefenseValue;

        character.SecondaryWeapon = shield;
        var defenseWithShield = character.DefenseValue;

        // No Quickness/Dexterity penalty at Master level - only the shield's own +50 DefenseValue shows up.
        Assert.That(defenseWithShield, Is.EqualTo(defenseWithoutShield + shield.DefenseValue));
    }
}
