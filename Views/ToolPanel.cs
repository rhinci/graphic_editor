using System;
using System.Drawing;
using System.Windows.Forms;

namespace graphic_editor.Views
{
    public partial class ToolPanel : UserControl
    {
        public event EventHandler<string>? ToolSelected;
        public event EventHandler? DeleteRequested;
        public event EventHandler? ClearRequested;

        public event EventHandler<Color>? FillColorChanged;
        public event EventHandler<Color>? StrokeColorChanged;
        public event EventHandler<float>? StrokeThicknessChanged;
        public event EventHandler<float>? FillOpacityChanged;

        public event EventHandler? UndoRequested;
        public event EventHandler? RedoRequested;

        private string _selectedTool = "select";

        private float _fillOpacity = 0.5f;

        private Color _fillColor = Color.LightBlue;
        public Color FillColor
        {
            get { return _fillColor; }
            set
            {
                _fillColor = value;
                UpdateColorButtons();
            }
        }

        private Color _strokeColor = Color.Black;
        public Color StrokeColor
        {
            get { return _strokeColor; }
            set
            {
                _strokeColor = value;
                UpdateColorButtons();
            }
        }

        public float FillOpacity
        {
            get { return _fillOpacity; }
            set
            {
                _fillOpacity = value;
                UpdateOpacityDisplay();
            }
        }

        public string SelectedTool
        {
            get { return _selectedTool; }
            private set
            {
                _selectedTool = value;
                UpdateButtonAppearance();
            }
        }

        public ToolPanel()
        {
            InitializeComponent();
            UpdateButtonAppearance();
            UpdateColorButtons();
            UpdateOpacityDisplay();

            numThickness.Value = 2;
            numThickness.ValueChanged += numThickness_ValueChanged;

            trackOpacity.Minimum = 0;
            trackOpacity.Maximum = 100;
            trackOpacity.Value = 50;
            trackOpacity.ValueChanged += trackOpacity_ValueChanged;

            btnRectangle.Click += (s, e) => HandleToolClick("rectangle");
            btnEllipse.Click += (s, e) => HandleToolClick("ellipse");
            btnLine.Click += (s, e) => HandleToolClick("line");
            btnSelect.Click += (s, e) => HandleToolClick("select");
            btnDelete.Click += (s, e) => DeleteRequested?.Invoke(this, EventArgs.Empty);
            btnClear.Click += (s, e) => ClearRequested?.Invoke(this, EventArgs.Empty);

            btnUndo.Click += (s, e) => UndoRequested?.Invoke(this, EventArgs.Empty);
            btnRedo.Click += (s, e) => RedoRequested?.Invoke(this, EventArgs.Empty);

            btnFillColor.Click += BtnFillColor_Click;
            btnStrokeColor.Click += BtnStrokeColor_Click;

            UpdateUndoRedoButtons(false, false);
        }



        public void SetUndoRedoState(bool canUndo, bool canRedo)
        {
            btnUndo.Enabled = canUndo;
            btnRedo.Enabled = canRedo;

            btnUndo.BackColor = canUndo ? SystemColors.Control : Color.LightGray;
            btnRedo.BackColor = canRedo ? SystemColors.Control : Color.LightGray;
        }
        private void UpdateUndoRedoButtons(bool canUndo, bool canRedo)
        {
            btnUndo.Enabled = canUndo;
            btnRedo.Enabled = canRedo;

            btnUndo.BackColor = canUndo ? SystemColors.Control : Color.LightGray;
            btnRedo.BackColor = canRedo ? SystemColors.Control : Color.LightGray;
        }



        private void BtnFillColor_Click(object sender, EventArgs e)
        {
            ShowColorDialog(true);
        }

        private void BtnStrokeColor_Click(object sender, EventArgs e)
        {
            ShowColorDialog(false);
        }

        private void HandleToolClick(string tool)
        {
            SelectedTool = tool;
            ToolSelected?.Invoke(this, tool);
        }

        private void UpdateColorButtons()
        {
            btnFillColor.BackColor = _fillColor;
            btnFillColor.ForeColor = GetContrastColor(_fillColor);
            btnFillColor.Text = "";

            btnStrokeColor.BackColor = _strokeColor;
            btnStrokeColor.ForeColor = GetContrastColor(_strokeColor);
            btnStrokeColor.Text = "";
        }

        private Color GetContrastColor(Color color)
        {
            double luminance = (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;
            return luminance > 0.5 ? Color.Black : Color.White;
        }

        private void ShowColorDialog(bool isFillColor)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = isFillColor ? _fillColor : _strokeColor;
                colorDialog.FullOpen = true;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    if (isFillColor)
                    {
                        FillColor = colorDialog.Color;
                        FillColorChanged?.Invoke(this, colorDialog.Color);
                    }
                    else
                    {
                        StrokeColor = colorDialog.Color;
                        StrokeColorChanged?.Invoke(this, colorDialog.Color);
                    }
                }
            }
        }

        private void numThickness_ValueChanged(object sender, EventArgs e)
        {
            StrokeThicknessChanged?.Invoke(this, (float)numThickness.Value);
        }

        private void UpdateButtonAppearance()
        {
            btnRectangle.BackColor = SystemColors.Control;
            btnEllipse.BackColor = SystemColors.Control;
            btnLine.BackColor = SystemColors.Control;
            btnSelect.BackColor = SystemColors.Control;

            switch (_selectedTool)
            {
                case "rectangle": btnRectangle.BackColor = Color.LightBlue; break;
                case "ellipse": btnEllipse.BackColor = Color.LightBlue; break;
                case "line": btnLine.BackColor = Color.LightBlue; break;
                case "select": btnSelect.BackColor = Color.LightBlue; break;
            }
        }

        private void UpdateOpacityDisplay()
        {
            int percentage = (int)(_fillOpacity * 100);
            labelOpacityValue.Text = $"{percentage}%";
            UpdateColorButtonsWithOpacity();
        }

        private void UpdateColorButtonsWithOpacity()
        {
            Color fillColorWithOpacity = Color.FromArgb((int)(_fillOpacity * 255), _fillColor);

            btnFillColor.BackColor = fillColorWithOpacity;
            btnFillColor.ForeColor = GetContrastColor(fillColorWithOpacity);
            btnFillColor.Text = "";
        }

        private void trackOpacity_ValueChanged(object sender, EventArgs e)
        {
            float opacity = trackOpacity.Value / 100f;
            FillOpacity = opacity;
            FillOpacityChanged?.Invoke(this, opacity);
        }
    }
}