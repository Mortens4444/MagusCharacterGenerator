using M.A.G.U.S.Assistant.Database;
using M.A.G.U.S.Assistant.Database.Repositories;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Assistant.ViewModels;
using M.A.G.U.S.Assistant.Views;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace M.A.G.U.S.Assistant;

internal static class MauiProgram
{
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

        RegisterPages(builder);
        RegisterViewModels(builder);
        RegisterRepositories(builder);
        RegisterServices(builder);

        AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
        {
            var exception = args.ExceptionObject as Exception;
            Console.Error.WriteLine($"{exception}");
            Debug.WriteLine($"Global error: {exception}");
        };

        TaskScheduler.UnobservedTaskException += (sender, args) =>
        {
            Console.Error.WriteLine($"{args.Exception}");
            Debug.WriteLine($"Task error: {args.Exception}");
        };

        return builder.Build();
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
    }

    private static void RegisterRepositories(MauiAppBuilder builder)
    {
        var repositoryTypes = new List<Type>
        {
            typeof(CharacterRepository),
            typeof(SettingsRepository)
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
            typeof(CanvasDrawable),
            typeof(CharacterDetailsViewModel),
            typeof(CharacterGeneratorViewModel),
            typeof(CharactersViewModel),
            typeof(ClassesViewModel),
            typeof(CreatureDetailsViewModel),
            typeof(DiceRollViewModel),
            typeof(GraphicsCanvasDrawable),
            typeof(ImagesViewModel),
            typeof(ItemDetailsViewModel),
            typeof(LanguagesViewModel),
            typeof(MarketViewModel),
            typeof(ObjectInspectorViewModel),
            //typeof(PaintViewModel),
            typeof(PaintWizardViewModel),
            typeof(QualificationsViewModel),
            typeof(RacesViewModel),
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
            // typeof(GardenEditorPage),
            typeof(GemstonesPage),
            typeof(ImagePreviewPage),
            typeof(ImagesPage),
            typeof(ItemDetailsPage),
            typeof(LanguagesPage),
            typeof(MagicalObjectsPage),
            typeof(MapPage),
            typeof(MarketPage),
            typeof(NotifierPage),
            typeof(ObjectInspectorPage),
            typeof(PaintWizardPage),
            typeof(PoisonsPage),
            typeof(QualificationsPage),
            typeof(RacesPage),
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
