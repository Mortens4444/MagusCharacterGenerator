using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Things;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text.Json.Serialization;

namespace M.A.G.U.S.GameSystem;

public partial class Character
{
    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private Money money = new(0);

    public ObservableCollection<Thing> Equipment { get; init; } = [];

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

    public string TotalEquipmentWeight => (Equipment?.Sum(e => e.Weight) ?? 0).ToString("N1");

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

    public void RemoveEquipment(Thing thing)
    {
        if (Equipment.Remove(thing))
        {
            OnPropertyChanged(nameof(TotalEquipmentWeight));
        }
    }

    public void Sell(Thing thing)
    {
        if (Equipment.Contains(thing))
        {
            Money += thing.MultipliedPrice;
            Equipment.Remove(thing);
            OnPropertyChanged(nameof(Money));
            OnPropertyChanged(nameof(TotalEquipmentWeight));
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
