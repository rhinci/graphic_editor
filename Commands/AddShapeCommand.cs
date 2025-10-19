using graphic_editor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace graphic_editor.Commands
{
    public class AddShapeCommand : Command
    {
        private readonly CanvasModel _model;
        private readonly Shape _shape;

        public string Description => $"Добавление {GetShapeTypeName(_shape)}";

        public AddShapeCommand(CanvasModel model, Shape shape)
        {
            _model = model;
            _shape = shape;
        }

        public void Execute()
        {
            _model.AddShape(_shape);
        }

        public void Undo()
        {
            _model.RemoveSelectedShape();
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
