using graphic_editor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphic_editor.Views
{
    public partial class CanvasControl : UserControl
    {
        private CanvasModel? _model;


        private bool _isDragging = false;
        private PointF _lastMousePosition;
        private Shape? _draggedShape;
        public Shape? CurrentDrawingShape { get; set; }


        public CanvasModel? Model
        {
            get { return _model; }
            set
            {
                _model = value;
                this.Invalidate();
            }
        }


        public CanvasControl()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.BackColor = Color.White;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_model == null) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Рисуем все фигуры из модели
            foreach (var shape in _model.Shapes)
            {
                shape.Draw(g);
            }

            // --- НОВОЕ: Рисуем фигуру, которую сейчас создаём ---
            if (CurrentDrawingShape != null)
            {
                CurrentDrawingShape.Draw(g);
            }
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (_model == null) return;

            PointF clickPoint = new PointF(e.X, e.Y);
            _model.SelectShapeAtPoint(clickPoint);

            if (_model.SelectedShape != null)
            {
                _isDragging = true;
                _draggedShape = _model.SelectedShape;
                _lastMousePosition = clickPoint;
                this.Cursor = Cursors.Hand;
            }

            this.Invalidate();
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (!_isDragging || _draggedShape == null || _model == null) return;

            PointF currentMousePos = new PointF(e.X, e.Y);
            float deltaX = currentMousePos.X - _lastMousePosition.X;
            float deltaY = currentMousePos.Y - _lastMousePosition.Y;

            if (_draggedShape is LineShape line)
            {
                line.Position = new PointF(
                    line.Position.X + deltaX,
                    line.Position.Y + deltaY
                );
                line.EndPoint = new PointF(
                    line.EndPoint.X + deltaX,
                    line.EndPoint.Y + deltaY
                );
            }
            else
            {
                _draggedShape.Position = new PointF(
                    _draggedShape.Position.X + deltaX,
                    _draggedShape.Position.Y + deltaY
                );
            }

            _lastMousePosition = currentMousePos;
            this.Invalidate();
        }


        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (_isDragging)
            {
                _isDragging = false;
                _draggedShape = null;

                this.Cursor = Cursors.Default;

                this.Invalidate();
            }
        }


        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (_isDragging)
            {
                _isDragging = false;
                _draggedShape = null;
                this.Cursor = Cursors.Default;
                this.Invalidate();
            }
        }


        public void RefreshCanvas()
        {
            this.Invalidate();
        }
    }
}
