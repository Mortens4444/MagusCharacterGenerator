using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Services;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage.Streams;

namespace M.A.G.U.S.Assistant.Platforms.Windows;

internal partial class SoundPlayer : ISoundPlayer, IDisposable
{
    private MediaPlayer? windowsPlayer;
    private InMemoryRandomAccessStream? currentStream;

    public event EventHandler? PlaybackEnded;

    public Task PlayAsync(string sound)
    {
        return PlayAsync(new SoundItem { ResourceId = EmbeddedResourceHelper.GetResourceId(sound) }, 1);
    }

    public async Task PlayAsync(SoundItem sound, double volume)
    {
        Stop();

        var asm = Assembly.GetExecutingAssembly();
        var resourceStream = asm.GetManifestResourceStream(sound.ResourceId) ?? throw new FileNotFoundException("Embedded resource not found", sound.ResourceId);

        currentStream = new InMemoryRandomAccessStream();
        var buffer = new byte[8192];
        while (true)
        {
            var memory = new Memory<byte>(buffer);
            var read = await resourceStream.ReadAsync(memory, CancellationToken.None).ConfigureAwait(false);
            if (read <= 0)
            {
                break;
            }

            await currentStream.WriteAsync(buffer.AsBuffer(0, read)).AsTask().ConfigureAwait(false);
        }

        currentStream.Seek(0);

        windowsPlayer = new MediaPlayer
        {
            Volume = (float)volume
        };

        var contentType = sound.ResourceId.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase) ? "audio/mpeg" :
                          sound.ResourceId.EndsWith(".wav", StringComparison.OrdinalIgnoreCase) ? "audio/wav" :
                          "application/octet-stream";

        windowsPlayer.Source = MediaSource.CreateFromStream(currentStream, contentType);
        windowsPlayer.MediaEnded += OnPlaybackEnded;
        windowsPlayer.Play();
    }

    public void Stop()
    {
        if (windowsPlayer != null)
        {
            windowsPlayer.Pause();
            windowsPlayer.MediaEnded -= OnPlaybackEnded;
            windowsPlayer.Dispose();
            windowsPlayer = null;
        }
    }
    
    private void OnPlaybackEnded(MediaPlayer sender, object e)
    {
        if (currentStream != null)
        {
            currentStream.Dispose();
            currentStream = null;
        }
        if (windowsPlayer != null)
        {
            OnPlaybackEndedInternal();
            windowsPlayer.MediaEnded -= OnPlaybackEnded;
        }
    }

    public void SetVolume(double volume)
    {
        if (windowsPlayer != null)
        {
            windowsPlayer.Volume = volume;
        }
    }

    private void OnPlaybackEndedInternal()
    {
        MainThread.BeginInvokeOnMainThread(() => PlaybackEnded?.Invoke(this, EventArgs.Empty));
    }

    public void Dispose()
    {
        Stop();
        if (currentStream != null)
        {
            currentStream.Dispose();
            currentStream = null;
        }
        GC.SuppressFinalize(this);
    }
}
