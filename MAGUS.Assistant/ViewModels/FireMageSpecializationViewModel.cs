using MAGUS.Enums;
using System.Windows.Input;

namespace MAGUS.Assistant.ViewModels;

/// <summary>
/// Backs FireMageSpecializationPage - the level-5 "choose your Fire Mage path" prompt (Második
/// Törvénykönyv, "A tűzvarázslók három Útja"). Purely a picker: the actual rule application
/// happens in Character.ApplyFireMageSpecialization once the page closes with a choice made.
/// </summary>
internal sealed partial class FireMageSpecializationViewModel : BaseViewModel
{
    public event EventHandler? CloseRequested;

    private FireMageSpecialization selectedSpecialization = FireMageSpecialization.None;

    public FireMageSpecialization SelectedSpecialization
    {
        get => selectedSpecialization;
        set
        {
            if (SetProperty(ref selectedSpecialization, value))
            {
                OnPropertyChanged(nameof(IsConfirmEnabled));
                OnPropertyChanged(nameof(IsDestructiveFireSelected));
                OnPropertyChanged(nameof(IsLightSelected));
                OnPropertyChanged(nameof(IsSogronSelected));
            }
        }
    }

    public bool IsConfirmEnabled => SelectedSpecialization != FireMageSpecialization.None;

    public bool IsDestructiveFireSelected => SelectedSpecialization == FireMageSpecialization.DestructiveFire;

    public bool IsLightSelected => SelectedSpecialization == FireMageSpecialization.Light;

    public bool IsSogronSelected => SelectedSpecialization == FireMageSpecialization.Sogron;

    public ICommand SelectDestructiveFireCommand => new Command(() => SelectedSpecialization = FireMageSpecialization.DestructiveFire);

    public ICommand SelectLightCommand => new Command(() => SelectedSpecialization = FireMageSpecialization.Light);

    public ICommand SelectSogronCommand => new Command(() => SelectedSpecialization = FireMageSpecialization.Sogron);

    public ICommand ConfirmCommand => new Command(() => CloseRequested?.Invoke(this, EventArgs.Empty), () => IsConfirmEnabled);
}
