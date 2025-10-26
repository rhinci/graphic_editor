using graphic_editor.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace graphic_editor.Commands
{
    public class RemoveShapeCommand : Command
    {
        private readonly CanvasModel _model;
        private readonly Shape _shape;
        private readonly int _index;

        public string Description => $"Удаление {GetShapeTypeName(_shape)}";

        public RemoveShapeCommand(CanvasModel model, Shape shape)
        {
            _model = model;
            _shape = shape;

            var shapesList = model.Shapes.ToList();
            _index = shapesList.IndexOf(shape);
        }

        public void Execute()
        {
            _model.RemoveSelectedShape();
        }

        public void Undo()
        {
            _model.InsertShape(_shape, _index);
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
}