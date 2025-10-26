using M.A.G.U.S.Assistant.ViewModels;
using Microsoft.Maui.Layouts;

namespace M.A.G.U.S.Assistant.Views;

internal partial class PaintWizardPage : NotifierPage
{
    private readonly PaintWizardViewModel vm;

    // �llapot drag/paint
    private bool isPanning;
    private double lastPanX, lastPanY;
    private double startTranslationX, startTranslationY;

    public PaintWizardPage()
    {
        InitializeComponent();
        vm = new PaintWizardViewModel();
        BindingContext = vm;

        // alap grid l�trehoz�s (vagy felhaszn�l� hozza l�tre)
        vm.CreateGridCommand.Execute(null);

        // esem�nyek
        //GridCanvas.PointerPressed += GridCanvas_PointerPressed;
        //GridCanvas.PointerMoved += GridCanvas_PointerMoved;
        //GridCanvas.PointerReleased += GridCanvas_PointerReleased;

        // Zoom: a Slider a VM.Zoom-ot �ll�tja � hallgatunk v�ltoz�sra
        vm.PropertyChanged += Vm_PropertyChanged;

        // canvas m�ret�nek friss�t�se
        UpdateCanvasSize();
    }

    private void Vm_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(PaintWizardViewModel.CanvasWidth) ||
            e.PropertyName == nameof(PaintWizardViewModel.CanvasHeight) ||
            e.PropertyName == nameof(PaintWizardViewModel.Zoom))
        {
            UpdateCanvasSize();
            RefreshPlacedItems();
        }
    }

    private void UpdateCanvasSize()
    {
        GridCanvas.WidthRequest = vm.CanvasWidth;
        GridCanvas.HeightRequest = vm.CanvasHeight;

        // ZoomContainer sk�l�z�sa: egyszer�en a Scale tulajdons�got haszn�ljuk
        ZoomContainer.Scale = (float)vm.Zoom;
    }

    private void RefreshPlacedItems()
    {
        // t�r�lj�k a gyerekeket, majd �jra l�trehozzuk (egyszer�)
        GridCanvas.Children.Clear();

        foreach (var p in vm.PlacedItems.ToList())
        {
            var left = p.X * vm.ScaleFactor;
            var top = p.Y * vm.ScaleFactor;
            var w = p.Width * vm.ScaleFactor;
            var h = p.Height * vm.ScaleFactor;

            // ha van k�p, k�sz�t�nk Image-et, k�l�nben BoxView-et
            if (!String.IsNullOrEmpty(p.Image))
            {
                // ha f�jl: ImageSource.FromFile; ha embedded resource: FromResource(...)
                var source = ImageSource.FromFile(p.Image);
                var img = new Image { Source = source, Aspect = Aspect.Fill };
                AbsoluteLayout.SetLayoutBounds(img, new Rect(left, top, w, h));
                AbsoluteLayout.SetLayoutFlags(img, AbsoluteLayoutFlags.None);
                GridCanvas.Children.Add(img);
            }
            else
            {
                var box = new BoxView { Color = Colors.SaddleBrown, Opacity = 0.8 };
                AbsoluteLayout.SetLayoutBounds(box, new Rect(left, top, w, h));
                AbsoluteLayout.SetLayoutFlags(box, AbsoluteLayoutFlags.None);
                GridCanvas.Children.Add(box);
            }

            //if (!String.IsNullOrEmpty(p.Image))
            //{
            //    var img = new Image { Source = p.Image, Aspect = Aspect.Fill };
            //    AbsoluteLayout.SetLayoutBounds(img, new Rect(left, top, w, h));
            //    AbsoluteLayout.SetLayoutFlags(img, AbsoluteLayoutFlags.None);
            //    GridCanvas.Children.Add(img);
            //}
            //else
            //{
            //    var box = new BoxView { Color = Colors.SaddleBrown, Opacity = 0.8 };
            //    AbsoluteLayout.SetLayoutBounds(box, new Rect(left, top, w, h));
            //    AbsoluteLayout.SetLayoutFlags(box, AbsoluteLayoutFlags.None);
            //    GridCanvas.Children.Add(box);
            //}
        }

        // opcion�lisan: rajzold meg a r�csot (gridline-okat)
        DrawGridLines();
    }

    private void DrawGridLines()
    {
        // egyszer� grid: minden 10 cm nagyobb vonalas
        // Ehhez lehetne GraphicsView, de most egyszer� vizu�lis seg�dvonalak nem k�telez�ek.
        // (Ha kell, be�p�thetj�k Microsoft.Maui.Graphics GraphicsView-t)
    }

    #region Pointer (kattint�s, ceruza)
    //private void GridCanvas_PointerPressed(object sender, Microsoft.Maui.Controls.PointerEventArgs e)
    //{
    //    var pt = e.GetPosition(GridCanvas);
    //    // �tv�lt�s: pont (px) -> cm (logikai) (figyelj a Scale-re: GridCanvas m�r sk�l�zva a ZoomContainer-on)
    //    var xCm = (int)Math.Floor(pt.Value.X / vm.ScaleFactor);
    //    var yCm = (int)Math.Floor(pt.Value.Y / vm.ScaleFactor);

    //    if (vm.IsDrawingWalls)
    //    {
    //        vm.ToggleWallCell(xCm, yCm);
    //        RefreshPlacedItems();
    //        return;
    //    }

    //    // Ha van kiv�lasztott paletta elem, elhelyezz�k (snap az adott cellre)
    //    var selected = vm.SelectedPaletteItem;
    //    if (selected != null)
    //    {
    //        var ok = vm.TryPlaceFromPalette(selected, xCm, yCm);
    //        if (ok) RefreshPlacedItems();
    //    }

    //    // panning eset�n (k�s�bb)
    //    isPanning = true;
    //    lastPanX = pt.Value.X;
    //    lastPanY = pt.Value.Y;
    //    startTranslationX = ZoomContainer.TranslationX;
    //    startTranslationY = ZoomContainer.TranslationY;
    //}

    private void GridCanvas_Tapped(object sender, TappedEventArgs e)
    {
        // Megjegyz�s: TapGestureRecognizer maga nem adja vissza az abszol�t X/Y poz�ci�t.
        // Ha poz�ci� kell, l�sd al�bbi "prec�z poz�ci�" r�sz.
        var selected = vm.SelectedPaletteItem;
        if (selected != null)
        {
            // ide m�g csak egyszer�bb elhelyez�st tehetsz (pl. center vagy el�re sz�molt koordin�ta)
            var centerX = (int)(vm.CanvasWidth / (2 * vm.ScaleFactor));
            var centerY = (int)(vm.CanvasHeight / (2 * vm.ScaleFactor));
            if (vm.TryPlaceFromPalette(selected, centerX, centerY))
                RefreshPlacedItems();
        }
    }

    private void GridCanvas_PanUpdated(object sender, PanUpdatedEventArgs e)
    {
        // PanUpdatedEventArgs: e.StatusType, e.TotalX, e.TotalY
        // Ezt haszn�lhatod panning-re (n�zet mozgat�s), illetve rajzol�sra ha megfelel� logik�t �p�tesz.
        if (e.StatusType == GestureStatus.Started)
        {
            // kezd� poz�ci� ment�se, stb.
        }
        else if (e.StatusType == GestureStatus.Running)
        {
            // panning: forgasd / translate a ZoomContainer-t az e.TotalX/e.TotalY alapj�n
            ZoomContainer.TranslationX = startTranslationX + (float)e.TotalX;
            ZoomContainer.TranslationY = startTranslationY + (float)e.TotalY;
        }
        else if (e.StatusType == GestureStatus.Completed || e.StatusType == GestureStatus.Canceled)
        {
            // befejez�s
        }
    }

    //private void GridCanvas_PointerMoved(object sender, Microsoft.Maui.Controls.PointerEventArgs e)
    //{
    //    if (!isPanning) return;
    //    var pt = e.GetPosition(GridCanvas);
    //    var dx = pt.Value.X - lastPanX;
    //    var dy = pt.Value.Y - lastPanY;
    //    ZoomContainer.TranslationX = (float)(startTranslationX + dx);
    //    ZoomContainer.TranslationY = (float)(startTranslationY + dy);
    //}

    //private void GridCanvas_PointerReleased(object sender, Microsoft.Maui.Controls.PointerEventArgs e)
    //{
    //    isPanning = false;
    //}
    #endregion
}