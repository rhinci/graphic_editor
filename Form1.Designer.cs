namespace graphic_editor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            новыйToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            canvasControl1 = new graphic_editor.Views.CanvasControl();
            toolPanel1 = new graphic_editor.Views.ToolPanel();
            inspectorPanel1 = new graphic_editor.Views.InspectorPanel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1213, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { новыйToolStripMenuItem, открытьToolStripMenuItem, сохранитьToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(59, 24);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // новыйToolStripMenuItem
            // 
            новыйToolStripMenuItem.Name = "новыйToolStripMenuItem";
            новыйToolStripMenuItem.Size = new Size(166, 26);
            новыйToolStripMenuItem.Text = "Новый";
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new Size(166, 26);
            открытьToolStripMenuItem.Text = "Открыть";
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(166, 26);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // canvasControl1
            // 
            canvasControl1.BackColor = Color.White;
            canvasControl1.CurrentDrawingShape = null;
            canvasControl1.IsCreatingShape = false;
            canvasControl1.Location = new Point(247, 31);
            canvasControl1.Model = null;
            canvasControl1.Name = "canvasControl1";
            canvasControl1.Size = new Size(710, 587);
            canvasControl1.TabIndex = 1;
            canvasControl1.MouseDown += canvasControl1_MouseDown;
            canvasControl1.MouseMove += canvasControl1_MouseMove;
            canvasControl1.MouseUp += canvasControl1_MouseUp;
            // 
            // toolPanel1
            // 
            toolPanel1.FillColor = Color.LightBlue;
            toolPanel1.FillOpacity = 0.5F;
            toolPanel1.Location = new Point(0, 31);
            toolPanel1.Name = "toolPanel1";
            toolPanel1.Size = new Size(241, 805);
            toolPanel1.StrokeColor = Color.Black;
            toolPanel1.TabIndex = 2;
            // 
            // inspectorPanel1
            // 
            inspectorPanel1.Location = new Point(964, 31);
            inspectorPanel1.Name = "inspectorPanel1";
            inspectorPanel1.Size = new Size(237, 587);
            inspectorPanel1.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1213, 715);
            Controls.Add(inspectorPanel1);
            Controls.Add(toolPanel1);
            Controls.Add(canvasControl1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem новыйToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private Views.CanvasControl canvasControl1;
        private Views.ToolPanel toolPanel1;
        private Views.InspectorPanel inspectorPanel1;
        //private Views.InspectorPanel inspectorPanel1; 
    }
}
