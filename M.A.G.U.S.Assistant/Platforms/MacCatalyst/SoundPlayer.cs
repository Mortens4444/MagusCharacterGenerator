using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Services;
using Plugin.Maui.Audio;
using System.Reflection;

namespace M.A.G.U.S.Assistant.Platforms.MacCatalyst;

public class SoundPlayer : ISoundPlayer
{
    private IAudioPlayer? audioPlayer;

    public event EventHandler? PlaybackEnded;

    public Task PlayAsync(string sound)
    {
        return PlayAsync(
            new SoundItem { ResourceId = EmbeddedResourceHelper.GetResourceId(sound) },
            1
        );
    }

    public Task PlayAndVibrateAsync(string sound)
    {
        // Mac Catalyst: nincs vibration → csak lejátszás
        return PlayAsync(sound);
    }

    public Task PlayAsync(SoundItem sound, double volume)
    {
        ArgumentNullException.ThrowIfNull(sound);

        Stop();

        var asm = Assembly.GetExecutingAssembly();
        var stream = asm.GetManifestResourceStream(sound.ResourceId)
            ?? throw new FileNotFoundException(
                "Embedded resource not found",
                sound.ResourceId
            );

        audioPlayer = AudioManager.Current.CreatePlayer(stream);
        audioPlayer.Volume = volume;
        audioPlayer.PlaybackEnded += OnPlaybackEnded;
        audioPlayer.Play();

        return Task.CompletedTask;
    }

    public void Stop()
    {
        if (audioPlayer == null)
        {
            return;
        }

        if (audioPlayer.IsPlaying)
        {
            audioPlayer.Stop();
        }

        audioPlayer.PlaybackEnded -= OnPlaybackEnded;
        audioPlayer.Dispose();
        audioPlayer = null;
    }

    public void SetVolume(double volume)
    {
        if (audioPlayer != null)
        {
            audioPlayer.Volume = volume;
        }
    }

    private void OnPlaybackEnded(object? sender, EventArgs e)
    {
        if (audioPlayer == null)
        {
            return;
        }

        audioPlayer.PlaybackEnded -= OnPlaybackEnded;
        OnPlaybackEndedInternal();
    }

    private void OnPlaybackEndedInternal()
    {
        MainThread.BeginInvokeOnMainThread(() =>
            PlaybackEnded?.Invoke(this, EventArgs.Empty)
        );
    }
}
