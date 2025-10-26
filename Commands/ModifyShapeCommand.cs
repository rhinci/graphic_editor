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
    public class ModifyShapeCommand : Command
    {
        private readonly CanvasModel _model;
        private readonly Shape _shape;
        private readonly ShapeMemento _oldState;
        private readonly ShapeMemento _newState;

        public string Description => $"Изменение {GetShapeTypeName(_shape)}";

        public ModifyShapeCommand(CanvasModel model, Shape shape, ShapeMemento newState)
        {
            _model = model;
            _shape = shape;
            _oldState = new ShapeMemento(shape);
            _newState = newState;
        }

        public void Execute()
        {
            _newState.ApplyTo(_shape);
            _model.SelectShapeAtPoint(_shape.Position);
        }

        public void Undo()
        {
            _oldState.ApplyTo(_shape);
            _model.SelectShapeAtPoint(_shape.Position);
        }

        private string GetShapeTypeName(Shape shape)
        {
            return shape switch
            {
                RectangleShape => "прямоугольника",
                EllipseShape => "эллипса",
                LineShape => "линии",
                _ => "фигуры"
            };
        }
    }

    public class ShapeMemento
    {
        public PointF Position { get; }
        public float Rotation { get; }
        public SizeF Size { get; }
        public PointF EndPoint { get; }
        public Color FillColor { get; }
        public float FillOpacity { get; }
        public Color StrokeColor { get; }
        public float StrokeThickness { get; }
        public Type ShapeType { get; }

        public ShapeMemento(Shape shape)
        {
            Position = shape.Position;
            Rotation = shape.Rotation;
            FillColor = shape.FillColor;
            FillOpacity = shape.FillOpacity;
            StrokeColor = shape.StrokeColor;
            StrokeThickness = shape.StrokeThickness;
            ShapeType = shape.GetType();

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
            if (shape.GetType() != ShapeType)
                return;

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