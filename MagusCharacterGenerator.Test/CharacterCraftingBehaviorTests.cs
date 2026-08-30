using MAGUS.Classes.NonPlayableCharacters;
using MAGUS.Classes.Sorcerer;
using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications.Scientific;
using MAGUS.Qualifications.Scientific.Psi;
using MAGUS.Races;
using MAGUS.Things.Gemstones;
using MAGUS.Things.MagicalObjects;
using MAGUS.Things.Weapons.CrushingWeapons;

namespace MAGUS.Test;

[TestFixture]
public class CharacterCraftingBehaviorTests
{
    private static Character CreateWizard() =>
        new(new Settings(true), "Test", new Human(), new Wizard());

    private static Character CreateNonWizard() =>
        new(new Settings(true), "Test", new Human(), new Craftsman());

    // Első Törvénykönyv, "Drágakőmágia": makes a Detekció-charged gemstone magic-capable (the
    // cheapest of the three - Detekció 50, Védelem 80, Okozás 100 Mp).
    private const int DetectionTransmutationCost = 50;

    private static Character CreateGemstoneQualifiedWizard()
    {
        var wizard = CreateWizard();
        wizard.Qualifications.Add(new GemstoneMagic(QualificationLevel.Master));
        wizard.Psi = new PsiKyrMethod();
        return wizard;
    }

    [Test]
    public void CanCraftGemstoneMagicItems_WithoutMasterGemstoneMagic_IsFalse()
    {
        var wizard = CreateWizard();
        Assert.That(wizard.CanCraftGemstoneMagicItems, Is.False);
    }

    [Test]
    public void CanCraftGemstoneMagicItems_NonWizardWithMasterGemstoneMagic_IsFalse()
    {
        var character = CreateNonWizard();
        character.Qualifications.Add(new GemstoneMagic(QualificationLevel.Master));

        Assert.That(character.CanCraftGemstoneMagicItems, Is.False);
    }

    [Test]
    public void CanCraftGemstoneMagicItems_WizardWithMasterGemstoneMagic_IsTrue()
    {
        var wizard = CreateWizard();
        wizard.Qualifications.Add(new GemstoneMagic(QualificationLevel.Master));

        Assert.That(wizard.CanCraftGemstoneMagicItems, Is.True);
    }

    [Test]
    public void TryCraftGemstoneWeapon_WithoutQualification_Fails()
    {
        var wizard = CreateWizard();
        wizard.Psi = new PsiKyrMethod();
        var staff = new ShortStaff();
        var agate = new Agate();
        wizard.Equipment.Add(staff);
        wizard.Equipment.Add(agate);
        wizard.ManaPoints = 100;

        var result = wizard.TryCraftGemstoneWeapon(staff, agate, MagicItemEffectType.Detection, 5, out var crafted);

        Assert.That(result, Is.False);
        Assert.That(crafted, Is.Null);
        Assert.That(wizard.Equipment, Does.Contain(staff));
        Assert.That(wizard.Equipment, Does.Contain(agate));
    }

    [Test]
    public void TryCraftGemstoneWeapon_WithoutTrance_Fails()
    {
        // Qualified (Wizard + Master Drágakőmágia) but no Psi at all, so the KyrTrance-based
        // transmutation prerequisite can't be met.
        var wizard = CreateWizard();
        wizard.Qualifications.Add(new GemstoneMagic(QualificationLevel.Master));
        var staff = new ShortStaff();
        var agate = new Agate();
        wizard.Equipment.Add(staff);
        wizard.Equipment.Add(agate);
        wizard.ManaPoints = 100;

        var result = wizard.TryCraftGemstoneWeapon(staff, agate, MagicItemEffectType.Detection, 5, out var crafted);

        Assert.That(result, Is.False);
        Assert.That(crafted, Is.Null);
        Assert.That(wizard.ManaPoints, Is.EqualTo(100));
    }

    [Test]
    public void TryCraftGemstoneWeapon_WithInsufficientMana_Fails()
    {
        var wizard = CreateGemstoneQualifiedWizard();
        var staff = new ShortStaff();
        var agate = new Agate();
        wizard.Equipment.Add(staff);
        wizard.Equipment.Add(agate);
        // Enough for the 5-point charge alone, not enough once the 50 Mp transmutation is added.
        wizard.ManaPoints = 10;

        var result = wizard.TryCraftGemstoneWeapon(staff, agate, MagicItemEffectType.Detection, 5, out var crafted);

        Assert.That(result, Is.False);
        Assert.That(crafted, Is.Null);
        Assert.That(wizard.ManaPoints, Is.EqualTo(10));
    }

    [Test]
    public void TryCraftGemstoneWeapon_Succeeds_ConsumesWeaponGemstoneAndBothManaCosts()
    {
        var wizard = CreateGemstoneQualifiedWizard();
        var staff = new ShortStaff();
        var agate = new Agate();
        wizard.Equipment.Add(staff);
        wizard.Equipment.Add(agate);
        wizard.ManaPoints = DetectionTransmutationCost + 10;

        var result = wizard.TryCraftGemstoneWeapon(staff, agate, MagicItemEffectType.Detection, 6, out var crafted);

        Assert.That(result, Is.True);
        Assert.That(crafted, Is.Not.Null);
        Assert.That(crafted!.TargetItem, Is.SameAs(staff));
        Assert.That(crafted.Gemstone, Is.SameAs(agate));
        Assert.That(crafted.EffectType, Is.EqualTo(MagicItemEffectType.Detection));
        Assert.That(crafted.ManaPoints, Is.EqualTo(6));
        Assert.That(wizard.ManaPoints, Is.EqualTo(DetectionTransmutationCost + 10 - DetectionTransmutationCost - 6));
        Assert.That(wizard.Equipment, Does.Not.Contain(staff));
        Assert.That(wizard.Equipment, Does.Not.Contain(agate));
        Assert.That(wizard.Equipment, Does.Contain(crafted));
    }

    [Test]
    public void TryCraftGemstoneWeapon_ClearsPrimaryWeaponIfConsumed()
    {
        var wizard = CreateGemstoneQualifiedWizard();
        var staff = new ShortStaff();
        var agate = new Agate();
        wizard.Equipment.Add(staff);
        wizard.Equipment.Add(agate);
        wizard.ManaPoints = DetectionTransmutationCost + 10;
        wizard.PrimaryWeapon = staff;

        var result = wizard.TryCraftGemstoneWeapon(staff, agate, MagicItemEffectType.Detection, 5, out _);

        Assert.That(result, Is.True);
        Assert.That(wizard.PrimaryWeapon, Is.Null);
    }

    [Test]
    public void CanCraftRuneMagicItems_WithoutMasterRunicMagic_IsFalse()
    {
        var wizard = CreateWizard();
        Assert.That(wizard.CanCraftRuneMagicItems, Is.False);
    }

    [Test]
    public void CanCraftRuneMagicItems_NonWizardWithMasterRunicMagic_IsFalse()
    {
        var character = CreateNonWizard();
        character.Qualifications.Add(new RunicMagic(QualificationLevel.Master));

        Assert.That(character.CanCraftRuneMagicItems, Is.False);
    }

    [Test]
    public void CanCraftRuneMagicItems_WizardWithMasterRunicMagic_IsTrue()
    {
        var wizard = CreateWizard();
        wizard.Qualifications.Add(new RunicMagic(QualificationLevel.Master));

        Assert.That(wizard.CanCraftRuneMagicItems, Is.True);
    }

    [Test]
    public void TryCraftRuneWeapon_WithoutQualification_Fails()
    {
        var wizard = CreateWizard();
        var staff = new ShortStaff();
        wizard.Equipment.Add(staff);
        wizard.ManaPoints = 200;

        var result = wizard.TryCraftRuneWeapon(staff, 63, out var crafted);

        Assert.That(result, Is.False);
        Assert.That(crafted, Is.Null);
        Assert.That(wizard.Equipment, Does.Contain(staff));
    }

    [Test]
    public void TryCraftRuneWeapon_WithInvalidTier_Fails()
    {
        var wizard = CreateWizard();
        wizard.Qualifications.Add(new RunicMagic(QualificationLevel.Master));
        var staff = new ShortStaff();
        wizard.Equipment.Add(staff);
        wizard.ManaPoints = 200;

        var result = wizard.TryCraftRuneWeapon(staff, 100, out var crafted);

        Assert.That(result, Is.False);
        Assert.That(crafted, Is.Null);
        Assert.That(wizard.ManaPoints, Is.EqualTo(200));
    }

    [Test]
    public void TryCraftRuneWeapon_WithInsufficientMana_Fails()
    {
        var wizard = CreateWizard();
        wizard.Qualifications.Add(new RunicMagic(QualificationLevel.Master));
        var staff = new ShortStaff();
        wizard.Equipment.Add(staff);
        wizard.ManaPoints = 50;

        var result = wizard.TryCraftRuneWeapon(staff, 63, out var crafted);

        Assert.That(result, Is.False);
        Assert.That(crafted, Is.Null);
        Assert.That(wizard.ManaPoints, Is.EqualTo(50));
    }

    [Test]
    public void TryCraftRuneWeapon_Succeeds_ConsumesWeaponAndMana()
    {
        var wizard = CreateWizard();
        wizard.Qualifications.Add(new RunicMagic(QualificationLevel.Master));
        var staff = new ShortStaff();
        wizard.Equipment.Add(staff);
        wizard.ManaPoints = 100;

        var result = wizard.TryCraftRuneWeapon(staff, 63, out var crafted);

        Assert.That(result, Is.True);
        Assert.That(crafted, Is.Not.Null);
        Assert.That(crafted!.TargetItem, Is.SameAs(staff));
        Assert.That(crafted.ManaPoints, Is.EqualTo(63));
        Assert.That(wizard.ManaPoints, Is.EqualTo(37));
        Assert.That(wizard.Equipment, Does.Not.Contain(staff));
        Assert.That(wizard.Equipment, Does.Contain(crafted));
    }

    [Test]
    public void TryCraftRuneWeapon_ClearsPrimaryWeaponIfConsumed()
    {
        var wizard = CreateWizard();
        wizard.Qualifications.Add(new RunicMagic(QualificationLevel.Master));
        var staff = new ShortStaff();
        wizard.Equipment.Add(staff);
        wizard.ManaPoints = 100;
        wizard.PrimaryWeapon = staff;

        var result = wizard.TryCraftRuneWeapon(staff, 63, out _);

        Assert.That(result, Is.True);
        Assert.That(wizard.PrimaryWeapon, Is.Null);
    }

    // Első Törvénykönyv doesn't forbid combining Rúnamágia and Drágakőmágia on the same item - see
    // Character.WrapsAWeapon, which both TryCraftGemstoneWeapon and TryCraftRuneWeapon check the
    // target against, so either can be layered on top of the other's output.
    [Test]
    public void TryCraftGemstoneWeapon_OnAlreadyRuneInscribedWeapon_Succeeds()
    {
        var wizard = CreateWizard();
        wizard.Qualifications.Add(new RunicMagic(QualificationLevel.Master));
        wizard.Qualifications.Add(new GemstoneMagic(QualificationLevel.Master));
        wizard.Psi = new PsiKyrMethod();
        var staff = new ShortStaff();
        wizard.Equipment.Add(staff);
        wizard.ManaPoints = 300;

        Assert.That(wizard.TryCraftRuneWeapon(staff, 63, out var runeSword), Is.True);
        Assert.That(wizard.Equipment, Does.Contain(runeSword));

        var agate = new Agate();
        wizard.Equipment.Add(agate);

        var result = wizard.TryCraftGemstoneWeapon(runeSword!, agate, MagicItemEffectType.Detection, 5, out var gemstoneWeapon);

        Assert.That(result, Is.True);
        Assert.That(gemstoneWeapon, Is.Not.Null);
        Assert.That(gemstoneWeapon!.TargetItem, Is.SameAs(runeSword));
        Assert.That(wizard.Equipment, Does.Not.Contain(runeSword));
        Assert.That(wizard.Equipment, Does.Contain(gemstoneWeapon));
    }

    [Test]
    public void TryCraftRuneWeapon_OnAlreadyGemstoneSetWeapon_Succeeds()
    {
        var wizard = CreateGemstoneQualifiedWizard();
        wizard.Qualifications.Add(new RunicMagic(QualificationLevel.Master));
        var staff = new ShortStaff();
        var agate = new Agate();
        wizard.Equipment.Add(staff);
        wizard.Equipment.Add(agate);
        wizard.ManaPoints = 300;

        Assert.That(wizard.TryCraftGemstoneWeapon(staff, agate, MagicItemEffectType.Detection, 5, out var gemstoneWeapon), Is.True);
        Assert.That(wizard.Equipment, Does.Contain(gemstoneWeapon));

        var result = wizard.TryCraftRuneWeapon(gemstoneWeapon!, 63, out var runeSword);

        Assert.That(result, Is.True);
        Assert.That(runeSword, Is.Not.Null);
        Assert.That(runeSword!.TargetItem, Is.SameAs(gemstoneWeapon));
        Assert.That(wizard.Equipment, Does.Not.Contain(gemstoneWeapon));
        Assert.That(wizard.Equipment, Does.Contain(runeSword));
    }
}
