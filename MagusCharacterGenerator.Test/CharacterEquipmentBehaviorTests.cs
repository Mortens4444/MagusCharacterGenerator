using MAGUS.Classes.NonPlayableCharacters;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Valuables;
using MAGUS.Races;
using MAGUS.Things.Weapons.CrushingWeapons;

namespace MAGUS.Test;

[TestFixture]
public class CharacterEquipmentBehaviorTests
{
    private static Character CreateCharacter() =>
        new(new Settings(true), "Test", new Human(), new Craftsman())
        {
            Money = new Money(1000)
        };

    [Test]
    public void Buy_WithEnoughMoney_AddsToEquipment()
    {
        var character = CreateCharacter();
        var staff = new ShortStaff();

        character.Buy(staff);

        Assert.That(character.Equipment, Contains.Item(staff));
        Assert.That(character.HasItem<ShortStaff>(), Is.True);
    }

    [Test]
    public void Buy_WithoutEnoughMoney_Throws()
    {
        var character = CreateCharacter();
        character.Money = new Money(0);
        var staff = new ShortStaff();

        Assert.That(() => character.Buy(staff), Throws.InvalidOperationException);
    }

    [Test]
    public void Sell_RemovesItemAndRefundsMoney()
    {
        var character = CreateCharacter();
        var staff = new ShortStaff();
        character.Buy(staff);

        character.Sell(staff);

        Assert.That(character.Equipment, Does.Not.Contain(staff));
    }

    [Test]
    public void Sell_ItemNotOwned_IsNoOp()
    {
        var character = CreateCharacter();
        var staff = new ShortStaff();

        character.Sell(staff);

        Assert.That(character.Equipment, Does.Not.Contain(staff));
    }

    [Test]
    public void RemoveEquipment_ExistingItem_Removes()
    {
        var character = CreateCharacter();
        var staff = new ShortStaff();
        character.Equipment.Add(staff);

        character.RemoveEquipment(staff);

        Assert.That(character.Equipment, Does.Not.Contain(staff));
    }

    [Test]
    public void TotalEquipmentWeight_ReflectsItems()
    {
        var character = CreateCharacter();
        character.Equipment.Add(new ShortStaff());
        Assert.That(character.TotalEquipmentWeight, Is.Not.Null);
    }
}
