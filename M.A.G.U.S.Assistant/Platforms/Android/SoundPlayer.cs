using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Services;
using Plugin.Maui.Audio;
using System.Reflection;

namespace M.A.G.U.S.Assistant.Platforms.Android;

public class SoundPlayer : ISoundPlayer
{
    private IAudioPlayer? audioPlayer;

    public event EventHandler? PlaybackEnded;

    public Task PlayAsync(string sound)
    {
        return PlayAsync(new SoundItem { ResourceId = EmbeddedResourceHelper.GetResourceId(sound) }, 1);
    }

    public Task PlayAsync(SoundItem sound, double volume)
    {
        ArgumentNullException.ThrowIfNull(sound);
        Stop();
        if (sound == null)
        {
            return Task.CompletedTask;
        }

        var asm = Assembly.GetExecutingAssembly();
        var stream = asm.GetManifestResourceStream(sound.ResourceId) ?? throw new FileNotFoundException("Embedded resource not found", sound.ResourceId);

        audioPlayer = AudioManager.Current.CreatePlayer(stream);
        audioPlayer.PlaybackEnded += OnPlaybackEnded;
        audioPlayer.Volume = volume;
        audioPlayer.Play();

        return Task.CompletedTask;
    }

    public void Stop()
    {
        if (audioPlayer != null && audioPlayer.IsPlaying)
        {
            audioPlayer.Stop();
            audioPlayer.PlaybackEnded -= OnPlaybackEnded;
            audioPlayer.Dispose();
            audioPlayer = null;
        }
    }

    private void OnPlaybackEnded(object? sender, EventArgs e)
    {
        if (audioPlayer != null)
        {
            OnPlaybackEndedInternal();
            audioPlayer.PlaybackEnded -= OnPlaybackEnded;
        }
    }

    public void SetVolume(double volume)
    {
        if (audioPlayer != null)
        {
            audioPlayer.Volume = volume;
        }
    }

    private void OnPlaybackEndedInternal()
    {
        MainThread.BeginInvokeOnMainThread(() => PlaybackEnded?.Invoke(this, EventArgs.Empty));
    }
}
