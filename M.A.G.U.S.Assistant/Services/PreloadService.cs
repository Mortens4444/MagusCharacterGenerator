using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Bestiary;
using M.A.G.U.S.GameSystem.Runes;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Races;
using M.A.G.U.S.Things;
using M.A.G.U.S.Things.Gemstones;
using M.A.G.U.S.Things.MagicalObjects;
using M.A.G.U.S.Things.Poisons;
using M.A.G.U.S.Things.Weapons;
using M.A.G.U.S.Utils;
using Mtf.Extensions;
using Mtf.LanguageService.MAUI;
using System.Reflection;

namespace M.A.G.U.S.Assistant.Services;

internal sealed class PreloadService
{
    private static readonly Lazy<PreloadService> lazy = new(() => new PreloadService());
    public static PreloadService Instance => lazy.Value;

    private readonly Lock sync = new();
    private Task? initializeTask;

    // Caches (readonly felület)
    public IReadOnlyList<IClass> Classes { get; private set; } = [];
    public IReadOnlyList<Race> Races { get; private set; } = [];
    public IReadOnlyList<Creature> Creatures { get; private set; } = [];
    public IReadOnlyList<Thing> Things { get; private set; } = [];
    public IReadOnlyList<Weapon> Weapons { get; private set; } = [];
    public IReadOnlyList<Gemstone> Gemstones { get; private set; } = [];
    public IReadOnlyList<Rune> Runes { get; private set; } = [];
    public IReadOnlyList<Poison> Poisons { get; private set; } = [];
    public IReadOnlyList<MagicalObject> MagicalObjects { get; private set; } = [];
    public IReadOnlyList<ImageItem> CachedImageItems { get; private set; } = [];
    public IReadOnlyList<SoundItem> AllSounds { get; private set; } = [];
    public IReadOnlyList<Qualification> Qualifications { get; private set; } = [];

    private PreloadService() { }

    /// <summary>
    /// Indítsd el a preloadot. Többször hívható; ugyanazt a Task-ot adja vissza.
    /// Ha biztosan szükséged van a tartalomra mielőtt továbblépsz, await-eld.
    /// Ha csak "in background" akarod, hívd anélkül, hogy await-elnek.
    /// </summary>
    public Task InitializeAsync()
    {
        lock (sync)
        {
            initializeTask ??= InitializeInternalAsync();
            return initializeTask;
        }
    }

    private async Task InitializeInternalAsync()
    {
        try
        {
            var tasks = new List<Task>
            {
                LoadClassesAsync(),
                LoadRacesAsync(),
                LoadCreaturesAsync(),
                LoadThingsAsync(),
                LoadGemstonesAsync(),
                LoadRunesAsync(),
                LoadPoisonsAsync(),
                LoadMagicalObjectsAsync(),
                BuildImageCacheAsync(),
                LoadSoundListAsync(),
                LoadQualificationsAsync()
            };

            await Task.WhenAll(tasks).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new Mtf.Maui.Controls.Messages.ShowErrorMessage(ex));
        }
    }

    private Task LoadClassesAsync()
        => Task.Run(() =>
        {
            try
            {
                var items = "M.A.G.U.S.Classes".CreateInstancesFromNamespace<IClass>()
                    .OrderBy(c => Lng.Elem(c.Name))
                    .ToArray();

                Classes = items;
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new Mtf.Maui.Controls.Messages.ShowErrorMessage(ex));
            }
        });

    private Task LoadRacesAsync()
        => Task.Run(() =>
        {
            try
            {
                var items = "M.A.G.U.S.Races".CreateInstancesFromNamespace<Race>()
                    .OrderBy(r => Lng.Elem(r.Name))
                    .ToArray();

                Races = items;
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new Mtf.Maui.Controls.Messages.ShowErrorMessage(ex));
            }
        });

    private Task LoadCreaturesAsync()
        => Task.Run(() =>
        {
            try
            {
                var items = "M.A.G.U.S.Bestiary".CreateInstancesFromNamespace<Creature>()
                    .OrderBy(c => Lng.Elem(c.Name))
                    .ToArray();

                Creatures = items;
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new Mtf.Maui.Controls.Messages.ShowErrorMessage(ex));
            }
        });

    private Task LoadThingsAsync()
        => Task.Run(() =>
        {
            try
            {
                var items = "M.A.G.U.S.Things".CreateInstancesFromNamespace<Thing>(typeof(INotForSale))
                    .OrderBy(t => Lng.Elem(t.Name))
                    .ToArray();

                Things = items;

                Weapons = [.. items
                    .OfType<Weapon>()
                    .OrderBy(w => Lng.Elem(w.Name))];
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new Mtf.Maui.Controls.Messages.ShowErrorMessage(ex));
            }
        });

    private Task LoadGemstonesAsync()
        => Task.Run(() =>
        {
            try
            {
                var items = "M.A.G.U.S.Things.Gemstones".CreateInstancesFromNamespace<Gemstone>()
                    .OrderBy(g => Lng.Elem(g.Name))
                    .ToArray();

                Gemstones = items;
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new Mtf.Maui.Controls.Messages.ShowErrorMessage(ex));
            }
        });

    private Task LoadRunesAsync()
        => Task.Run(() =>
        {
            try
            {
                var runes = "M.A.G.U.S.GameSystem.Runes".CreateInstancesFromNamespace<Rune>()
                    .OrderBy(r => r.Name)
                    .ToArray();

                Runes = runes;
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new Mtf.Maui.Controls.Messages.ShowErrorMessage(ex));
            }
        });

    private Task LoadPoisonsAsync()
        => Task.Run(() =>
        {
            try
            {
                var poisons = "M.A.G.U.S.Things.Poisons".CreateInstancesFromNamespace<Poison>()
                    .OrderBy(p => Lng.Elem(p.Name))
                    .ToArray();

                Poisons = poisons;
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new Mtf.Maui.Controls.Messages.ShowErrorMessage(ex));
            }
        });

    private Task LoadMagicalObjectsAsync()
        => Task.Run(() =>
        {
            try
            {
                var magicalObjects = "M.A.G.U.S.Things.MagicalObjects".CreateInstancesFromNamespace<MagicalObject>()
                    .OrderBy(m => Lng.Elem(m.Name))
                    .ToArray();

                MagicalObjects = magicalObjects;
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new Mtf.Maui.Controls.Messages.ShowErrorMessage(ex));
            }
        });

    private Task LoadQualificationsAsync()
        => Task.Run(() =>
        {
            try
            {
                var qualifications = "M.A.G.U.S.Qualifications".CreateInstancesFromNamespace<Qualification>()
                    .OrderBy(c => c.Category.Equals("Other", StringComparison.OrdinalIgnoreCase))
                    .ThenBy(q => Lng.Elem(q.Name))
                    .ToArray();

                Qualifications = qualifications;
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new Mtf.Maui.Controls.Messages.ShowErrorMessage(ex));
            }
        });

    private Task BuildImageCacheAsync()
        => Task.Run(() =>
        {
            try
            {
                var list = new List<ImageItem>();
                var interfaceType = typeof(IHaveImage);
                var types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s =>
                    {
                        try { return s.GetTypes(); }
                        catch (ReflectionTypeLoadException e) { return e.Types.Where(t => t != null)!; }
                    })
                    .Where(p => interfaceType.IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract);

                foreach (var type in types)
                {
                    try
                    {
                        var instance = Activator.CreateInstance(type);
                        if (instance is IHaveImage imageProvider)
                        {
                            var nameProperty = type.GetProperty("Name");
                            var displayNameProperty = type.GetProperty("DisplayName");

                            if (imageProvider.Images != null)
                            {
                                foreach (var image in imageProvider.Images)
                                {
                                    if (string.IsNullOrWhiteSpace(image)) continue;

                                    var entityName = nameProperty?.GetValue(instance)?.ToString()
                                                     ?? displayNameProperty?.GetValue(instance)?.ToString()
                                                     ?? String.Empty;

                                    if (string.IsNullOrWhiteSpace(entityName)) continue;

                                    list.Add(new ImageItem
                                    {
                                        ResourceId = image.Trim(),
                                        DisplayName = Lng.Elem(entityName)
                                    });
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // skip problematic type
                        System.Diagnostics.Debug.WriteLine($"Skipping type {type.Name}: {ex.Message}");
                    }
                }

                list = list.OrderBy(x => Lng.Elem(x.DisplayName)).ToList();
                CachedImageItems = list;
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new Mtf.Maui.Controls.Messages.ShowErrorMessage($"Error building image cache: {ex.Message}"));
            }
        });

    private Task LoadSoundListAsync()
        => Task.Run(() =>
        {
            try
            {
                var list = new List<SoundItem>();
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

                list.AddRange(sounds);
                AllSounds = list;
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new Mtf.Maui.Controls.Messages.ShowErrorMessage(ex));
            }
        });
}