using graphic_editor.Models;
using System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace graphic_editor.Commands
{
    public class ModifyShapePropertiesCommand : Command
    {
        private readonly CanvasModel _model;
        private readonly Shape _shape;
        private readonly ShapeProperties _oldProperties;
        private readonly ShapeProperties _newProperties;

        public string Description => "Изменение свойств фигуры";

        public ModifyShapePropertiesCommand(CanvasModel model, Shape shape, ShapeProperties newProperties)
        {
            _model = model;
            _shape = shape;
            _oldProperties = new ShapeProperties(shape);
            _newProperties = newProperties;
        }

        public void Execute()
        {
            _newProperties.ApplyTo(_shape);
            _model.UpdateShape(_shape);
        }

        public void Undo()
        {
            _oldProperties.ApplyTo(_shape);
            _model.UpdateShape(_shape);
        }
    }

    public class ShapeProperties
    {
        public PointF Position { get; set; }
        public float Rotation { get; set; }
        public SizeF Size { get; set; }
        public PointF EndPoint { get; set; }
        public Color FillColor { get; set; }
        public float FillOpacity { get; set; }
        public Color StrokeColor { get; set; }
        public float StrokeThickness { get; set; }

        public ShapeProperties() { }

        public ShapeProperties(Shape shape)
        {
            Position = shape.Position;
            Rotation = shape.Rotation;
            FillColor = shape.FillColor;
            FillOpacity = shape.FillOpacity;
            StrokeColor = shape.StrokeColor;
            StrokeThickness = shape.StrokeThickness;

            if (shape is RectangleShape rect)
            {
                Size = rect.Size;
            }
            else if (shape is EllipseShape ellipse)
            {
                Size = ellipse.Size;
            }
            else if (shape is LineShape line)
            {
                EndPoint = line.EndPoint;
            }
        }

        public void ApplyTo(Shape shape)
        {
            shape.Position = Position;
            shape.Rotation = Rotation;
            shape.FillColor = FillColor;
            shape.FillOpacity = FillOpacity;
            shape.StrokeColor = StrokeColor;
            shape.StrokeThickness = StrokeThickness;

            if (shape is RectangleShape rect && Size != SizeF.Empty)
            {
                rect.Size = Size;
            }
            else if (shape is EllipseShape ellipse && Size != SizeF.Empty)
            {
                ellipse.Size = Size;
            }
            else if (shape is LineShape line && EndPoint != PointF.Empty)
            {
                line.EndPoint = EndPoint;
            }
        }
    }
}