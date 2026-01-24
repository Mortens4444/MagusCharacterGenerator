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

    // Change defaults to match standard Matrix behavior
    public float currentScale = 1f;
    public float minScale = 1f;
    public float maxScale = 5f;

    public float translateX = 0f;
    public float translateY = 0f;

    protected override void ConnectHandler(ImageView platformView)
    {
        base.ConnectHandler(platformView);

        // Matrix mode is essential for custom zoom
        platformView.SetScaleType(ImageView.ScaleType.Matrix);

        scaleDetector = new ScaleGestureDetector(platformView.Context, new ScaleListener(this));
        gestureDetector = new GestureDetector(platformView.Context, new GestureListener(this));

        platformView.Touch += OnTouch;

        // Listen for the layout to be ready to calculate initial AspectFit
        platformView.ViewTreeObserver?.AddOnGlobalLayoutListener(new LayoutListener(platformView, this));
    }

    protected override void DisconnectHandler(ImageView platformView)
    {
        platformView.Touch -= OnTouch;
        base.DisconnectHandler(platformView);
        Dispose(true);
    }

    private void OnTouch(object? sender, View.TouchEventArgs e)
    {
        var scaleResult = scaleDetector?.OnTouchEvent(e.Event) ?? false;
        var gestureResult = gestureDetector?.OnTouchEvent(e.Event) ?? false;

        // Mark handled if either detector processed it
        e.Handled = scaleResult || gestureResult || true;
    }

    public void ApplyTransform(ImageView view)
    {
        var matrix = new Matrix();

        // Order is CRITICAL: Scale first, then Translate
        matrix.PostScale(currentScale, currentScale);
        matrix.PostTranslate(translateX, translateY);

        view.ImageMatrix = matrix;
        view.Invalidate();
    }

    // --- LOGIC TO RESET IMAGE TO ASPECT FIT ---
    public void ResetToAspectFit(ImageView view)
    {
        if (view.Drawable == null || view.Width == 0 || view.Height == 0) return;

        var drawable = view.Drawable;
        float viewW = view.Width;
        float viewH = view.Height;
        float imageW = drawable.IntrinsicWidth;
        float imageH = drawable.IntrinsicHeight;

        // Calculate the scale needed to fit the image inside the view
        float scaleX = viewW / imageW;
        float scaleY = viewH / imageH;
        float fitScale = Math.Min(scaleX, scaleY);

        // Update state
        currentScale = fitScale;
        minScale = fitScale;         // Don't let user zoom out smaller than fit
        maxScale = fitScale * 4.0f;  // Max zoom is 4x the starting size

        // Calculate translation to center the image
        float redundantX = viewW - (fitScale * imageW);
        float redundantY = viewH - (fitScale * imageH);

        translateX = redundantX / 2f;
        translateY = redundantY / 2f;

        ApplyTransform(view);
    }

    // --- LISTENERS ---

    private class ScaleListener(ZoomImageHandler handler) : ScaleGestureDetector.SimpleOnScaleGestureListener
    {
        public override bool OnScale(ScaleGestureDetector detector)
        {
            float scaleFactor = detector.ScaleFactor;
            float prevScale = handler.currentScale;

            // Calculate new scale
            handler.currentScale *= scaleFactor;
            // Clamp
            handler.currentScale = Math.Clamp(handler.currentScale, handler.minScale, handler.maxScale);

            // Re-calculate factor based on clamped value to keep math sync
            float effectiveFactor = handler.currentScale / prevScale;

            // Adjust Translation to zoom towards the finger (FocusX/Y)
            // Formula: NewPos = Focus + (OldPos - Focus) * ScaleFactor
            // We rearrange to modify TranslateX directly:

            float focusX = detector.FocusX;
            float focusY = detector.FocusY;

            handler.translateX = (handler.translateX - focusX) * effectiveFactor + focusX;
            handler.translateY = (handler.translateY - focusY) * effectiveFactor + focusY;

            handler.ApplyTransform(handler.PlatformView);
            return true;
        }
    }

    private class GestureListener(ZoomImageHandler handler) : GestureDetector.SimpleOnGestureListener
    {
        public override bool OnScroll(MotionEvent? e1, MotionEvent? e2, float distanceX, float distanceY)
        {
            // Simple panning
            handler.translateX -= distanceX;
            handler.translateY -= distanceY;

            // Optional: You could add logic here to prevent panning the image off-screen

            handler.ApplyTransform(handler.PlatformView);
            return true;
        }

        public override bool OnDoubleTap(MotionEvent e)
        {
            // Reset on double tap
            handler.ResetToAspectFit(handler.PlatformView);
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
        if (disposed) return;
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

internal sealed class LayoutListener : Java.Lang.Object, ViewTreeObserver.IOnGlobalLayoutListener
{
    private readonly ImageView view;
    private readonly ZoomImageHandler handler;

    public LayoutListener(ImageView view, ZoomImageHandler handler)
    {
        this.view = view;
        this.handler = handler;
    }

    public void OnGlobalLayout()
    {
        // Ensure we have dimensions and an image
        if (view.Width > 0 && view.Height > 0 && view.Drawable != null)
        {
            // Remove listener so this only runs once per layout change
            view.ViewTreeObserver?.RemoveOnGlobalLayoutListener(this);

            // Calculate the correct startup Position
            handler.ResetToAspectFit(view);
        }
    }
}