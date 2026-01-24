using Android.Graphics;
using Android.Views;
using Android.Widget;
using Microsoft.Maui.Handlers;
using View = Android.Views.View;

namespace M.A.G.U.S.Assistant.Platforms.Android.Handlers;

internal class ZoomImageHandler : ImageHandler, IDisposable
{
    private ScaleGestureDetector? scaleDetector;
    private GestureDetector? gestureDetector;
    private bool disposed;

    private float scale = 1f;
    private const float MaxScale = 4f;
    private const float MinScale = 1f;

    private float translateX;
    private float translateY;
    private float lastFocusX;
    private float lastFocusY;

    protected override void ConnectHandler(ImageView platformView)
    {
        base.ConnectHandler(platformView);

        platformView.SetScaleType(ImageView.ScaleType.Matrix);
        scaleDetector = new ScaleGestureDetector(platformView.Context, new ScaleListener(this));
        gestureDetector = new GestureDetector(platformView.Context, new GestureListener(this));

        platformView.Touch += OnTouch;
        platformView.Clickable = true;
        platformView.Focusable = true;
        platformView.FocusableInTouchMode = true;
        //platformView.ViewTreeObserver?.AddOnGlobalLayoutListener(new LayoutListener(platformView, this));
    }

    protected override void DisconnectHandler(ImageView platformView)
    {
        if (platformView != null)
        {
            platformView.Touch -= OnTouch;
        }
        base.DisconnectHandler(platformView);
        Dispose(true);
    }

    // Replace the OnTouch method signature to match EventHandler<View.TouchEventArgs>
    private void OnTouch(object? sender, View.TouchEventArgs e)
    {
        if (e.Event == null)
        {
            e.Handled = false;
            return;
        }

        bool handled = false;

        if (scaleDetector != null)
        {
            handled = scaleDetector.OnTouchEvent(e.Event);
        }

        if (gestureDetector != null)
        {
            handled |= gestureDetector.OnTouchEvent(e.Event);
        }

        e.Handled = handled;
    }

    public void ApplyTransform(ImageView view)
    {
        if (view == null) return;
        var matrix = new Matrix();
        matrix.PostScale(scale, scale);
        matrix.PostTranslate(translateX, translateY);
        view.ImageMatrix = matrix;
        view.Invalidate();
    }

    private class ScaleListener : ScaleGestureDetector.SimpleOnScaleGestureListener
    {
        private readonly ZoomImageHandler handler;

        public ScaleListener(ZoomImageHandler handler)
        {
            this.handler = handler;
        }

        public override bool OnScaleBegin(ScaleGestureDetector detector)
        {
            handler.lastFocusX = detector.FocusX;
            handler.lastFocusY = detector.FocusY;
            return true;
        }

        public override bool OnScale(ScaleGestureDetector detector)
        {
            if (handler.PlatformView == null)
            {
                return false;
            }

            float oldScale = handler.scale;
            handler.scale *= detector.ScaleFactor;
            handler.scale = Math.Clamp(handler.scale, MinScale, MaxScale);

            if (Math.Abs(oldScale - handler.scale) < 0.001f)
            {
                return true; // Nem változott, nincs mit csinálni
            }

            // Az érintési pont körüli nagyítás
            float focusX = detector.FocusX;
            float focusY = detector.FocusY;

            // Kompenzáljuk az eltolást, hogy a focus pont helyben maradjon
            float scaleFactor = handler.scale / oldScale;
            handler.translateX = focusX + (handler.translateX - focusX) * scaleFactor;
            handler.translateY = focusY + (handler.translateY - focusY) * scaleFactor;

            handler.ApplyTransform(handler.PlatformView);
            return true;
        }
    }

    private class GestureListener : GestureDetector.SimpleOnGestureListener
    {
        private readonly ZoomImageHandler handler;

        public GestureListener(ZoomImageHandler handler)
        {
            this.handler = handler;
        }

        public override bool OnScroll(MotionEvent? e1, MotionEvent? e2, float distanceX, float distanceY)
        {
            if (handler.PlatformView == null || handler.scale <= 1f)
            {
                return false;
            }

            // distanceX/Y már helyes irányú, csak ki kell vonni
            handler.translateX -= distanceX;
            handler.translateY -= distanceY;

            handler.ApplyTransform(handler.PlatformView);
            return true;
        }

        public override bool OnDoubleTap(MotionEvent? e)
        {
            if (handler.PlatformView == null)
            {
                return false;
            }

            // Reset
            handler.scale = 1f;
            handler.translateX = 0f;
            handler.translateY = 0f;

            handler.ApplyTransform(handler.PlatformView);
            return true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
            return;

        if (disposing)
        {
            scaleDetector?.Dispose();
            gestureDetector?.Dispose();
            scaleDetector = null;
            gestureDetector = null;
        }

        disposed = true;
    }
}
