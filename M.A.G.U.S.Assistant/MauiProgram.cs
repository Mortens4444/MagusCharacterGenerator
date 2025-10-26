using Microsoft.Extensions.Logging;

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
            typeof(Views.AboutPage),
            typeof(Views.BestiaryPage),
            typeof(Views.CharacterGeneratorPage),
            typeof(Views.ClassesPage),
            typeof(Views.CreatureDetailsPage),
            typeof(Views.DiceRollPage),
            // typeof(Views.GardenEditorPage),
            typeof(Views.GemstonesPage),
            typeof(Views.ImagePreviewPage),
            typeof(Views.ImagesPage),
            typeof(Views.ItemDetailsPage),
            typeof(Views.LanguagesPage),
            typeof(Views.MagicalObjectsPage),
            typeof(Views.MapPage),
            typeof(Views.MarketPage),
            typeof(Views.NotifierPage),
            typeof(Views.ObjectInspectorPage),
            typeof(Views.PaintWizardPage),
            typeof(Views.PoisonsPage),
            typeof(Views.QualificationsPage),
            typeof(Views.RacesPage),
            typeof(Views.RunesPage),
            typeof(Views.SearchListPage),
            typeof(Views.SoundPage)
        };

        foreach (var pageType in pageTypes)
        {
            Routing.RegisterRoute(pageType.Name, pageType);
        }

        return builder.Build();
    }
}
