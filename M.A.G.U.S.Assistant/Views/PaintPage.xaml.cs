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
                // pr�b�ljuk lek�rni az utols� tap poz�ci�t a platform inputb�l - ez nem mindig pontos.
                // ez�rt a CommunityToolkit a megb�zhat� �t.
                // Egyszer� fallback: k�z�pre tesz�nk, vagy haszn�ljuk PanGesture a mozgat�shoz.
                var bounds = CanvasView.Bounds;
                var x = bounds.Width / 2;
                var y = bounds.Height / 2;
                ViewModel?.PlaceShape(x, y);
            })
        });
    }
}