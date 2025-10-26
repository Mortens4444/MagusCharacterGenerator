using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Services;
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
//        // lek�rj�k a param�tert �s castoljuk a v�rt t�pusra
//        var item = NavigationParameterStore.Get<ImageItem>(id);
//        if (item != null)
//        {
//            // haszn�ld az item-et: be�ll�thatod a BindingContext-ot vagy k�zvetlen�l a UI-t
//            BindingContext = new ImagePreviewViewModel(item);
//        }
//        else
//        {
//            // hiba: param�ter nem tal�lhat� � visszal�p�s vagy hiba�zenet
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
