using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Utils;
using Mtf.LanguageService;
using Mtf.Maui.Controls.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class SoundViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private readonly ISoundPlayer soundPlayer;
    private readonly ObservableCollection<SoundItem> allSounds = [];
    public ObservableCollection<SoundItem> FilteredSounds { get; } = [];

    private SoundItem? selectedSound;
    public SoundItem? SelectedSound
    {
        get => selectedSound;
        set
        {
            if (selectedSound == value)
            {
                return;
            }

            selectedSound = value;
            OnPropertyChanged(nameof(SelectedSound));
            OnSelectedSoundChanged();
        }
    }

    private bool isPlaying;
    public bool IsPlaying
    {
        get => isPlaying;
        private set
        {
            if (isPlaying == value)
            {
                return;
            }

            isPlaying = value;
            OnPropertyChanged(nameof(IsPlaying));
            OnPropertyChanged(nameof(CanPlay));
        }
    }
    public bool CanPlay => SelectedSound != null && !IsPlaying;

    private double volume = 1.0;
    public double Volume
    {
        get => volume;
        set
        {
            if (Math.Abs(volume - value) < 0.001)
            {
                return;
            }

            volume = value;
            OnPropertyChanged(nameof(Volume));
            soundPlayer.SetVolume(volume);
        }
    }

    private string searchText = String.Empty;
    public string SearchText
    {
        get => searchText;
        set
        {
            if (searchText == value)
            {
                return;
            }

            searchText = value ?? String.Empty;
            OnPropertyChanged(nameof(SearchText));
            ApplyFilter();
        }
    }

    public ICommand PlayCommand { get; }
    public ICommand StopCommand { get; }

    public SoundViewModel(ISoundPlayer soundPlayer)
    {
        this.soundPlayer = soundPlayer ?? throw new ArgumentNullException(nameof(soundPlayer));
        this.soundPlayer.PlaybackEnded += OnPlaybackEnded;

        PlayCommand = new Command(() =>
            {
                PlayAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            },
            () => CanPlay
        );
        StopCommand = new Command(Stop, () => IsPlaying);

        Volume = 1.0;
        LoadSoundList();
        ApplyFilter();
    }

    private void LoadSoundList()
    {
        allSounds.Clear();

        try
        {
            var asm = Assembly.GetExecutingAssembly();
            var sounds = asm.GetManifestResourceNames()
                .Where(n => n.Contains(".Resources.Raw.", StringComparison.OrdinalIgnoreCase) &&
                    (n.EndsWith(".wav", StringComparison.OrdinalIgnoreCase) ||
                     n.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase)))
                .Select(name =>
                {
                    var display = name.Split('.')[^2];
                    return new SoundItem { ResourceId = name, DisplayName = Lng.Elem(display.ToName()) };
                })
                .OrderBy(s => s.DisplayName);

            foreach (var sound in sounds)
            {
                allSounds.Add(sound);
            }
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    private void ApplyFilter()
    {
        var queryText = (SearchText ?? String.Empty).Trim();
        var filteredSounds = String.IsNullOrEmpty(queryText) ? allSounds
            : new ObservableCollection<SoundItem>(allSounds.Where(s => s.DisplayName.Contains(queryText, StringComparison.OrdinalIgnoreCase)));

        FilteredSounds.Clear();
        foreach (var filteredSound in filteredSounds)
        {
            FilteredSounds.Add(filteredSound);
        }

        OnPropertyChanged(nameof(FilteredSounds));
        ((Command)PlayCommand).ChangeCanExecute();
    }

    private void OnSelectedSoundChanged()
    {
        Stop();
        OnPropertyChanged(nameof(CanPlay));
        ((Command)PlayCommand).ChangeCanExecute();
    }

    private Task PlayAsync()
    {
        if (SelectedSound == null)
        {
            return Task.CompletedTask;
        }

        try
        {
            IsPlaying = true;
            return soundPlayer.PlayAsync(SelectedSound, Volume);
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
            return Task.CompletedTask;
        }
        finally
        {
            ((Command)PlayCommand).ChangeCanExecute();
            ((Command)StopCommand).ChangeCanExecute();
        }
    }

    private void OnPlaybackEnded(object? sender, EventArgs e)
    {
        IsPlaying = false;
        ((Command)PlayCommand).ChangeCanExecute();
        ((Command)StopCommand).ChangeCanExecute();
    }

    private void Stop()
    {
        try
        {
            soundPlayer.Stop();
            IsPlaying = false;
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
        finally
        {
            ((Command)PlayCommand).ChangeCanExecute();
            ((Command)StopCommand).ChangeCanExecute();
        }
    }

    private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}