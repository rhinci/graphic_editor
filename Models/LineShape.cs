using graphic_editor.Models;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace graphic_editor.Models
{
    public class LineShape : Shape
    {
        public PointF EndPoint { get; set; }

        public override void Draw(Graphics g)
        {
            var originalState = g.Save();

            float centerX = (Position.X + EndPoint.X) / 2;
            float centerY = (Position.Y + EndPoint.Y) / 2;

            g.TranslateTransform(centerX, centerY);
            g.RotateTransform(Rotation);
            g.TranslateTransform(-centerX, -centerY);

            var strokePen = new Pen(StrokeColor, StrokeThickness)
            {
                DashStyle = IsSelected ? DashStyle.Dash : DashStyle.Solid
            };

            using (strokePen)
            {
                g.DrawLine(strokePen, Position, EndPoint);
            }

            g.Restore(originalState);
        }

        public override bool ContainsPoint(PointF p)
        {
            float tolerance = Math.Max(StrokeThickness, 10f);
            return DistanceToPoint(p, Position, EndPoint) <= tolerance;
        }

        private float DistanceToPoint(PointF p, PointF lineStart, PointF lineEnd)
        {
            float lineLengthSquared = (lineEnd.X - lineStart.X) * (lineEnd.X - lineStart.X) +
                                     (lineEnd.Y - lineStart.Y) * (lineEnd.Y - lineStart.Y);

            if (lineLengthSquared == 0)
                return (float)Math.Sqrt((p.X - lineStart.X) * (p.X - lineStart.X) +
                                       (p.Y - lineStart.Y) * (p.Y - lineStart.Y));

            float t = Math.Max(0, Math.Min(1, ((p.X - lineStart.X) * (lineEnd.X - lineStart.X) +
                                              (p.Y - lineStart.Y) * (lineEnd.Y - lineStart.Y)) / lineLengthSquared));

            PointF projection = new PointF(
                lineStart.X + t * (lineEnd.X - lineStart.X),
                lineStart.Y + t * (lineEnd.Y - lineStart.Y));

            return (float)Math.Sqrt((p.X - projection.X) * (p.X - projection.X) +
                                   (p.Y - projection.Y) * (p.Y - projection.Y));
        }
    }
}