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
    public partial class ToolPanel : UserControl
    {
        public event EventHandler<string>? ToolSelected;
        public event EventHandler? DeleteRequested;
        public event EventHandler? ClearRequested;

        private string _selectedTool = "select";
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

            foreach (Control control in this.Controls)
            {
                if (control is Button btn)
                {
                    btn.Click += (sender, e) => HandleButtonClick(btn.Text);
                }
            }
        }

        private void HandleButtonClick(string buttonText)
        {
            switch (buttonText)
            {
                case "Прямоугольник":
                    SelectedTool = "rectangle";
                    ToolSelected?.Invoke(this, "rectangle");
                    break;
                case "Эллипс":
                    SelectedTool = "ellipse";
                    ToolSelected?.Invoke(this, "ellipse");
                    break;
                case "Линия":
                    SelectedTool = "line";
                    ToolSelected?.Invoke(this, "line");
                    break;
                case "Выделение":
                    SelectedTool = "select";
                    ToolSelected?.Invoke(this, "select");
                    break;
                case "Удалить объект":
                    DeleteRequested?.Invoke(this, EventArgs.Empty);
                    break;
                case "Очистить холст":
                    ClearRequested?.Invoke(this, EventArgs.Empty);
                    break;
            }
        }


        private void UpdateButtonAppearance()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button btn)
                {
                    btn.BackColor = SystemColors.Control;
                    btn.UseVisualStyleBackColor = true;
                }
            }


            string targetText = _selectedTool switch
            {
                "rectangle" => "Прямоугольник",
                "ellipse" => "Эллипс",
                "line" => "Линия",
                "select" => "Выделение",
                _ => ""
            };

            foreach (Control control in this.Controls)
            {
                if (control is Button btn && btn.Text == targetText)
                {
                    btn.BackColor = Color.LightBlue;
                }
            }
        }
    }
}
