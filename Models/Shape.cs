using System.Drawing;
using System.Drawing.Drawing2D;

namespace graphic_editor.Models
{
    public abstract class Shape
    {
        public PointF Position { get; set; }
        public float Rotation { get; set; }
        public float Scale { get; set; } = 1.0f;
        public Color FillColor { get; set; } = Color.LightBlue;
        public float FillOpacity { get; set; } = 0.5f;
        public Color StrokeColor { get; set; } = Color.Black;
        public float StrokeThickness { get; set; } = 2.0f;
        public bool IsSelected { get; set; } = false;


        public abstract void Draw(Graphics g);
        public abstract bool ContainsPoint(PointF p);
    }
}