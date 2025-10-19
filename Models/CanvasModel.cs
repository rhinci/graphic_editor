using graphic_editor.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;

namespace graphic_editor.Models
{
    public class CanvasModel
    {
        private List<Shape> _shapes = new List<Shape>();
        public IReadOnlyList<Shape> Shapes => _shapes;

        public Color CurrentFillColor { get; set; } = Color.LightBlue;
        public Color CurrentStrokeColor { get; set; } = Color.Black;
        public float CurrentStrokeThickness { get; set; } = 2.0f;
        public float CurrentFillOpacity { get; set; } = 0.5f;


        private Shape? _selectedShape;

        public Shape? SelectedShape
        {
            get { return _selectedShape; }
            private set
            {
                if (_selectedShape != null)
                    _selectedShape.IsSelected = false;

                if (value != null)
                    value.IsSelected = true;

                _selectedShape = value;
                SelectedShapeChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler? SelectedShapeChanged;



        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
            SelectedShape = shape;
        }

        public void RemoveSelectedShape()
        {
            if (SelectedShape != null)
            {
                _shapes.Remove(SelectedShape);
                SelectedShape = null;
            }
        }

        public void SelectShapeAtPoint(PointF point)
        {
            var shape = _shapes
                .LastOrDefault(s => s.ContainsPoint(point));

            SelectedShape = shape;
        }

        public void Clear()
        {
            _shapes.Clear();
            SelectedShape = null;
        }

        public void UpdateShape(Shape shape)
        {
            SelectedShapeChanged?.Invoke(this, EventArgs.Empty);
        }

        public void InsertShape(Shape shape, int index)
        {
            var shapesList = _shapes.ToList();
            shapesList.Insert(index, shape);
            _shapes = shapesList;
            SelectedShape = shape;
        }
    }
}