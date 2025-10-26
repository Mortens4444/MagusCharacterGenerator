using M.A.G.U.S.Assistant.ViewModels;
using Microsoft.Maui.Layouts;

namespace M.A.G.U.S.Assistant.Views;

internal partial class PaintWizardPage : NotifierPage
{
    private readonly PaintWizardViewModel vm;

    // állapot drag/paint
    private bool isPanning;
    private double lastPanX, lastPanY;
    private double startTranslationX, startTranslationY;

    public PaintWizardPage()
    {
        InitializeComponent();
        vm = new PaintWizardViewModel();
        BindingContext = vm;

        // alap grid létrehozás (vagy felhasználó hozza létre)
        vm.CreateGridCommand.Execute(null);

        // események
        //GridCanvas.PointerPressed += GridCanvas_PointerPressed;
        //GridCanvas.PointerMoved += GridCanvas_PointerMoved;
        //GridCanvas.PointerReleased += GridCanvas_PointerReleased;

        // Zoom: a Slider a VM.Zoom-ot állítja — hallgatunk változásra
        vm.PropertyChanged += Vm_PropertyChanged;

        // canvas méretének frissítése
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

        // ZoomContainer skálázása: egyszerûen a Scale tulajdonságot használjuk
        ZoomContainer.Scale = (float)vm.Zoom;
    }

    private void RefreshPlacedItems()
    {
        // töröljük a gyerekeket, majd újra létrehozzuk (egyszerû)
        GridCanvas.Children.Clear();

        foreach (var p in vm.PlacedItems.ToList())
        {
            var left = p.X * vm.ScaleFactor;
            var top = p.Y * vm.ScaleFactor;
            var w = p.Width * vm.ScaleFactor;
            var h = p.Height * vm.ScaleFactor;

            // ha van kép, készítünk Image-et, különben BoxView-et
            if (!String.IsNullOrEmpty(p.Image))
            {
                // ha fájl: ImageSource.FromFile; ha embedded resource: FromResource(...)
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

        // opcionálisan: rajzold meg a rácsot (gridline-okat)
        DrawGridLines();
    }

    private void DrawGridLines()
    {
        // egyszerû grid: minden 10 cm nagyobb vonalas
        // Ehhez lehetne GraphicsView, de most egyszerû vizuális segédvonalak nem kötelezõek.
        // (Ha kell, beépíthetjük Microsoft.Maui.Graphics GraphicsView-t)
    }

    #region Pointer (kattintás, ceruza)
    //private void GridCanvas_PointerPressed(object sender, Microsoft.Maui.Controls.PointerEventArgs e)
    //{
    //    var pt = e.GetPosition(GridCanvas);
    //    // átváltás: pont (px) -> cm (logikai) (figyelj a Scale-re: GridCanvas már skálázva a ZoomContainer-on)
    //    var xCm = (int)Math.Floor(pt.Value.X / vm.ScaleFactor);
    //    var yCm = (int)Math.Floor(pt.Value.Y / vm.ScaleFactor);

    //    if (vm.IsDrawingWalls)
    //    {
    //        vm.ToggleWallCell(xCm, yCm);
    //        RefreshPlacedItems();
    //        return;
    //    }

    //    // Ha van kiválasztott paletta elem, elhelyezzük (snap az adott cellre)
    //    var selected = vm.SelectedPaletteItem;
    //    if (selected != null)
    //    {
    //        var ok = vm.TryPlaceFromPalette(selected, xCm, yCm);
    //        if (ok) RefreshPlacedItems();
    //    }

    //    // panning esetén (késõbb)
    //    isPanning = true;
    //    lastPanX = pt.Value.X;
    //    lastPanY = pt.Value.Y;
    //    startTranslationX = ZoomContainer.TranslationX;
    //    startTranslationY = ZoomContainer.TranslationY;
    //}

    private void GridCanvas_Tapped(object sender, TappedEventArgs e)
    {
        // Megjegyzés: TapGestureRecognizer maga nem adja vissza az abszolút X/Y pozíciót.
        // Ha pozíció kell, lásd alábbi "precíz pozíció" rész.
        var selected = vm.SelectedPaletteItem;
        if (selected != null)
        {
            // ide még csak egyszerûbb elhelyezést tehetsz (pl. center vagy elõre számolt koordináta)
            var centerX = (int)(vm.CanvasWidth / (2 * vm.ScaleFactor));
            var centerY = (int)(vm.CanvasHeight / (2 * vm.ScaleFactor));
            if (vm.TryPlaceFromPalette(selected, centerX, centerY))
                RefreshPlacedItems();
        }
    }

    private void GridCanvas_PanUpdated(object sender, PanUpdatedEventArgs e)
    {
        // PanUpdatedEventArgs: e.StatusType, e.TotalX, e.TotalY
        // Ezt használhatod panning-re (nézet mozgatás), illetve rajzolásra ha megfelelõ logikát építesz.
        if (e.StatusType == GestureStatus.Started)
        {
            // kezdõ pozíció mentése, stb.
        }
        else if (e.StatusType == GestureStatus.Running)
        {
            // panning: forgasd / translate a ZoomContainer-t az e.TotalX/e.TotalY alapján
            ZoomContainer.TranslationX = startTranslationX + (float)e.TotalX;
            ZoomContainer.TranslationY = startTranslationY + (float)e.TotalY;
        }
        else if (e.StatusType == GestureStatus.Completed || e.StatusType == GestureStatus.Canceled)
        {
            // befejezés
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