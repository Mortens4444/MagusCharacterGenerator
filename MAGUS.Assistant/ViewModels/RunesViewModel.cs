using MAGUS.Assistant.Interfaces;

namespace MAGUS.Assistant.ViewModels;

internal sealed partial class RunesViewModel : SearchListViewModel
{
    public RunesViewModel(ISoundPlayer soundPlayer)
        : base(soundPlayer)
    {
        PageTitle = "Runes";
    }
}
