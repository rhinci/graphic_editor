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
            SuspendLayout();
            // 
            // btnRectangle
            // 
            btnRectangle.Location = new Point(25, 107);
            btnRectangle.Name = "btnRectangle";
            btnRectangle.Size = new Size(178, 42);
            btnRectangle.TabIndex = 0;
            btnRectangle.Text = "Прямоугольник";
            btnRectangle.UseVisualStyleBackColor = true;
            // 
            // btnEllipse
            // 
            btnEllipse.Location = new Point(25, 155);
            btnEllipse.Name = "btnEllipse";
            btnEllipse.Size = new Size(178, 42);
            btnEllipse.TabIndex = 1;
            btnEllipse.Text = "Эллипс";
            btnEllipse.UseVisualStyleBackColor = true;
            // 
            // btnLine
            // 
            btnLine.Location = new Point(25, 203);
            btnLine.Name = "btnLine";
            btnLine.Size = new Size(178, 42);
            btnLine.TabIndex = 2;
            btnLine.Text = "Линия";
            btnLine.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            btnSelect.Location = new Point(25, 251);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(178, 42);
            btnSelect.TabIndex = 3;
            btnSelect.Text = "Выделение";
            btnSelect.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(25, 299);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(178, 42);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Удалить объект";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(25, 347);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(178, 42);
            btnClear.TabIndex = 5;
            btnClear.Text = "Очистить холст";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(64, 41);
            label1.Name = "label1";
            label1.Size = new Size(103, 20);
            label1.TabIndex = 6;
            label1.Text = "Инструменты";
            // 
            // ToolPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnSelect);
            Controls.Add(btnLine);
            Controls.Add(btnEllipse);
            Controls.Add(btnRectangle);
            Name = "ToolPanel";
            Size = new Size(228, 644);
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
    }
}
