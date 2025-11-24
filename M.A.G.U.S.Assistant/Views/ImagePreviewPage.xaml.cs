using M.A.G.U.S.Assistant.Models;
using System.Reflection;

namespace M.A.G.U.S.Assistant.Views;


//[QueryProperty(nameof(ParamId), "paramId")]
//internal partial class ImagePreviewPage : ContentPage
//{
//    public string ParamId
//    {
//        set
//        {
//            if (String.IsNullOrWhiteSpace(value))
//            {
//                return;
//            }

//            LoadParameter(value);
//        }
//    }

//    private void LoadParameter(string id)
//    {
//        // lekérjük a paramétert és castoljuk a várt típusra
//        var item = NavigationParameterStore.Get<ImageItem>(id);
//        if (item != null)
//        {
//            // használd az item-et: beállíthatod a BindingContext-ot vagy közvetlenül a UI-t
//            BindingContext = new ImagePreviewViewModel(item);
//        }
//        else
//        {
//            // hiba: paraméter nem található — visszalépés vagy hibaüzenet
//            _ = Shell.Current.GoToAsync("..");
//        }
//    }
//}

internal partial class ImagePreviewPage : NotifierPage
{
    private readonly ImageItem item;

    public ImagePreviewPage(ImageItem image)
    {
        InitializeComponent();
        item = image;
        LoadImage();
    }

    private void LoadImage()
    {
        try
        {
            var asm = Assembly.GetExecutingAssembly();
            PreviewImage.Source = ImageSource.FromResource(item.ResourceId, asm);
        }
        catch
        {
            // fallback empty
        }
    }

    private async void CloseClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}
