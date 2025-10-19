namespace graphic_editor.Views
{
    partial class ToolPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnRectangle = new Button();
            btnEllipse = new Button();
            btnLine = new Button();
            btnSelect = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            label1 = new Label();
            labelStrokeColor = new Label();
            labelFillColor = new Label();
            btnStrokeColor = new Button();
            btnFillColor = new Button();
            labelThickness = new Label();
            numThickness = new NumericUpDown();
            labelOpacity = new Label();
            trackOpacity = new TrackBar();
            labelOpacityValue = new Label();
            btnUndo = new Button();
            btnRedo = new Button();
            ((System.ComponentModel.ISupportInitialize)numThickness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackOpacity).BeginInit();
            SuspendLayout();
            // 
            // btnRectangle
            // 
            btnRectangle.Location = new Point(26, 46);
            btnRectangle.Name = "btnRectangle";
            btnRectangle.Size = new Size(178, 42);
            btnRectangle.TabIndex = 0;
            btnRectangle.Text = "Прямоугольник";
            btnRectangle.UseVisualStyleBackColor = true;
            // 
            // btnEllipse
            // 
            btnEllipse.Location = new Point(26, 94);
            btnEllipse.Name = "btnEllipse";
            btnEllipse.Size = new Size(178, 42);
            btnEllipse.TabIndex = 1;
            btnEllipse.Text = "Эллипс";
            btnEllipse.UseVisualStyleBackColor = true;
            // 
            // btnLine
            // 
            btnLine.Location = new Point(26, 142);
            btnLine.Name = "btnLine";
            btnLine.Size = new Size(178, 42);
            btnLine.TabIndex = 2;
            btnLine.Text = "Линия";
            btnLine.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            btnSelect.Location = new Point(26, 190);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(178, 42);
            btnSelect.TabIndex = 3;
            btnSelect.Text = "Выделение";
            btnSelect.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(26, 238);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(178, 42);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Удалить объект";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(26, 286);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(178, 42);
            btnClear.TabIndex = 5;
            btnClear.Text = "Очистить холст";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 17);
            label1.Name = "label1";
            label1.Size = new Size(103, 20);
            label1.TabIndex = 6;
            label1.Text = "Инструменты";
            // 
            // labelStrokeColor
            // 
            labelStrokeColor.AutoSize = true;
            labelStrokeColor.Location = new Point(34, 345);
            labelStrokeColor.Name = "labelStrokeColor";
            labelStrokeColor.Size = new Size(108, 20);
            labelStrokeColor.TabIndex = 7;
            labelStrokeColor.Text = "Цвет обводки:";
            // 
            // labelFillColor
            // 
            labelFillColor.AutoSize = true;
            labelFillColor.Location = new Point(34, 393);
            labelFillColor.Name = "labelFillColor";
            labelFillColor.Size = new Size(105, 20);
            labelFillColor.TabIndex = 8;
            labelFillColor.Text = "Цвет заливки:";
            // 
            // btnStrokeColor
            // 
            btnStrokeColor.Location = new Point(148, 334);
            btnStrokeColor.Name = "btnStrokeColor";
            btnStrokeColor.Size = new Size(56, 42);
            btnStrokeColor.TabIndex = 9;
            btnStrokeColor.UseVisualStyleBackColor = true;
            // 
            // btnFillColor
            // 
            btnFillColor.Location = new Point(148, 382);
            btnFillColor.Name = "btnFillColor";
            btnFillColor.Size = new Size(56, 42);
            btnFillColor.TabIndex = 10;
            btnFillColor.UseVisualStyleBackColor = true;
            // 
            // labelThickness
            // 
            labelThickness.AutoSize = true;
            labelThickness.Location = new Point(34, 437);
            labelThickness.Name = "labelThickness";
            labelThickness.Size = new Size(75, 20);
            labelThickness.TabIndex = 11;
            labelThickness.Text = "Толщина:";
            // 
            // numThickness
            // 
            numThickness.Location = new Point(151, 430);
            numThickness.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numThickness.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numThickness.Name = "numThickness";
            numThickness.Size = new Size(53, 27);
            numThickness.TabIndex = 12;
            numThickness.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // labelOpacity
            // 
            labelOpacity.AutoSize = true;
            labelOpacity.Location = new Point(34, 477);
            labelOpacity.Name = "labelOpacity";
            labelOpacity.Size = new Size(112, 20);
            labelOpacity.TabIndex = 13;
            labelOpacity.Text = "Прозрачность:";
            // 
            // trackOpacity
            // 
            trackOpacity.Location = new Point(26, 500);
            trackOpacity.Name = "trackOpacity";
            trackOpacity.Size = new Size(155, 56);
            trackOpacity.TabIndex = 14;
            // 
            // labelOpacityValue
            // 
            labelOpacityValue.AutoSize = true;
            labelOpacityValue.Location = new Point(177, 500);
            labelOpacityValue.Name = "labelOpacityValue";
            labelOpacityValue.Size = new Size(37, 20);
            labelOpacityValue.TabIndex = 15;
            labelOpacityValue.Text = "50%";
            // 
            // btnUndo
            // 
            btnUndo.Location = new Point(14, 548);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(99, 38);
            btnUndo.TabIndex = 16;
            btnUndo.Text = "Отменить";
            btnUndo.UseVisualStyleBackColor = true;
            // 
            // btnRedo
            // 
            btnRedo.Location = new Point(119, 548);
            btnRedo.Name = "btnRedo";
            btnRedo.Size = new Size(99, 38);
            btnRedo.TabIndex = 17;
            btnRedo.Text = "Повторить";
            btnRedo.UseVisualStyleBackColor = true;
            // 
            // ToolPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnRedo);
            Controls.Add(btnUndo);
            Controls.Add(labelOpacityValue);
            Controls.Add(trackOpacity);
            Controls.Add(labelOpacity);
            Controls.Add(numThickness);
            Controls.Add(labelThickness);
            Controls.Add(btnFillColor);
            Controls.Add(btnStrokeColor);
            Controls.Add(labelFillColor);
            Controls.Add(labelStrokeColor);
            Controls.Add(label1);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnSelect);
            Controls.Add(btnLine);
            Controls.Add(btnEllipse);
            Controls.Add(btnRectangle);
            Name = "ToolPanel";
            Size = new Size(228, 644);
            ((System.ComponentModel.ISupportInitialize)numThickness).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackOpacity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRectangle;
        private Button btnEllipse;
        private Button btnLine;
        private Button btnSelect;
        private Button btnDelete;
        private Button btnClear;
        private Label label1;
        private Label labelStrokeColor;
        private Label labelFillColor;
        private Button btnStrokeColor;
        private Button btnFillColor;
        private Label labelThickness;
        private NumericUpDown numThickness;
        private Label labelOpacity;
        private TrackBar trackOpacity;
        private Label labelOpacityValue;
        private Button btnUndo;
        private Button btnRedo;
    }
}
