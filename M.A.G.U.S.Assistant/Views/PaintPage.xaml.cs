using M.A.G.U.S.Assistant.ViewModels;


namespace M.A.G.U.S.Assistant.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaintPage : NotifierPage
    {
        private PaintViewModel ViewModel => BindingContext as PaintViewModel;


        public PaintPage()
        {
            InitializeComponent();


            // Tap to place selected item at tap position
            var tap = new TapGestureRecognizer { NumberOfTapsRequired = 1 };
            tap.Tapped += (s, e) =>
            {
                var center = new Point(CanvasView.Width / 2, CanvasView.Height / 2);
                // try to use last touch recorded by VM if available
                if (ViewModel.LastTouch.HasValue)
                {
                    var p = ViewModel.LastTouch.Value;
                    ViewModel.PlaceItem(p.X, p.Y);
                }
                else
                {
                    ViewModel.PlaceItem(center.X, center.Y);
                }
            };
            CanvasView.GestureRecognizers.Add(tap);
        }


        // Pan to move selected item
        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if (ViewModel == null) return;


            if (e.StatusType == GestureStatus.Running)
            {
                ViewModel.HandlePan((float)e.TotalX, (float)e.TotalY);
            }
            else if (e.StatusType == GestureStatus.Completed || e.StatusType == GestureStatus.Canceled)
            {
                ViewModel.EndManipulation();
            }
        }


        // Pinch to scale selected item
        private void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            if (ViewModel == null) return;


            if (e.Status == GestureStatus.Running)
            {
                ViewModel.HandlePinch((float)e.Scale);
            }
            else if (e.Status == GestureStatus.Completed || e.Status == GestureStatus.Canceled)
            {
                ViewModel.EndManipulation();
            }
        }

        // kezd�- �s seg�dmez�k (opcion�lis)
        private bool isDrawingStroke = false;

        private void CanvasView_StartInteraction(object sender, Microsoft.Maui.Controls.TouchEventArgs e)
        {
            if (ViewModel == null) return;

            // leggyakoribb: az els� �rint�st haszn�ljuk (single touch)
            var touches = e.Touches;
            if (touches == null || touches.Length == 0) return;
            var p = touches[0];

            // r�gz�tj�k az utols� touch-ot (placement fallback-hoz)
            ViewModel.RecordTouch(p.X, p.Y);

            if (ViewModel.SelectedModeIndex == 1) // Draw mode
            {
                // �j stroke kezdete
                ViewModel.CurrentStroke.Clear();
                ViewModel.CurrentStroke.Add(new PointF(p.X, p.Y));
                isDrawingStroke = true;
                ViewModel.Invalidate();
            }
            else
            {
                // m�s m�dokn�l pl. Select/Place: esetleg kijel�l�s kezdete
                // (itt csak r�gz�tett�k LastTouch-ot fent)
            }
        }

        private void CanvasView_DragInteraction(object sender, Microsoft.Maui.Controls.TouchEventArgs e)
        {
            if (ViewModel == null) return;
            var touches = e.Touches;
            if (touches == null || touches.Length == 0) return;
            var p = touches[0];

            if (ViewModel.SelectedModeIndex == 1) // Draw mode -> gy�jtj�k a mozg�st
            {
                // append �j pont
                ViewModel.CurrentStroke.Add(new PointF(p.X, p.Y));
                ViewModel.Invalidate();
                return;
            }

            // nem-draw m�d: mozgat�s (hit-test alap�)
            if (ViewModel.LastTouch.HasValue)
            {
                var last = ViewModel.LastTouch.Value;
                var dx = p.X - last.X;
                var dy = p.Y - last.Y;

                // ViewModel.HandlePan v�r delta-t (float)
                ViewModel.HandlePan((float)dx, (float)dy);
            }

            // friss�ts�k a LastTouch-ot
            ViewModel.RecordTouch(p.X, p.Y);
        }

        private void CanvasView_EndInteraction(object sender, Microsoft.Maui.Controls.TouchEventArgs e)
        {
            if (ViewModel == null) return;

            if (ViewModel.SelectedModeIndex == 1 && isDrawingStroke)
            {
                // stroke k�sz � itt eld�ntheted, hogy elmented-e (pl. Shapes-be) vagy csak megjelenik
                isDrawingStroke = false;
                // ha akarod, konvert�lhatod CurrentStroke-ot PlacedItem-re vagy Shapes-be
            }
            else
            {
                // m�s m�dokban befejezz�k a manipul�ci�t
                ViewModel.EndManipulation();
            }

            ViewModel.Invalidate();
        }

        private void CanvasView_CancelInteraction(object sender, EventArgs e)
        {
            isDrawingStroke = false;
            ViewModel.EndManipulation();
            ViewModel.Invalidate();
        }
    }
}