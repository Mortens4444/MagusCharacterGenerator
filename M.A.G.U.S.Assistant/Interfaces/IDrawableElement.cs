using M.A.G.U.S.Assistant.Models.Drawing;
using System.Text.Json.Serialization;

namespace M.A.G.U.S.Assistant.Interfaces;

[JsonDerivedType(typeof(LineElement), typeDiscriminator: "line")]
[JsonDerivedType(typeof(RectangleElement), typeDiscriminator: "rect")]
[JsonDerivedType(typeof(CircleElement), typeDiscriminator: "circle")]
[JsonDerivedType(typeof(TextElement), typeDiscriminator: "text")]
internal interface IDrawableElement
{
    Color Color { get; set; }

    void Draw(ICanvas canvas);

    bool Contains(PointF point);

    void Move(float dx, float dy);

    float Rotation { get; set; }

    void Rotate(float angleDegrees);

    PointF GetCenter();

    void Resize(float scale);
}
