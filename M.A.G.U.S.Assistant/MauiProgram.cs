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

        var pageTypes = new List<Type>
        {
            typeof(AboutPage),
            typeof(BestiaryPage),
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

        var viewModelTypes = new List<Type>
        {
            typeof(AboutPageViewModel),
            typeof(CanvasDrawable),
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

        builder.Services.AddSingleton<DatabaseContext>();
        builder.Services.AddSingleton<CharacterRepository>();
        builder.Services.AddSingleton<SettingsRepository>();

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
}
