using graphic_editor.Models;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace graphic_editor.Models
{
    public class EllipseShape : Shape
    {
        public SizeF Size { get; set; } = new SizeF(100, 100);

        public override void Draw(Graphics g)
        {
            var originalState = g.Save();

            g.TranslateTransform(Position.X, Position.Y);
            g.RotateTransform(Rotation);
            g.TranslateTransform(-Position.X, -Position.Y);

            using (var fillBrush = new SolidBrush(Color.FromArgb((int)(FillOpacity * 255), FillColor)))
            {
                g.FillEllipse(fillBrush, Position.X, Position.Y, Size.Width, Size.Height);
            }

            var strokePen = new Pen(StrokeColor, StrokeThickness)
            {
                DashStyle = IsSelected ? DashStyle.Dash : DashStyle.Solid
            };

            using (strokePen)
            {
                g.DrawEllipse(strokePen, Position.X, Position.Y, Size.Width, Size.Height);
            }

            g.Restore(originalState);
        }

        public override bool ContainsPoint(PointF p)
        {
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(new RectangleF(Position, Size));
                return path.IsVisible(p);
            }
        }
    }
}