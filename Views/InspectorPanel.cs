using graphic_editor.Commands;
using graphic_editor.Models;
using graphic_editor.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace graphic_editor.Views
{
    public partial class InspectorPanel : UserControl
    {
        private Shape? _boundShape;
        private CommandManager? _commandManager;

        public InspectorPanel()
        {
            InitializeComponent();
            SetEnabled(false);

            SubscribeToEvents();

            trackFillOpacity.Minimum = 0;
            trackFillOpacity.Maximum = 100;
            trackFillOpacity.Value = 50;

            numStrokeThickness.Minimum = 1;
            numStrokeThickness.Maximum = 20;
            numStrokeThickness.Value = 2;
        }

        private void SubscribeToEvents()
        {
            txtX.KeyDown += TextBox_KeyDown;
            txtY.KeyDown += TextBox_KeyDown;
            txtWidth.KeyDown += TextBox_KeyDown;
            txtHeight.KeyDown += TextBox_KeyDown;
            txtRotation.KeyDown += TextBox_KeyDown;

            btnApply.Click += btnApply_Click;

            btnInspectorFillColor.Click += BtnInspectorFillColor_Click;
            btnInspectorStrokeColor.Click += BtnInspectorStrokeColor_Click;

            trackFillOpacity.ValueChanged += TrackFillOpacity_ValueChanged;

            numStrokeThickness.ValueChanged += NumStrokeThickness_ValueChanged;
        }   

        public void BindShape(Shape? shape)
        {
            _boundShape = shape;

            if (shape != null)
            {
                SetEnabled(true);
                UpdateFieldsFromShape();
            }
            else
            {
                SetEnabled(false);
                ClearFields();
            }
        }

        private void UpdateFieldsFromShape()
        {
            if (_boundShape == null) return;

            txtX.Text = _boundShape.Position.X.ToString("0.##");
            txtY.Text = _boundShape.Position.Y.ToString("0.##");

            if (_boundShape is RectangleShape rect)
            {
                txtWidth.Text = rect.Size.Width.ToString("0.##");
                txtHeight.Text = rect.Size.Height.ToString("0.##");
                labelWidth.Text = "Ширина:";
                labelHeight.Text = "Высота:";
            }
            else if (_boundShape is EllipseShape ellipse)
            {
                txtWidth.Text = ellipse.Size.Width.ToString("0.##");
                txtHeight.Text = ellipse.Size.Height.ToString("0.##");
                labelWidth.Text = "Ширина:";
                labelHeight.Text = "Высота:";
            }
            else if (_boundShape is LineShape line)
            {
                txtWidth.Text = (line.EndPoint.X - line.Position.X).ToString("0.##");
                txtHeight.Text = (line.EndPoint.Y - line.Position.Y).ToString("0.##");
                labelWidth.Text = "ΔX:";
                labelHeight.Text = "ΔY:";
            }

            txtRotation.Text = _boundShape.Rotation.ToString("0.##");

            int opacityPercentage = (int)(_boundShape.FillOpacity * 100);
            trackFillOpacity.Value = opacityPercentage;
            labelOpacityValue.Text = $"{opacityPercentage}%";

            numStrokeThickness.Value = (decimal)_boundShape.StrokeThickness;
        }

        private void UpdateColorButtons()
        {
            if (_boundShape == null) return;

            btnInspectorFillColor.BackColor = _boundShape.FillColor;
            btnInspectorFillColor.ForeColor = GetContrastColor(_boundShape.FillColor);

            btnInspectorStrokeColor.BackColor = _boundShape.StrokeColor;
            btnInspectorStrokeColor.ForeColor = GetContrastColor(_boundShape.StrokeColor);
        }

        private Color GetContrastColor(Color color)
        {
            double luminance = (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;
            return luminance > 0.5 ? Color.Black : Color.White;
        }


        public void SetCommandManager(CommandManager commandManager)
        {
            _commandManager = commandManager;
        }

        private void ApplyChangesToShape()
        {
            if (_boundShape == null || _commandManager == null) return;

            try
            {
                var newState = new ShapeMemento(_boundShape);

                UpdateShapeFromFields(_boundShape);

                var command = new ModifyShapeCommand(GetCanvasModel(), _boundShape, newState);
                _commandManager.ExecuteCommand(command);
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateShapeFromFields(Shape shape)
        {
            float x = float.Parse(txtX.Text);
            float y = float.Parse(txtY.Text);
            shape.Position = new PointF(x, y);

            if (shape is RectangleShape rect)
            {
                float width = float.Parse(txtWidth.Text);
                float height = float.Parse(txtHeight.Text);
                rect.Size = new SizeF(width, height);
            }
            else if (shape is EllipseShape ellipse)
            {
                float width = float.Parse(txtWidth.Text);
                float height = float.Parse(txtHeight.Text);
                ellipse.Size = new SizeF(width, height);
            }
            else if (shape is LineShape line)
            {
                float deltaX = float.Parse(txtWidth.Text);
                float deltaY = float.Parse(txtHeight.Text);
                line.EndPoint = new PointF(x + deltaX, y + deltaY);
            }

            shape.Rotation = float.Parse(txtRotation.Text);
        }

        private CanvasModel GetCanvasModel()
        {
            if (this.Parent is Form1 mainForm)
            {
                return mainForm.GetCanvasModel();
            }
            return new CanvasModel();
        }

        private void SetEnabled(bool enabled)
        {
            txtX.Enabled = enabled;
            txtY.Enabled = enabled;
            txtWidth.Enabled = enabled;
            txtHeight.Enabled = enabled;
            txtRotation.Enabled = enabled;
            btnApply.Enabled = enabled;

            btnInspectorFillColor.Enabled = enabled;
            trackFillOpacity.Enabled = enabled;
            btnInspectorStrokeColor.Enabled = enabled;
            numStrokeThickness.Enabled = enabled;
        }

        private void ClearFields()
        {
            txtX.Text = "";
            txtY.Text = "";
            txtWidth.Text = "";
            txtHeight.Text = "";
            txtRotation.Text = "";

            trackFillOpacity.Value = 50;
            labelOpacityValue.Text = "50%";
            numStrokeThickness.Value = 2;

            btnInspectorFillColor.BackColor = SystemColors.Control;
            btnInspectorStrokeColor.BackColor = SystemColors.Control;
        }

        public event EventHandler? ShapeUpdated;

        private void btnApply_Click(object sender, EventArgs e)
        {
            ApplyChangesToShape();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ApplyChangesToShape();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }


        private void BtnInspectorFillColor_Click(object sender, EventArgs e)
        {
            if (_boundShape == null || _commandManager == null) return;

            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = _boundShape.FillColor;
                colorDialog.FullOpen = true;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    var oldState = new ShapeMemento(_boundShape);

                    _boundShape.FillColor = colorDialog.Color;
                    UpdateColorButtons();

                    var newState = new ShapeMemento(_boundShape);

                    var command = new ModifyShapeCommand(GetCanvasModel(), _boundShape, newState);
                    _commandManager.ExecuteCommand(command);

                    ShapeUpdated?.Invoke(this, EventArgs.Empty);
                }
            }
        }


        private void BtnInspectorStrokeColor_Click(object sender, EventArgs e)
        {
            if (_boundShape == null) return;

            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = _boundShape.StrokeColor;
                colorDialog.FullOpen = true;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    _boundShape.StrokeColor = colorDialog.Color;
                    UpdateColorButtons();
                    ShapeUpdated?.Invoke(this, EventArgs.Empty);
                }
            }
        }


        private void TrackFillOpacity_ValueChanged(object sender, EventArgs e)
        {
            if (_boundShape == null || _commandManager == null) return;

            var oldState = new ShapeMemento(_boundShape);

            float opacity = trackFillOpacity.Value / 100f;
            _boundShape.FillOpacity = opacity;
            labelOpacityValue.Text = $"{trackFillOpacity.Value}%";

            var newState = new ShapeMemento(_boundShape);

            var command = new ModifyShapeCommand(GetCanvasModel(), _boundShape, newState);
            _commandManager.ExecuteCommand(command);

            ShapeUpdated?.Invoke(this, EventArgs.Empty);
        }

        private void NumStrokeThickness_ValueChanged(object sender, EventArgs e)
        {
            if (_boundShape == null || _commandManager == null) return;

            // Сохраняем состояние до изменения
            var oldState = new ShapeMemento(_boundShape);

            // Применяем изменение
            _boundShape.StrokeThickness = (float)numStrokeThickness.Value;

            // Сохраняем состояние после изменения
            var newState = new ShapeMemento(_boundShape);

            // Создаем и выполняем команду
            var command = new ModifyShapeCommand(GetCanvasModel(), _boundShape, newState);
            _commandManager.ExecuteCommand(command);

            ShapeUpdated?.Invoke(this, EventArgs.Empty);
        }
    }
}