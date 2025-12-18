using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Things.Weapons;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class CharacterViewModel : BaseViewModel
{
    private CombatValueModifier selectedCombatValueModifier;
    private Character? character;
    private INotifyCollectionChanged? subscribedEquipment;
    private Weapon? primaryWeapon;
    private Weapon? secondaryWeapon;

    public IEnumerable<Alignment> Alignments => [.. Enum.GetValues<Alignment>()];

    public ObservableCollection<CombatValueModifier> AvailableCombatValueModifiers { get; } = [.. Enum.GetValues<CombatValueModifier>()];

    public ObservableCollection<IWeapon> AvailableWeapons { get; } = [];

    public CombatValueModifier SelectedCombatValueModifier
    {
        get => selectedCombatValueModifier;
        set
        {
            if (SetProperty(ref selectedCombatValueModifier, value))
            {
                if (Character != null)
                {
                    Character.SelectedCombatValueModifier = value;
                }
            }
        }
    }

    public Weapon? PrimaryWeapon
    {
        get => primaryWeapon;
        set
        {
            if (SetProperty(ref primaryWeapon, value))
            {
                if (Character != null)
                {
                    Character.PrimaryWeapon = value;
                }
            }
        }
    }

    public Weapon? SecondaryWeapon
    {
        get => secondaryWeapon;
        set
        {
            if (SetProperty(ref secondaryWeapon, value))
            {
                if (Character != null)
                {
                    Character.SecondaryWeapon = value;
                }
            }
        }
    }

    public Character? Character
    {
        get => character;
        protected set
        {
            if (character == value)
            {
                return;
            }

            if (subscribedEquipment != null)
            {
                subscribedEquipment.CollectionChanged -= Equipment_CollectionChanged;
                subscribedEquipment = null;
            }

            SetProperty(ref character, value);
            SetProperty(ref selectedCombatValueModifier, value?.SelectedCombatValueModifier ?? CombatValueModifier.Base, nameof(SelectedCombatValueModifier));
            SetProperty(ref primaryWeapon, value?.PrimaryWeapon, nameof(PrimaryWeapon));
            SetProperty(ref secondaryWeapon, value?.SecondaryWeapon, nameof(SecondaryWeapon));

            if (character?.Equipment is INotifyCollectionChanged nc)
            {
                subscribedEquipment = nc;
                subscribedEquipment.CollectionChanged += Equipment_CollectionChanged;
            }

            RefillAvailableWeapons();

            primaryWeapon = Character?.PrimaryWeapon;
            secondaryWeapon = Character?.SecondaryWeapon;

            OnPropertyChanged(nameof(AvailableWeapons));
            OnPropertyChanged(nameof(PrimaryWeapon));
            OnPropertyChanged(nameof(SecondaryWeapon));

            OnPropertyChanged(nameof(Race));
            OnPropertyChanged(nameof(Class));
            OnPropertyChanged(nameof(Level));
        }
    }

    public string Race => Character?.RaceName ?? String.Empty;

    public string Class => Character?.Class ?? String.Empty;

    public int Level => Character?.Level ?? 1;

    private void Equipment_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e) => RefillAvailableWeapons();
    
    private void RefillAvailableWeapons()
    {
        AvailableWeapons.Clear();

        if (Character?.Equipment == null)
        {
            return;
        }

        foreach (var w in Character.Equipment.OfType<IWeapon>())
        {
            AvailableWeapons.Add(w);
        }
    }
}
