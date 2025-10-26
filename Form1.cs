using graphic_editor.Commands;
using graphic_editor.Models;
using graphic_editor.Services;
using graphic_editor.Views;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace graphic_editor
{
    public partial class Form1 : Form
    {
        private CanvasModel _model = new CanvasModel();
        private CommandManager _commandManager = new CommandManager();
        private SerializationService _serializationService = new SerializationService();
        private bool _isDrawing = false;
        private PointF _drawStartPoint;
        private string _currentTool = "select";
        private Shape? _currentDrawingShape;

        public Form1()
        {
            InitializeComponent();
            inspectorPanel1.SetCommandManager(_commandManager);

            canvasControl1.Model = _model;

            _commandManager.HistoryChanged += CommandManager_HistoryChanged;

            toolPanel1.ToolSelected += ToolPanel_ToolSelected;
            toolPanel1.DeleteRequested += ToolPanel_DeleteRequested;
            toolPanel1.ClearRequested += ToolPanel_ClearRequested;
            toolPanel1.FillColorChanged += ToolPanel_FillColorChanged;
            toolPanel1.StrokeColorChanged += ToolPanel_StrokeColorChanged;
            toolPanel1.StrokeThicknessChanged += ToolPanel_StrokeThicknessChanged;
            toolPanel1.FillOpacityChanged += ToolPanel_FillOpacityChanged;

            toolPanel1.UndoRequested += ToolPanel_UndoRequested;
            toolPanel1.RedoRequested += ToolPanel_RedoRequested;
            _commandManager.HistoryChanged += CommandManager_HistoryChanged;

            _model.SelectedShapeChanged += Model_SelectedShapeChanged;
            inspectorPanel1.ShapeUpdated += InspectorPanel_ShapeUpdated;

            canvasControl1.MouseDown += canvasControl1_MouseDown;
            canvasControl1.MouseMove += canvasControl1_MouseMove;
            canvasControl1.MouseUp += canvasControl1_MouseUp;

            menuNew.Click += MenuNew_Click;
            menuOpen.Click += MenuOpen_Click;
            menuSave.Click += MenuSave_Click;
        }

        //панель инструментов
        private void ToolPanel_FillColorChanged(object sender, Color color)
        {
            _model.CurrentFillColor = color;
        }

        private void ToolPanel_StrokeColorChanged(object sender, Color color)
        {
            _model.CurrentStrokeColor = color;
        }

        private void ToolPanel_StrokeThicknessChanged(object sender, float thickness)
        {
            _model.CurrentStrokeThickness = thickness;
        }

        private void ToolPanel_FillOpacityChanged(object sender, float opacity)
        {
            _model.CurrentFillOpacity = opacity;
        }

        private void ToolPanel_ToolSelected(object sender, string tool)
        {
            _currentTool = tool;
            canvasControl1.Cursor = tool == "select" ? Cursors.Default : Cursors.Cross;
        }

        private void ToolPanel_DeleteRequested(object sender, EventArgs e)
        {
            if (_model.SelectedShape != null)
            {
                var command = new RemoveShapeCommand(_model, _model.SelectedShape);
                _commandManager.ExecuteCommand(command);
                canvasControl1.RefreshCanvas();
            }
        }

        private void ToolPanel_ClearRequested(object sender, EventArgs e)
        {
            _model.Clear();
            canvasControl1.RefreshCanvas();
        }




        //инспектор
        private void Model_SelectedShapeChanged(object sender, EventArgs e)
        {
            inspectorPanel1.BindShape(_model.SelectedShape);
            canvasControl1.RefreshCanvas();
        }

        private void InspectorPanel_ShapeUpdated(object sender, EventArgs e)
        {
            canvasControl1.RefreshCanvas();
        }







        // отмена/повтор действия
        private void ToolPanel_UndoRequested(object sender, EventArgs e)
        {
            Undo();
        }

        private void ToolPanel_RedoRequested(object sender, EventArgs e)
        {
            Redo();
        }
        private void CommandManager_HistoryChanged(object sender, EventArgs e)
        {
            UpdateUndoRedoButtons();
        }

        private void UpdateUndoRedoButtons()
        {
            toolPanel1.SetUndoRedoState(_commandManager.CanUndo, _commandManager.CanRedo);
        }

        public void Undo()
        {
            _commandManager.Undo();
            canvasControl1.RefreshCanvas();
        }

        public void Redo()
        {
            _commandManager.Redo();
            canvasControl1.RefreshCanvas();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Z))
            {
                Undo();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.Y))
            {
                Redo();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public CanvasModel GetCanvasModel()
        {
            return _model;
        }




        //работа на холсте
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
                var command = new AddShapeCommand(_model, _currentDrawingShape);
                _commandManager.ExecuteCommand(command);

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




        // для меню
        private void MenuNew_Click(object sender, EventArgs e)
        {
            if (_model.Shapes.Count > 0)
            {
                var result = MessageBox.Show("Создать новый проект? Несохраненные данные будут потеряны((",
                                           "Новый проект",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);
                if (result == DialogResult.No) return;
            }

            _model.Clear();
            _commandManager.ClearHistory();
            canvasControl1.RefreshCanvas();
        }

        private void MenuOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                dialog.Title = "Открыть проект";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var newModel = _serializationService.LoadFromFile(dialog.FileName);
                        _model = newModel;
                        canvasControl1.Model = _model;
                        _commandManager.ClearHistory();
                        canvasControl1.RefreshCanvas();

                        MessageBox.Show("Проект успешно загружен!)))", "Ура ура",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка :(",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void MenuSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                dialog.Title = "Сохранить проект";
                dialog.DefaultExt = "json";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _serializationService.SaveToFile(dialog.FileName, _model);
                        MessageBox.Show("Проект успешно сохранён!", "Успех",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }
    }
}