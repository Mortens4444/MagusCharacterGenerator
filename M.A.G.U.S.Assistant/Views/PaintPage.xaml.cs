using M.A.G.U.S.Assistant.ViewModels;

namespace M.A.G.U.S.Assistant.Views;

public partial class PaintPage : ContentPage
{
    private PaintViewModel ViewModel => BindingContext as PaintViewModel;

    public PaintPage()
    {
        InitializeComponent();

        TouchGrid.GestureRecognizers.Add(new TapGestureRecognizer
        {
            Command = new Command(async () =>
            {
                // próbáljuk lekérni az utolsó tap pozíciót a platform inputból - ez nem mindig pontos.
                // ezért a CommunityToolkit a megbízható út.
                // Egyszerû fallback: középre teszünk, vagy használjuk PanGesture a mozgatáshoz.
                var bounds = CanvasView.Bounds;
                var x = bounds.Width / 2;
                var y = bounds.Height / 2;
                ViewModel?.PlaceShape(x, y);
            })
        });
    }
}