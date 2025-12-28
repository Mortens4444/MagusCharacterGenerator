using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Models;
using Mtf.Maui.Controls.Messages;
using Plugin.Maui.Audio;
using System.Reflection;

namespace M.A.G.U.S.Assistant.Platforms.Tizen;

public class SoundPlayer : ISoundPlayer
{
    private IAudioPlayer? audioPlayer;

    public event EventHandler? PlaybackEnded;

    public Task PlayAsync(string sound)
    {
        return PlayAsync(new SoundItem
        {
            ResourceId = EmbeddedResourceHelper.GetResourceId(sound)
        }, 1);
    }

    public Task PlayAndVibrateAsync(string sound)
    {
        return PlayAsync(sound);
    }

    public Task PlayAsync(SoundItem sound, double volume)
    {
        ArgumentNullException.ThrowIfNull(sound);

        Stop();

        try
        {
            var asm = Assembly.GetExecutingAssembly();
            var stream = asm.GetManifestResourceStream(sound.ResourceId)
                ?? throw new FileNotFoundException("Embedded resource not found", sound.ResourceId);

            audioPlayer = AudioManager.Current.CreatePlayer(stream);
            audioPlayer.Volume = volume;
            audioPlayer.PlaybackEnded += OnPlaybackEnded;
            audioPlayer.Play();
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }

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
        MainThread.BeginInvokeOnMainThread(() =>
            PlaybackEnded?.Invoke(this, EventArgs.Empty));
    }
}
