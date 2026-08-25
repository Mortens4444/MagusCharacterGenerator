using MAGUS.Assistant.Enums;
using MAGUS.Assistant.Interfaces;

namespace MAGUS.Assistant.Models.Drawing;

/// <summary>
/// Builds the map-icon GroupElements stamped onto the canvas by PaintTool.Stamp (see
/// PaintWizardViewModel.SelectedPredefinedObject and PaintWizardPage.OnTouchStart) - top-down,
/// schematic shapes built from RectangleElement/CircleElement/LineElement (no rotated-shape rendering
/// needed, since PaintCanvasDrawable only ever rotates a *top-level* element as a rigid whole).
/// </summary>
internal static class PredefinedObjects
{
    public static GroupElement Create(PredefinedObjectType type, PointF at) => type switch
    {
        PredefinedObjectType.Tree => CreateTree(at),
        PredefinedObjectType.Rock => CreateRock(at),
        PredefinedObjectType.Table => CreateTable(at),
        PredefinedObjectType.Chair => CreateChair(at),
        _ => throw new NotSupportedException($"Unknown predefined object type: {type}")
    };

    /// <summary>Trunk intentionally omitted - a wide, bold-outlined cluster of clumps forms the canopy, with thin seam lines marking where clumps meet so it doesn't just read as stacked circles.</summary>
    private static GroupElement CreateTree(PointF at)
    {
        const float outline = 3f;

        var shadow = new CircleElement { Color = Color.FromArgb("#1F3D20"), FillColor = Color.FromArgb("#1F3D20"), Center = new PointF(at.X + 6, at.Y + 12), Radius = 34f };
        var main = new CircleElement { Color = Colors.DarkGreen, FillColor = Colors.ForestGreen, Center = new PointF(at.X, at.Y + 2), Radius = 36f, Thickness = outline };
        var left = new CircleElement { Color = Colors.DarkGreen, FillColor = Colors.SeaGreen, Center = new PointF(at.X - 24, at.Y - 4), Radius = 22f, Thickness = outline };
        var right = new CircleElement { Color = Colors.DarkGreen, FillColor = Colors.SeaGreen, Center = new PointF(at.X + 24, at.Y - 8), Radius = 21f, Thickness = outline };
        var topLeft = new CircleElement { Color = Colors.DarkGreen, FillColor = Colors.MediumSeaGreen, Center = new PointF(at.X - 14, at.Y - 28), Radius = 18f, Thickness = outline };
        var topRight = new CircleElement { Color = Colors.DarkGreen, FillColor = Colors.MediumSeaGreen, Center = new PointF(at.X + 14, at.Y - 30), Radius = 17f, Thickness = outline };
        var top = new CircleElement { Color = Colors.DarkGreen, FillColor = Colors.MediumSeaGreen, Center = new PointF(at.X, at.Y - 42), Radius = 15f, Thickness = outline };
        var highlight1 = new CircleElement { Color = Colors.LightGreen, FillColor = Colors.LightGreen, Center = new PointF(at.X - 12, at.Y - 16), Radius = 12f };
        var highlight2 = new CircleElement { Color = Colors.PaleGreen, FillColor = Colors.PaleGreen, Center = new PointF(at.X + 10, at.Y - 22), Radius = 8f };

        var seamLeft = new LineElement { Color = Colors.DarkGreen, Thickness = 1.5f, Points = [new PointF(at.X - 12, at.Y - 20), new PointF(at.X - 22, at.Y - 10)] };
        var seamRight = new LineElement { Color = Colors.DarkGreen, Thickness = 1.5f, Points = [new PointF(at.X + 12, at.Y - 18), new PointF(at.X + 22, at.Y - 8)] };
        var seamTop = new LineElement { Color = Colors.DarkGreen, Thickness = 1.5f, Points = [new PointF(at.X, at.Y - 30), new PointF(at.X - 4, at.Y - 16)] };

        return new GroupElement { Children = [shadow, main, left, right, topLeft, topRight, top, highlight1, highlight2, seamLeft, seamRight, seamTop] };
    }

    /// <summary>An irregular cluster of overlapping lobes (not one clean circle) plus a crack line and a couple of loose rectangular rubble chips at the base, so the silhouette reads as broken stone rather than a ball.</summary>
    private static GroupElement CreateRock(PointF at)
    {
        var shadow = new CircleElement { Color = Colors.DimGray, FillColor = Colors.DimGray, Center = new PointF(at.X + 8, at.Y + 12), Radius = 14f };
        var main = new CircleElement { Color = Colors.DimGray, FillColor = Colors.Gray, Center = new PointF(at.X, at.Y + 2), Radius = 20f };
        var bulgeLeft = new CircleElement { Color = Colors.DimGray, FillColor = Colors.DarkGray, Center = new PointF(at.X - 16, at.Y + 4), Radius = 12f };
        var bulgeRight = new CircleElement { Color = Colors.DimGray, FillColor = Colors.Gray, Center = new PointF(at.X + 14, at.Y - 4), Radius = 11f };
        var bulgeTop = new CircleElement { Color = Colors.DimGray, FillColor = Colors.LightSlateGray, Center = new PointF(at.X - 6, at.Y - 16), Radius = 10f };
        var highlight = new CircleElement { Color = Colors.Gainsboro, FillColor = Colors.Gainsboro, Center = new PointF(at.X - 12, at.Y - 10), Radius = 6f };

        var crack = new LineElement { Color = Color.FromArgb("#333333"), Thickness = 1.5f, Points = [new PointF(at.X - 10, at.Y - 6), new PointF(at.X + 6, at.Y + 10)] };

        var chip1 = new RectangleElement { Color = Colors.DimGray, FillColor = Colors.DarkGray, Rect = new RectF(at.X + 13, at.Y + 14, 7, 5) };
        var chip2 = new RectangleElement { Color = Colors.DimGray, FillColor = Colors.Gray, Rect = new RectF(at.X - 25, at.Y + 15, 6, 6) };

        return new GroupElement { Children = [shadow, main, bulgeLeft, bulgeRight, bulgeTop, highlight, crack, chip1, chip2] };
    }

    private static GroupElement CreateTable(PointF at)
    {
        var top = new RectangleElement { Color = Colors.SaddleBrown, FillColor = Colors.Peru, Rect = new RectF(at.X - 30, at.Y - 20, 60, 40) };

        return new GroupElement { Children = [top] };
    }

    private static GroupElement CreateChair(PointF at)
    {
        const float seatSize = 22f;
        const float backHeight = 6f;

        var seat = new RectangleElement { Color = Colors.SaddleBrown, FillColor = Colors.BurlyWood, Rect = new RectF(at.X - (seatSize / 2), at.Y - (seatSize / 2), seatSize, seatSize) };
        var back = new RectangleElement { Color = Colors.SaddleBrown, FillColor = Colors.SaddleBrown, Rect = new RectF(at.X - (seatSize / 2) - 1, at.Y - (seatSize / 2) - backHeight, seatSize + 2, backHeight) };

        return new GroupElement { Children = [seat, back] };
    }
}
