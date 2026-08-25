using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using MAGUS.Assistant.Interfaces;
using MAGUS.Assistant.Models.Drawing;

namespace MAGUS.Assistant.Services;

/// <summary>
/// Converts between the paint wizard's IDrawableElement tree and SVG - a real open, text-based
/// standard any vector app (Inkscape, Illustrator, a browser, ...) can read or hand-author, unlike
/// the app's internal Newtonsoft/TypeNameHandling save format used by DrawingRepository.
/// </summary>
internal static class SvgDrawingService
{
    private static readonly XNamespace Ns = "http://www.w3.org/2000/svg";

    public static string ToSvg(IEnumerable<IDrawableElement> elements, float width = 2000, float height = 2000)
    {
        var svg = new XElement(Ns + "svg",
            new XAttribute("width", F(width)),
            new XAttribute("height", F(height)),
            new XAttribute("viewBox", $"0 0 {F(width)} {F(height)}"));

        foreach (var element in elements)
        {
            var node = ToXElement(element);
            if (node != null)
            {
                svg.Add(node);
            }
        }

        return new XDocument(svg).ToString();
    }

    public static List<IDrawableElement> FromSvg(string svgContent)
    {
        var root = XDocument.Parse(svgContent).Root ?? throw new InvalidOperationException("Empty SVG document.");

        var elements = new List<IDrawableElement>();
        ParseChildren(root, Matrix.Identity, SvgStyle.None, elements);
        return elements;
    }

    private static XElement? ToXElement(IDrawableElement element) => element switch
    {
        GroupElement group => ToXElement(group),
        RectangleElement rect => ToXElement(rect),
        CircleElement circle => ToXElement(circle),
        LineElement line => ToXElement(line),
        TextElement text => ToXElement(text),
        _ => null
    };

    private static XElement ToXElement(GroupElement group)
    {
        var g = new XElement(Ns + "g");
        ApplyRotation(g, group.Rotation, group.GetCenter());

        foreach (var child in group.Children)
        {
            var node = ToXElement(child);
            if (node != null)
            {
                g.Add(node);
            }
        }

        return g;
    }

    private static XElement ToXElement(RectangleElement rect)
    {
        var el = new XElement(Ns + "rect",
            new XAttribute("x", F(rect.Rect.X)),
            new XAttribute("y", F(rect.Rect.Y)),
            new XAttribute("width", F(rect.Rect.Width)),
            new XAttribute("height", F(rect.Rect.Height)),
            new XAttribute("stroke", Hex(rect.Color)),
            new XAttribute("stroke-width", "2"),
            new XAttribute("fill", rect.FillColor == Colors.Transparent ? "none" : Hex(rect.FillColor)));
        ApplyRotation(el, rect.Rotation, rect.GetCenter());
        return el;
    }

    private static XElement ToXElement(CircleElement circle)
    {
        XElement el = circle.IsBoundedByRect
            ? new XElement(Ns + "ellipse",
                new XAttribute("cx", F(circle.BoundingRect.X + (circle.BoundingRect.Width / 2f))),
                new XAttribute("cy", F(circle.BoundingRect.Y + (circle.BoundingRect.Height / 2f))),
                new XAttribute("rx", F(circle.BoundingRect.Width / 2f)),
                new XAttribute("ry", F(circle.BoundingRect.Height / 2f)),
                new XAttribute("stroke", Hex(circle.Color)),
                new XAttribute("stroke-width", F(circle.Thickness)),
                new XAttribute("fill", circle.FillColor == Colors.Transparent ? "none" : Hex(circle.FillColor)))
            : new XElement(Ns + "circle",
                new XAttribute("cx", F(circle.Center.X)),
                new XAttribute("cy", F(circle.Center.Y)),
                new XAttribute("r", F(circle.Radius)),
                new XAttribute("stroke", Hex(circle.Color)),
                new XAttribute("stroke-width", F(circle.Thickness)),
                new XAttribute("fill", circle.FillColor == Colors.Transparent ? "none" : Hex(circle.FillColor)));

        ApplyRotation(el, circle.Rotation, circle.GetCenter());
        return el;
    }

    private static XElement ToXElement(LineElement line)
    {
        var points = String.Join(" ", line.Points.Select(p => $"{F(p.X)},{F(p.Y)}"));
        var el = new XElement(Ns + "polyline",
            new XAttribute("points", points),
            new XAttribute("stroke", Hex(line.Color)),
            new XAttribute("stroke-width", F(line.Thickness)),
            new XAttribute("stroke-linecap", "round"),
            new XAttribute("stroke-linejoin", "round"),
            new XAttribute("fill", "none"));
        ApplyRotation(el, line.Rotation, line.GetCenter());
        return el;
    }

    private static XElement ToXElement(TextElement text)
    {
        var el = new XElement(Ns + "text",
            new XAttribute("x", F(text.Position.X)),
            new XAttribute("y", F(text.Position.Y)),
            new XAttribute("font-size", F(text.FontSize)),
            new XAttribute("fill", Hex(text.Color)),
            text.Text);
        ApplyRotation(el, text.Rotation, text.GetCenter());
        return el;
    }

    private static void ApplyRotation(XElement el, float rotation, PointF center)
    {
        if (rotation != 0)
        {
            el.SetAttributeValue("transform", $"rotate({F(rotation)} {F(center.X)} {F(center.Y)})");
        }
    }

    private static string F(float value) => value.ToString("0.###", CultureInfo.InvariantCulture);

    private static string Hex(Color color) =>
        $"#{(byte)Math.Round(color.Red * 255):X2}{(byte)Math.Round(color.Green * 255):X2}{(byte)Math.Round(color.Blue * 255):X2}";

    /// <summary>
    /// 2D affine transform (SVG's matrix(a,b,c,d,e,f)). Accumulated while walking down nested &lt;g&gt;
    /// elements so real-world files (e.g. CAD/floor-plan exports, which position everything via
    /// matrix() instead of our own simple rotate()) resolve to correct absolute coordinates.
    /// </summary>
    private readonly record struct Matrix(float A, float B, float C, float D, float E, float F)
    {
        public static readonly Matrix Identity = new(1, 0, 0, 1, 0, 0);

        public bool IsIdentity => this == Identity;

        public PointF Apply(PointF p) => new((A * p.X) + (C * p.Y) + E, (B * p.X) + (D * p.Y) + F);

        /// <summary>this ∘ other - "other" is applied first (child's local space), then "this" (the accumulated ancestor space).</summary>
        public Matrix Compose(Matrix o) => new(
            (A * o.A) + (C * o.B), (B * o.A) + (D * o.B),
            (A * o.C) + (C * o.D), (B * o.C) + (D * o.D),
            (A * o.E) + (C * o.F) + E, (B * o.E) + (D * o.F) + F);
    }

    /// <summary>Inherited paint state while walking the SVG tree - null means "not specified here, keep the ancestor's value"; Colors.Transparent means an explicit "none" at this level.</summary>
    private readonly record struct SvgStyle(Color? Stroke, Color? Fill, float? StrokeWidth)
    {
        public static readonly SvgStyle None = new(null, null, null);
    }

    private static void ParseChildren(XElement parent, Matrix matrix, SvgStyle style, List<IDrawableElement> output)
    {
        foreach (var node in parent.Elements())
        {
            ParseNode(node, matrix, style, output);
        }
    }

    private static void ParseNode(XElement node, Matrix matrix, SvgStyle style, List<IDrawableElement> output)
    {
        var childStyle = ApplyStyle(node, style);
        var transform = AttrStr(node, "transform");
        var atIdentity = matrix.IsIdentity;
        var pureRotate = IsPureRotateTransform(transform);
        var localName = node.Name.LocalName;

        if (localName == "g")
        {
            if (atIdentity && pureRotate)
            {
                // Matches exactly what our own ToSvg emits for a stamped/rotated group - keep it as one
                // rotatable GroupElement instead of baking the angle into every child's coordinates.
                var children = new List<IDrawableElement>();
                ParseChildren(node, Matrix.Identity, childStyle, children);
                output.Add(new GroupElement { Children = children, Rotation = ExtractRotateAngle(transform) });
            }
            else
            {
                var nextMatrix = matrix.Compose(ParseTransformMatrix(transform));
                ParseChildren(node, nextMatrix, childStyle, output);
            }
            return;
        }

        if (localName == "path")
        {
            // Paths have no native IDrawableElement equivalent, so their coordinates always get baked
            // through whatever matrix applies (identity included - that's just a no-op passthrough).
            var pathMatrix = matrix.Compose(ParseTransformMatrix(transform));
            AppendPath(node, pathMatrix, childStyle, output);
            return;
        }

        if (atIdentity && pureRotate)
        {
            AppendNativeLeaf(node, localName, childStyle, ExtractRotateAngle(transform), output);
        }
        else
        {
            var leafMatrix = matrix.Compose(ParseTransformMatrix(transform));
            AppendTransformedLeaf(node, localName, leafMatrix, childStyle, output);
        }
    }

    private static void AppendNativeLeaf(XElement node, string localName, SvgStyle style, float rotation, List<IDrawableElement> output)
    {
        IDrawableElement? element = localName switch
        {
            "rect" => new RectangleElement
            {
                Color = ResolveStroke(style),
                FillColor = style.Fill ?? Colors.Transparent,
                Rect = new RectF(AttrF(node, "x"), AttrF(node, "y"), AttrF(node, "width"), AttrF(node, "height")),
                Rotation = rotation
            },
            "circle" => new CircleElement
            {
                Color = ResolveStroke(style),
                FillColor = style.Fill ?? Colors.Transparent,
                Center = new PointF(AttrF(node, "cx"), AttrF(node, "cy")),
                Radius = AttrF(node, "r", 10f),
                Thickness = style.StrokeWidth ?? 2f,
                Rotation = rotation
            },
            "ellipse" => BuildNativeEllipse(node, style, rotation),
            "line" or "polyline" or "polygon" => BuildNativeLine(node, style, rotation),
            "text" => new TextElement
            {
                Text = node.Value,
                Color = style.Fill ?? ResolveStroke(style),
                Position = new PointF(AttrF(node, "x"), AttrF(node, "y")),
                FontSize = AttrF(node, "font-size", 18f),
                Rotation = rotation
            },
            _ => null
        };

        if (element != null)
        {
            output.Add(element);
        }
    }

    private static CircleElement BuildNativeEllipse(XElement node, SvgStyle style, float rotation)
    {
        var cx = AttrF(node, "cx");
        var cy = AttrF(node, "cy");
        var rx = AttrF(node, "rx", 10f);
        var ry = AttrF(node, "ry", 10f);

        return new CircleElement
        {
            Color = ResolveStroke(style),
            FillColor = style.Fill ?? Colors.Transparent,
            Center = new PointF(cx, cy),
            Radius = Math.Max(rx, ry),
            IsBoundedByRect = true,
            BoundingRect = new RectF(cx - rx, cy - ry, rx * 2, ry * 2),
            Thickness = style.StrokeWidth ?? 2f,
            Rotation = rotation
        };
    }

    private static LineElement? BuildNativeLine(XElement node, SvgStyle style, float rotation)
    {
        var points = ReadRawPoints(node);
        if (points.Count < 2)
        {
            return null;
        }

        return new LineElement { Color = ResolveLineColor(style), Thickness = style.StrokeWidth ?? 2f, Points = points, Rotation = rotation };
    }

    private static void AppendTransformedLeaf(XElement node, string localName, Matrix matrix, SvgStyle style, List<IDrawableElement> output)
    {
        var color = ResolveLineColor(style);
        var thickness = style.StrokeWidth ?? 2f;

        List<PointF>? points = localName switch
        {
            "line" or "polyline" or "polygon" => ReadRawPoints(node),
            "rect" => RectCorners(new RectF(AttrF(node, "x"), AttrF(node, "y"), AttrF(node, "width"), AttrF(node, "height"))),
            "circle" => EllipsePoints(AttrF(node, "cx"), AttrF(node, "cy"), AttrF(node, "r", 10f), AttrF(node, "r", 10f)),
            "ellipse" => EllipsePoints(AttrF(node, "cx"), AttrF(node, "cy"), AttrF(node, "rx", 10f), AttrF(node, "ry", 10f)),
            _ => null
        };

        if (points != null)
        {
            if (points.Count >= 2)
            {
                output.Add(new LineElement { Color = color, Thickness = thickness, Points = [.. points.Select(matrix.Apply)] });
            }
            return;
        }

        if (localName == "text")
        {
            output.Add(new TextElement
            {
                Text = node.Value,
                Color = style.Fill ?? color,
                Position = matrix.Apply(new PointF(AttrF(node, "x"), AttrF(node, "y"))),
                FontSize = AttrF(node, "font-size", 18f)
            });
        }
    }

    private static void AppendPath(XElement node, Matrix matrix, SvgStyle style, List<IDrawableElement> output)
    {
        var color = ResolveLineColor(style);
        var thickness = style.StrokeWidth ?? 2f;

        foreach (var subpath in ParsePathData(AttrStr(node, "d") ?? String.Empty))
        {
            if (subpath.Count < 2)
            {
                continue;
            }

            output.Add(new LineElement { Color = color, Thickness = thickness, Points = [.. subpath.Select(matrix.Apply)] });
        }
    }

    private static List<PointF> ReadRawPoints(XElement node)
    {
        if (node.Name.LocalName == "line")
        {
            return [new PointF(AttrF(node, "x1"), AttrF(node, "y1")), new PointF(AttrF(node, "x2"), AttrF(node, "y2"))];
        }

        var numbers = Regex.Matches(AttrStr(node, "points") ?? "", @"-?[\d.]+")
            .Select(m => float.Parse(m.Value, CultureInfo.InvariantCulture))
            .ToList();

        var points = new List<PointF>();
        for (int i = 0; i + 1 < numbers.Count; i += 2)
        {
            points.Add(new PointF(numbers[i], numbers[i + 1]));
        }

        if (node.Name.LocalName == "polygon" && points.Count > 0)
        {
            points.Add(points[0]);
        }

        return points;
    }

    private static List<PointF> RectCorners(RectF r) =>
    [
        new PointF(r.X, r.Y),
        new PointF(r.X + r.Width, r.Y),
        new PointF(r.X + r.Width, r.Y + r.Height),
        new PointF(r.X, r.Y + r.Height),
        new PointF(r.X, r.Y)
    ];

    private static List<PointF> EllipsePoints(float cx, float cy, float rx, float ry, int segments = 24)
    {
        var points = new List<PointF>();
        for (int s = 0; s <= segments; s++)
        {
            var t = s / (float)segments * MathF.PI * 2f;
            points.Add(new PointF(cx + (rx * MathF.Cos(t)), cy + (ry * MathF.Sin(t))));
        }
        return points;
    }

    /// <summary>
    /// Minimal SVG path "d" parser: M/L/H/V/C/Q/Z (upper and lower case) plus S/T (smooth curves,
    /// whose reflected control point is approximated as the current point rather than tracked
    /// precisely) and A (elliptical arc, approximated as a straight line to its endpoint - true
    /// arc math isn't worth it for a schematic paint-over background). Curves are flattened into
    /// line segments since LineElement only draws straight segments. Malformed/truncated data
    /// stops parsing and returns whatever subpaths were completed rather than throwing.
    /// </summary>
    private static List<List<PointF>> ParsePathData(string d)
    {
        var subpaths = new List<List<PointF>>();
        var tokens = Regex.Matches(d, @"[MmLlHhVvCcSsQqTtAaZz]|-?\d*\.\d+(?:[eE][-+]?\d+)?|-?\d+(?:[eE][-+]?\d+)?")
            .Select(m => m.Value)
            .ToList();

        try
        {
            var i = 0;
            float ReadNum() => float.Parse(tokens[i++], CultureInfo.InvariantCulture);

            var current = PointF.Zero;
            var subpathStart = PointF.Zero;
            List<PointF>? currentPoints = null;
            var cmd = '\0';

            void StartSubpath(PointF p)
            {
                if (currentPoints is { Count: > 1 })
                {
                    subpaths.Add(currentPoints);
                }
                currentPoints = [p];
                subpathStart = p;
                current = p;
            }

            void LineTo(PointF p)
            {
                currentPoints ??= [current];
                currentPoints.Add(p);
                current = p;
            }

            while (i < tokens.Count)
            {
                if (tokens[i].Length == 1 && Char.IsLetter(tokens[i][0]))
                {
                    cmd = tokens[i][0];
                    i++;
                }

                switch (cmd)
                {
                    case 'M': StartSubpath(new PointF(ReadNum(), ReadNum())); cmd = 'L'; break;
                    case 'm': StartSubpath(new PointF(current.X + ReadNum(), current.Y + ReadNum())); cmd = 'l'; break;
                    case 'L': LineTo(new PointF(ReadNum(), ReadNum())); break;
                    case 'l': LineTo(new PointF(current.X + ReadNum(), current.Y + ReadNum())); break;
                    case 'H': LineTo(new PointF(ReadNum(), current.Y)); break;
                    case 'h': LineTo(new PointF(current.X + ReadNum(), current.Y)); break;
                    case 'V': LineTo(new PointF(current.X, ReadNum())); break;
                    case 'v': LineTo(new PointF(current.X, current.Y + ReadNum())); break;

                    case 'C':
                    case 'c':
                    {
                        var rel = cmd == 'c';
                        var c1 = rel ? new PointF(current.X + ReadNum(), current.Y + ReadNum()) : new PointF(ReadNum(), ReadNum());
                        var c2 = rel ? new PointF(current.X + ReadNum(), current.Y + ReadNum()) : new PointF(ReadNum(), ReadNum());
                        var end = rel ? new PointF(current.X + ReadNum(), current.Y + ReadNum()) : new PointF(ReadNum(), ReadNum());
                        currentPoints ??= [current];
                        FlattenCubic(current, c1, c2, end, currentPoints);
                        current = end;
                        break;
                    }

                    case 'S':
                    case 's':
                    {
                        var rel = cmd == 's';
                        var c2 = rel ? new PointF(current.X + ReadNum(), current.Y + ReadNum()) : new PointF(ReadNum(), ReadNum());
                        var end = rel ? new PointF(current.X + ReadNum(), current.Y + ReadNum()) : new PointF(ReadNum(), ReadNum());
                        currentPoints ??= [current];
                        FlattenCubic(current, current, c2, end, currentPoints);
                        current = end;
                        break;
                    }

                    case 'Q':
                    case 'q':
                    {
                        var rel = cmd == 'q';
                        var c1 = rel ? new PointF(current.X + ReadNum(), current.Y + ReadNum()) : new PointF(ReadNum(), ReadNum());
                        var end = rel ? new PointF(current.X + ReadNum(), current.Y + ReadNum()) : new PointF(ReadNum(), ReadNum());
                        currentPoints ??= [current];
                        FlattenQuadratic(current, c1, end, currentPoints);
                        current = end;
                        break;
                    }

                    case 'T':
                    case 't':
                    {
                        var rel = cmd == 't';
                        var end = rel ? new PointF(current.X + ReadNum(), current.Y + ReadNum()) : new PointF(ReadNum(), ReadNum());
                        currentPoints ??= [current];
                        FlattenQuadratic(current, current, end, currentPoints);
                        current = end;
                        break;
                    }

                    case 'A':
                    case 'a':
                    {
                        var rel = cmd == 'a';
                        ReadNum(); ReadNum(); ReadNum(); ReadNum(); ReadNum(); // rx ry x-axis-rotation large-arc-flag sweep-flag (unused - see summary)
                        var end = rel ? new PointF(current.X + ReadNum(), current.Y + ReadNum()) : new PointF(ReadNum(), ReadNum());
                        LineTo(end);
                        break;
                    }

                    case 'Z':
                    case 'z':
                        if (currentPoints != null)
                        {
                            currentPoints.Add(subpathStart);
                            subpaths.Add(currentPoints);
                            currentPoints = null;
                        }
                        current = subpathStart;
                        break;

                    default:
                        i++;
                        break;
                }
            }

            if (currentPoints is { Count: > 1 })
            {
                subpaths.Add(currentPoints);
            }
        }
        catch (Exception ex) when (ex is FormatException or ArgumentOutOfRangeException)
        {
            // Truncated/malformed "d" data - keep whatever subpaths were already completed.
        }

        return subpaths;
    }

    private static void FlattenCubic(PointF p0, PointF p1, PointF p2, PointF p3, List<PointF> output, int segments = 12)
    {
        for (var s = 1; s <= segments; s++)
        {
            var t = s / (float)segments;
            var mt = 1 - t;
            var x = (mt * mt * mt * p0.X) + (3 * mt * mt * t * p1.X) + (3 * mt * t * t * p2.X) + (t * t * t * p3.X);
            var y = (mt * mt * mt * p0.Y) + (3 * mt * mt * t * p1.Y) + (3 * mt * t * t * p2.Y) + (t * t * t * p3.Y);
            output.Add(new PointF(x, y));
        }
    }

    private static void FlattenQuadratic(PointF p0, PointF p1, PointF p2, List<PointF> output, int segments = 10)
    {
        for (var s = 1; s <= segments; s++)
        {
            var t = s / (float)segments;
            var mt = 1 - t;
            var x = (mt * mt * p0.X) + (2 * mt * t * p1.X) + (t * t * p2.X);
            var y = (mt * mt * p0.Y) + (2 * mt * t * p1.Y) + (t * t * p2.Y);
            output.Add(new PointF(x, y));
        }
    }

    /// <summary>True for an empty/absent transform too, since both mean "stay in native, unbaked mode".</summary>
    private static bool IsPureRotateTransform(string? transform) =>
        String.IsNullOrWhiteSpace(transform) || Regex.IsMatch(transform.Trim(), @"^rotate\([^()]*\)$");

    private static float ExtractRotateAngle(string? transform)
    {
        if (String.IsNullOrWhiteSpace(transform))
        {
            return 0f;
        }

        var match = Regex.Match(transform, @"rotate\(\s*(-?[\d.]+)");
        return match.Success && float.TryParse(match.Groups[1].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out var angle) ? angle : 0f;
    }

    /// <summary>Composes every matrix()/translate()/scale()/rotate() function found in a transform attribute, in document order (identity if none/unparseable).</summary>
    private static Matrix ParseTransformMatrix(string? transform)
    {
        if (String.IsNullOrWhiteSpace(transform))
        {
            return Matrix.Identity;
        }

        var result = Matrix.Identity;
        foreach (Match m in Regex.Matches(transform, @"(matrix|rotate|translate|scale)\s*\(([^)]*)\)"))
        {
            var args = Regex.Matches(m.Groups[2].Value, @"-?\d*\.?\d+(?:[eE][-+]?\d+)?")
                .Select(a => float.Parse(a.Value, CultureInfo.InvariantCulture))
                .ToArray();

            var token = m.Groups[1].Value switch
            {
                "matrix" when args.Length >= 6 => new Matrix(args[0], args[1], args[2], args[3], args[4], args[5]),
                "rotate" when args.Length >= 1 => RotationMatrix(args[0], args.Length >= 3 ? args[1] : 0, args.Length >= 3 ? args[2] : 0),
                "translate" when args.Length >= 1 => new Matrix(1, 0, 0, 1, args[0], args.Length >= 2 ? args[1] : 0),
                "scale" when args.Length >= 1 => new Matrix(args[0], 0, 0, args.Length >= 2 ? args[1] : args[0], 0, 0),
                _ => Matrix.Identity
            };

            result = result.Compose(token);
        }

        return result;
    }

    private static Matrix RotationMatrix(float degrees, float cx, float cy)
    {
        var radians = degrees * MathF.PI / 180f;
        var cos = MathF.Cos(radians);
        var sin = MathF.Sin(radians);
        var rotate = new Matrix(cos, sin, -sin, cos, 0, 0);

        if (cx == 0 && cy == 0)
        {
            return rotate;
        }

        return new Matrix(1, 0, 0, 1, cx, cy).Compose(rotate).Compose(new Matrix(1, 0, 0, 1, -cx, -cy));
    }

    /// <summary>Merges this node's own "style"/presentation attributes over the inherited ones - "style" wins over plain attributes, matching real-world exporters (e.g. Sweet Home 3D) that only ever set colors via "style".</summary>
    private static SvgStyle ApplyStyle(XElement node, SvgStyle inherited)
    {
        string? styleFill = null, styleStroke = null, styleStrokeWidth = null;
        var styleAttr = AttrStr(node, "style");
        if (!String.IsNullOrWhiteSpace(styleAttr))
        {
            foreach (var decl in styleAttr.Split(';', StringSplitOptions.RemoveEmptyEntries))
            {
                var parts = decl.Split(':', 2);
                if (parts.Length != 2)
                {
                    continue;
                }

                switch (parts[0].Trim().ToLowerInvariant())
                {
                    case "fill": styleFill = parts[1].Trim(); break;
                    case "stroke": styleStroke = parts[1].Trim(); break;
                    case "stroke-width": styleStrokeWidth = parts[1].Trim(); break;
                }
            }
        }

        var fillRaw = styleFill ?? AttrStr(node, "fill");
        var strokeRaw = styleStroke ?? AttrStr(node, "stroke");
        var strokeWidthRaw = styleStrokeWidth ?? AttrStr(node, "stroke-width");

        var fill = fillRaw switch
        {
            null => inherited.Fill,
            var v when v.Equals("none", StringComparison.OrdinalIgnoreCase) => Colors.Transparent,
            var v => ParseColorValue(v)
        };

        var stroke = strokeRaw switch
        {
            null => inherited.Stroke,
            var v when v.Equals("none", StringComparison.OrdinalIgnoreCase) => Colors.Transparent,
            var v => ParseColorValue(v)
        };

        var strokeWidth = strokeWidthRaw != null && float.TryParse(strokeWidthRaw, NumberStyles.Float, CultureInfo.InvariantCulture, out var sw)
            ? sw
            : inherited.StrokeWidth;

        return new SvgStyle(stroke, fill, strokeWidth);
    }

    /// <summary>Prefers a real stroke color; falls back to fill so fill-only shapes (icons, filled shapes with no separate outline pass) still render as a visible outline, since LineElement can't fill.</summary>
    private static Color ResolveLineColor(SvgStyle style) => Visible(style.Stroke) ?? Visible(style.Fill) ?? Colors.Black;

    private static Color ResolveStroke(SvgStyle style) => style.Stroke ?? Colors.Black;

    private static Color? Visible(Color? color) => color is { } c && c.Alpha > 0 ? c : null;

    /// <summary>Accepts "#rrggbb"/"#rgb" hex or any CSS/SVG name matching a Microsoft.Maui.Graphics.Colors property (e.g. "forestgreen"), since both are common in hand-authored SVG files.</summary>
    private static Color ParseColorValue(string value)
    {
        if (value.StartsWith('#'))
        {
            try
            {
                return Color.FromArgb(value);
            }
            catch (Exception ex) when (ex is FormatException or ArgumentException)
            {
                return Colors.Black;
            }
        }

        var property = typeof(Colors).GetProperty(value, BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase);
        return property?.GetValue(null) as Color ?? Colors.Black;
    }

    private static string? AttrStr(XElement node, string name) => node.Attribute(name)?.Value;

    private static float AttrF(XElement node, string name, float defaultValue = 0f) =>
        float.TryParse(AttrStr(node, name), NumberStyles.Float, CultureInfo.InvariantCulture, out var value) ? value : defaultValue;
}
