using graphic_editor.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace graphic_editor
{
    public partial class Form1 : Form
    {
        private CanvasModel _model = new CanvasModel();
        private bool _isDrawing = false;
        private PointF _drawStartPoint;
        private string _currentTool = "select";
        private Shape? _currentDrawingShape;

        public Form1()
        {
            InitializeComponent();

            canvasControl1.Model = _model;

            toolPanel1.ToolSelected += ToolPanel_ToolSelected;
            toolPanel1.DeleteRequested += ToolPanel_DeleteRequested;
            toolPanel1.ClearRequested += ToolPanel_ClearRequested;

            canvasControl1.MouseDown += canvasControl1_MouseDown;
            canvasControl1.MouseMove += canvasControl1_MouseMove;
            canvasControl1.MouseUp += canvasControl1_MouseUp;
        }

        private void ToolPanel_ToolSelected(object sender, string tool)
        {
            _currentTool = tool;
            canvasControl1.Cursor = tool == "select" ? Cursors.Default : Cursors.Cross;
        }

        private void ToolPanel_DeleteRequested(object sender, EventArgs e)
        {
            _model.RemoveSelectedShape();
            canvasControl1.RefreshCanvas();
        }

        private void ToolPanel_ClearRequested(object sender, EventArgs e)
        {
            _model.Clear();
            canvasControl1.RefreshCanvas();
        }

        private void canvasControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (_currentTool == "select") return;

            canvasControl1.IsCreatingShape = true;

            _isDrawing = true;
            _drawStartPoint = new PointF(e.X, e.Y);

            _currentDrawingShape = CreateShapeByTool();
            _currentDrawingShape.Position = _drawStartPoint;

            _currentDrawingShape.FillColor = _model.CurrentFillColor;
            _currentDrawingShape.StrokeColor = _model.CurrentStrokeColor;
            _currentDrawingShape.StrokeThickness = _model.CurrentStrokeThickness;
            _currentDrawingShape.FillOpacity = _model.CurrentFillOpacity;

            canvasControl1.CurrentDrawingShape = _currentDrawingShape;
            canvasControl1.RefreshCanvas();
        }

        private void canvasControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDrawing && _currentDrawingShape != null)
            {
                PointF currentPoint = new PointF(e.X, e.Y);
                UpdateShapeSize(_currentDrawingShape, _drawStartPoint, currentPoint);
                canvasControl1.RefreshCanvas();
            }
        }

        private void canvasControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isDrawing && _currentDrawingShape != null)
            {
                _model.AddShape(_currentDrawingShape);
                canvasControl1.CurrentDrawingShape = null;
            }

            _isDrawing = false;
            _currentDrawingShape = null;
            canvasControl1.IsCreatingShape = false;
            canvasControl1.RefreshCanvas();
        }

        private Shape CreateShapeByTool()
        {
            return _currentTool switch
            {
                "rectangle" => new RectangleShape(),
                "ellipse" => new EllipseShape(),
                "line" => new LineShape(),
                _ => throw new InvalidOperationException("Неизвестный инструмент")
            };
        }

        private void UpdateShapeSize(Shape shape, PointF start, PointF end)
        {
            switch (shape)
            {
                case RectangleShape rect:
                    float rectX = Math.Min(start.X, end.X);
                    float rectY = Math.Min(start.Y, end.Y);
                    float rectWidth = Math.Abs(end.X - start.X);
                    float rectHeight = Math.Abs(end.Y - start.Y);

                    rect.Position = new PointF(rectX, rectY);
                    rect.Size = new SizeF(rectWidth, rectHeight);
                    break;

                case EllipseShape ellipse:
                    float ellipseX = Math.Min(start.X, end.X);
                    float ellipseY = Math.Min(start.Y, end.Y);
                    float ellipseWidth = Math.Abs(end.X - start.X);
                    float ellipseHeight = Math.Abs(end.Y - start.Y);

                    ellipse.Position = new PointF(ellipseX, ellipseY);
                    ellipse.Size = new SizeF(ellipseWidth, ellipseHeight);
                    break;

                case LineShape line:
                    line.Position = start;
                    line.EndPoint = end;
                    break;
            }
        }
    }
}