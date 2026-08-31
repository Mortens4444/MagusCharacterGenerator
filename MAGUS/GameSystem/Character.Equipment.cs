using MAGUS.GameSystem.Valuables;
using MAGUS.Things;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text.Json.Serialization;

namespace MAGUS.GameSystem;

public partial class Character
{
    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private Money money = new(0);

    public ObservableCollection<Thing> Equipment { get; init; } = [];
    
    public List<Thing> StartingEquipment { get; set; } = [];

    public Money Money
    {
        get => money;
        set
        {
            if (money != value)
            {
                money = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Money.Summa));
            }
        }
    }

    public string TotalEquipmentWeight => (Equipment?.Sum(e => e.EffectiveWeight) ?? 0).ToString("N1");

    public void Buy(Thing thing)
    {
        if (Money < thing.MultipliedPrice)
        {
            throw new InvalidOperationException("Cannot afford this item");
        }

        Money -= thing.MultipliedPrice;
        Equipment.Add(thing);
        OnPropertyChanged(nameof(Money));
    }

    public bool HasItem<T>()
    {
        return Equipment.OfType<T>().Any();
    }

    /// <summary>
    /// Adds an item this character didn't buy - loot taken from a defeated enemy (see
    /// EncounterViewModel.OfferLootAsync) rather than a shop purchase, so unlike Buy this never
    /// touches Money. EquipmentOnCollectionChanged already raises the Equipment/TotalEquipmentWeight
    /// notifications for us.
    /// </summary>
    public void AddEquipment(Thing thing) => Equipment.Add(thing);

    public void RemoveEquipment(Thing thing)
    {
        if (Equipment.Remove(thing))
        {
            ClearEquippedReferences(thing);
            OnPropertyChanged(nameof(TotalEquipmentWeight));
        }
    }

    /// <summary>
    /// Call after mutating an owned Thing's RemainingPortions in place (e.g. eating one portion of a
    /// bulk food item - see CharacterCareActions.EatAsync) so TotalEquipmentWeight refreshes even
    /// though Equipment itself didn't gain or lose an item.
    /// </summary>
    public void NotifyEquipmentWeightChanged() => OnPropertyChanged(nameof(TotalEquipmentWeight));

    public void Sell(Thing thing)
    {
        if (Equipment.Contains(thing))
        {
            Money += thing.MultipliedPrice;
            Equipment.Remove(thing);
            ClearEquippedReferences(thing);
            OnPropertyChanged(nameof(Money));
            OnPropertyChanged(nameof(TotalEquipmentWeight));
        }
    }

    /// <summary>
    /// Un-equips <paramref name="thing"/> if it was the PrimaryWeapon/SecondaryWeapon/Armor - called
    /// whenever an item leaves Equipment (RemoveEquipment/Sell) so those pointers never outlive the
    /// item. Without this, PrimaryWeaponId (Character.Combat.cs) kept referencing a Weapon no longer
    /// in Equipment: ResolveWeaponById only searches Equipment, so after a save/reload the weapon
    /// silently vanished (PrimaryWeaponId stayed but PrimaryWeapon resolved to null) - see
    /// Character.Crafting.cs, which already did this for the weapon-crafting consumption paths.
    /// </summary>
    private void ClearEquippedReferences(Thing thing)
    {
        if (PrimaryWeapon == thing)
        {
            PrimaryWeapon = null;
        }

        if (SecondaryWeapon == thing)
        {
            SecondaryWeapon = null;
        }

        if (Armor == thing)
        {
            Armor = null;
        }
    }

    private void EquipmentOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        OnPropertyChanged(nameof(Equipment));
        OnPropertyChanged(nameof(TotalEquipmentWeight));
    }

    private void CalculateGold()
    {
        money.Gold += Classes.Sum(@class => @class.Gold);
    }
}
