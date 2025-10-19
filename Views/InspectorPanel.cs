using System;
using System.Drawing;
using System.Windows.Forms;
using graphic_editor.Models;

namespace graphic_editor.Views
{
    public partial class InspectorPanel : UserControl
    {
        private Shape? _boundShape;

        public InspectorPanel()
        {
            InitializeComponent();
            SetEnabled(false);

            SubscribeToTextBoxEvents();
            btnApply.Click += btnApply_Click;
        }

        private void SubscribeToTextBoxEvents()
        {
            txtX.KeyDown += TextBox_KeyDown;
            txtY.KeyDown += TextBox_KeyDown;
            txtWidth.KeyDown += TextBox_KeyDown;
            txtHeight.KeyDown += TextBox_KeyDown;
            txtRotation.KeyDown += TextBox_KeyDown;
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
        }

        private void ApplyChangesToShape()
        {
            if (_boundShape == null) return;

            try
            {
                float x = float.Parse(txtX.Text);
                float y = float.Parse(txtY.Text);
                _boundShape.Position = new PointF(x, y);

                if (_boundShape is RectangleShape rect)
                {
                    float width = float.Parse(txtWidth.Text);
                    float height = float.Parse(txtHeight.Text);
                }
                else if (_boundShape is EllipseShape ellipse)
                {
                    float width = float.Parse(txtWidth.Text);
                    float height = float.Parse(txtHeight.Text);
                }
                else if (_boundShape is LineShape line)
                {
                    float deltaX = float.Parse(txtWidth.Text);
                    float deltaY = float.Parse(txtHeight.Text);
                    line.EndPoint = new PointF(x + deltaX, y + deltaY);
                }

                float rotation = float.Parse(txtRotation.Text);

                _boundShape.Rotation = rotation;

                ShapeUpdated?.Invoke(this, EventArgs.Empty);

                UpdateFieldsFromShape();
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Ошибка формата: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Общая ошибка: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetEnabled(bool enabled)
        {
            txtX.Enabled = enabled;
            txtY.Enabled = enabled;
            txtWidth.Enabled = enabled;
            txtHeight.Enabled = enabled;
            txtRotation.Enabled = enabled;
            btnApply.Enabled = enabled;
        }

        private void ClearFields()
        {
            txtX.Text = "";
            txtY.Text = "";
            txtWidth.Text = "";
            txtHeight.Text = "";
            txtRotation.Text = "";
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
    }
}