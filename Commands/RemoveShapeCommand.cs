using graphic_editor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _index = model.Shapes.ToList().IndexOf(shape);
        }

        public void Execute()
        {
            _model.RemoveSelectedShape();
        }

        public void Undo()
        {
            var shapesList = _model.Shapes.ToList();
            shapesList.Insert(_index, _shape);

            _model.Clear();
            foreach (var shape in shapesList)
            {
                _model.AddShape(shape);
            }
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
}
