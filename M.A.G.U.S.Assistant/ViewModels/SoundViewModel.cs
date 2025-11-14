using M.A.G.U.S.Assistant.Models;
#if ANDROID
using Plugin.Maui.Audio;
#endif
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal class SoundViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private readonly ObservableCollection<SoundItem> allSounds = [];
    public ObservableCollection<SoundItem> FilteredSounds { get; } = [];

    public ObservableCollection<SoundItem> Sounds => FilteredSounds; // backward compatibility

    private SoundItem selectedSound;
    public SoundItem SelectedSound
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
            if (isPlaying == value) return;
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
            if (Math.Abs(volume - value) < 0.001) return;
            volume = value;
            OnPropertyChanged(nameof(Volume));
#if ANDROID
            audioPlayer.Volume = (float)volume;
#endif
        }
    }

    private string searchText = String.Empty;
    public string SearchText
    {
        get => searchText;
        set
        {
            if (searchText == value) return;
            searchText = value ?? String.Empty;
            OnPropertyChanged(nameof(SearchText));
            ApplyFilter();
        }
    }

    public ICommand PlayCommand { get; }
    public ICommand StopCommand { get; }

#if ANDROID
    private IAudioPlayer audioPlayer;
#endif

    public SoundViewModel()
    {
        PlayCommand = new Command(Play, () => CanPlay);
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
            var names = asm.GetManifestResourceNames()
                .Where(n => n.Contains(".Resources.Raw.", StringComparison.OrdinalIgnoreCase) &&
                    (n.EndsWith(".wav", StringComparison.OrdinalIgnoreCase)
                    || n.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase)))
                .OrderBy(n => n);

            foreach (var name in names)
            {
                var display = name.Split('.')[^2];
                allSounds.Add(new SoundItem { ResourceId = name, DisplayName = display });
            }
        }
        catch
        {
            // ignore
        }
    }

    private void ApplyFilter()
    {
        var q = (SearchText ?? String.Empty).Trim();
        var filtered = string.IsNullOrEmpty(q)
            ? allSounds
            : new ObservableCollection<SoundItem>(allSounds.Where(s => s.DisplayName.Contains(q, StringComparison.OrdinalIgnoreCase)));

        FilteredSounds.Clear();
        foreach (var it in filtered)
        {
            FilteredSounds.Add(it);
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

    private void Play()
    {
        if (SelectedSound == null) return;

        try
        {
            var asm = Assembly.GetExecutingAssembly();
            var stream = asm.GetManifestResourceStream(SelectedSound.ResourceId) ?? throw new FileNotFoundException("Embedded resource not found", SelectedSound.ResourceId);

#if ANDROID
            audioPlayer = AudioManager.Current.CreatePlayer(stream);
            audioPlayer.PlaybackEnded += OnPlaybackEnded;
            audioPlayer.Volume = (float)Volume;
            audioPlayer.Play();
#endif
            IsPlaying = true;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Play error: {ex}");
        }

        ((Command)PlayCommand).ChangeCanExecute();
        ((Command)StopCommand).ChangeCanExecute();
    }

    private void OnPlaybackEnded(object? sender, EventArgs e)
    {
#if ANDROID
        if (audioPlayer != null)
        {
            IsPlaying = false;
            OnPropertyChanged(nameof(CanPlay));
            audioPlayer.PlaybackEnded -= OnPlaybackEnded;
        }
#endif
        ((Command)PlayCommand).ChangeCanExecute();
        ((Command)StopCommand).ChangeCanExecute();
    }

    private void Stop()
    {
        try
        {
#if ANDROID
            if (audioPlayer != null && audioPlayer.IsPlaying)
            {
                audioPlayer.Stop();
                audioPlayer.PlaybackEnded -= OnPlaybackEnded;
            }
#endif
            IsPlaying = false;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Stop error: {ex}");
        }
        finally
        {
            ((Command)PlayCommand).ChangeCanExecute();
            ((Command)StopCommand).ChangeCanExecute();
        }
    }

    private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
