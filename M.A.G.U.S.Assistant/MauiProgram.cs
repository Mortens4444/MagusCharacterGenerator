using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Controls;
using M.A.G.U.S.Assistant.Database;
using M.A.G.U.S.Assistant.Database.Repositories;
using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Assistant.ViewModels;
using M.A.G.U.S.Assistant.Views;
using M.A.G.U.S.Interfaces;
using Microsoft.Extensions.Logging;
using Mtf.Maui.Controls.Messages;
using System.Diagnostics;

namespace M.A.G.U.S.Assistant;

internal static class MauiProgram
{
    public static IServiceProvider Services { get; private set; } = null!;

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

#if ANDROID
        builder.Services.AddSingleton<IPrintService, Platforms.Android.PrintService>();
        builder.Services.AddSingleton<ISoundPlayer, Platforms.Android.SoundPlayer>();
        builder.Services.AddSingleton<IShakeService, Platforms.Android.ShakeService>();

        builder.ConfigureMauiHandlers(handlers =>
        {
            handlers.AddHandler<ZoomImage, Platforms.Android.Handlers.ZoomImageHandler>();
        });
#elif WINDOWS
        builder.Services.AddSingleton<IPrintService, Platforms.Windows.PrintService>();
        builder.Services.AddSingleton<ISoundPlayer, Platforms.Windows.SoundPlayer>();
        builder.Services.AddSingleton<IShakeService, Platforms.Windows.ShakeService>();
        builder.Services.AddSingleton<IWindowStateService, Platforms.Windows.WindowsWindowStateService>();
#elif IOS
        builder.Services.AddSingleton<IPrintService, Platforms.iOS.PrintService>();
        builder.Services.AddSingleton<ISoundPlayer, Platforms.iOS.SoundPlayer>();
        builder.Services.AddSingleton<IShakeService, Platforms.iOS.ShakeService>();
#elif MACCATALYST
        builder.Services.AddSingleton<IPrintService, Platforms.MacCatalyst.PrintService>();
        builder.Services.AddSingleton<ISoundPlayer, Platforms.MacCatalyst.SoundPlayer>();
        builder.Services.AddSingleton<IShakeService, Platforms.MacCatalyst.ShakeService>();
#elif TIZEN
        builder.Services.AddSingleton<IPrintService, Platforms.Tizen.PrintService>();
        builder.Services.AddSingleton<ISoundPlayer, Platforms.Tizen.SoundPlayer>();
        builder.Services.AddSingleton<IShakeService, Platforms.Tizen.ShakeService>();
#else
        builder.Services.AddSingleton<IPrintService, StubPrintService>();
        builder.Services.AddSingleton<ISoundPlayer, StubSoundPlayer>();
        builder.Services.AddSingleton<IShakeService, StubShakeService>();
#endif
        RegisterPages(builder);
        RegisterViewModels(builder);
        RegisterRepositories(builder);
        RegisterServices(builder);
        RegisterSingletonServices(builder);

        AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
        {
            if (args.ExceptionObject is Exception exception)
            {
                Console.Error.WriteLine($"{exception}");
                Debug.WriteLine($"Global error: {exception}");
                WeakReferenceMessenger.Default.Send(new ShowErrorMessage(exception));
            }
        };

        TaskScheduler.UnobservedTaskException += (sender, args) =>
        {
            Console.Error.WriteLine($"{args.Exception}");
            Debug.WriteLine($"Task error: {args.Exception}");
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(args.Exception));
            args.SetObserved();
        };
        
        var app = builder.Build();
        Services = app.Services;
        return app;
    }

    private static void RegisterServices(MauiAppBuilder builder)
    {
        var serviceTypes = new List<Type>
        {
            typeof(DatabaseContext),
            typeof(SettingsService),
            typeof(CharacterService)
        };
        foreach (var serviceType in serviceTypes)
        {
            builder.Services.AddTransient(serviceType);
        }
        builder.Services.AddTransient<ISettings, SettingsService>();
    }

    private static void RegisterSingletonServices(MauiAppBuilder builder)
    {
        var serviceTypes = new List<Type>
        {
            //typeof(ShakeService)
        };
        foreach (var serviceType in serviceTypes)
        {
            builder.Services.AddSingleton(serviceType);
        }
    }

    private static void RegisterRepositories(MauiAppBuilder builder)
    {
        var repositoryTypes = new List<Type>
        {
            typeof(CharacterRepository),
            typeof(SettingsRepository),
            typeof(DrawingRepository)
        };
        foreach (var repositoryType in repositoryTypes)
        {
            builder.Services.AddSingleton(repositoryType);
        }
    }

    private static void RegisterViewModels(MauiAppBuilder builder)
    {
        var viewModelTypes = new List<Type>
        {
            typeof(AboutPageViewModel),
            //typeof(CanvasDrawable),
            typeof(CharacterDetailsViewModel),
            typeof(CharacterGeneratorViewModel),
            typeof(CharactersViewModel),
            typeof(ClassesViewModel),
            typeof(CreatureDetailsViewModel),
            typeof(DiceRollViewModel),
            typeof(EncounterViewModel),
            //typeof(GraphicsCanvasDrawable),
            typeof(ImagesViewModel),
            typeof(ItemDetailsViewModel),
            typeof(LanguagesViewModel),
            typeof(ObjectObserverViewModel),
            //typeof(PaintViewModel),
            typeof(PaintWizardViewModel),
            typeof(QualificationsViewModel),
            typeof(RacesViewModel),
            typeof(RollFormulaViewModel),
            typeof(SearchListViewModel),
            typeof(SettingsViewModel),
            typeof(SoundViewModel),
            typeof(WebBrowserViewModel),
        };
        foreach (var viewModelType in viewModelTypes)
        {
            builder.Services.AddTransient(viewModelType);
        }
    }

    private static void RegisterPages(MauiAppBuilder builder)
    {
        var pageTypes = new List<Type>
        {
            typeof(AboutPage),
            typeof(BestiaryPage),
            typeof(CharacterDetailsPage),
            typeof(CharacterGeneratorPage),
            typeof(CharactersPage),
            typeof(ClassesPage),
            typeof(CreatureDetailsPage),
            typeof(DiceRollPage),
            typeof(EncounterPage),
            // typeof(GardenEditorPage),
            typeof(GemstonesPage),
            typeof(ImagePreviewPage),
            typeof(ImagesPage),
            typeof(ItemDetailsPage),
            typeof(LanguagesPage),
            typeof(MagicalObjectsPage),
            typeof(MapPage),
            typeof(MarketPage),
            typeof(ObjectObserverPage),
            typeof(PaintWizardPage),
            typeof(PoisonsPage),
            typeof(QualificationsPage),
            typeof(RacesPage),
            typeof(RollFormulaPage),
            typeof(RunesPage),
            typeof(SearchListPage),
            typeof(SettingsPage),
            typeof(SoundPage)
        };

        foreach (var pageType in pageTypes)
        {
            Routing.RegisterRoute(pageType.Name, pageType);
            builder.Services.AddTransient(pageType);
        }
    }
}
