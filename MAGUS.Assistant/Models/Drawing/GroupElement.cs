using MAGUS.Assistant.Interfaces;

namespace MAGUS.Assistant.Models.Drawing;

/// <summary>
/// Several primitive elements (rectangles, circles, ...) moved/rotated/resized together as one unit
/// - the shape behind the predefined map objects (tree, rock, table, chair - see
/// PaintWizardViewModel.PredefinedObjects) stamped onto the canvas as a single group instead of
/// several independent, individually-selectable shapes.
/// </summary>
internal sealed class GroupElement : IDrawableElement
{
    /// <summary>Not meaningful for a group (its look comes entirely from Children) - kept only because IDrawableElement requires it.</summary>
    public Color Color { get; set; } = Colors.Transparent;

    public required List<IDrawableElement> Children { get; set; }

    public float Rotation { get; set; }

    public void Draw(ICanvas canvas)
    {
        foreach (var child in Children)
        {
            child.Draw(canvas);
        }
    }

    public bool Contains(PointF point) => Children.Any(child => child.Contains(point));

    public void Move(float dx, float dy)
    {
        foreach (var child in Children)
        {
            child.Move(dx, dy);
        }
    }

    public PointF GetCenter()
    {
        if (Children.Count == 0)
        {
            return PointF.Zero;
        }

        var centers = Children.Select(c => c.GetCenter()).ToList();
        return new PointF(centers.Average(c => c.X), centers.Average(c => c.Y));
    }

    /// <summary>
    /// Only tracks the group's own Rotation - PaintCanvasDrawable.DrawElement already wraps every
    /// top-level element's Draw call in a canvas rotation around GetCenter(), which rotates all
    /// children (and their relative positions) rigidly as one shape. Also moving the children here
    /// would double-apply the rotation on top of that canvas transform.
    /// </summary>
    public void Rotate(float angleDegrees)
    {
        Rotation += angleDegrees;
    }

    /// <summary>Scales each child's own size and spreads them further from (or pulls them closer to) the shared center, so the group grows as a whole instead of each child just growing in place.</summary>
    public void Resize(float scale)
    {
        if (scale <= 0)
        {
            return;
        }

        var center = GetCenter();

        foreach (var child in Children)
        {
            var childCenter = child.GetCenter();
            var dx = (childCenter.X - center.X) * (scale - 1);
            var dy = (childCenter.Y - center.Y) * (scale - 1);

            child.Resize(scale);
            child.Move(dx, dy);
        }
    }
}
