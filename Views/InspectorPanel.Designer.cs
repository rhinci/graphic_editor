namespace graphic_editor.Views
{
    partial class InspectorPanel
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            labelWidth = new Label();
            labelHeight = new Label();
            label6 = new Label();
            btnApply = new Button();
            txtX = new TextBox();
            txtY = new TextBox();
            txtWidth = new TextBox();
            txtHeight = new TextBox();
            txtRotation = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 23);
            label1.Name = "label1";
            label1.Size = new Size(129, 20);
            label1.TabIndex = 0;
            label1.Text = "Свойства фигуры";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 124);
            label2.Name = "label2";
            label2.Size = new Size(21, 20);
            label2.TabIndex = 1;
            label2.Text = "X:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 167);
            label3.Name = "label3";
            label3.Size = new Size(20, 20);
            label3.TabIndex = 2;
            label3.Text = "Y:";
            // 
            // labelWidth
            // 
            labelWidth.AutoSize = true;
            labelWidth.Location = new Point(26, 202);
            labelWidth.Name = "labelWidth";
            labelWidth.Size = new Size(70, 20);
            labelWidth.TabIndex = 3;
            labelWidth.Text = "Ширина:";
            // 
            // labelHeight
            // 
            labelHeight.AutoSize = true;
            labelHeight.Location = new Point(26, 243);
            labelHeight.Name = "labelHeight";
            labelHeight.Size = new Size(62, 20);
            labelHeight.TabIndex = 4;
            labelHeight.Text = "Высота:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 288);
            label6.Name = "label6";
            label6.Size = new Size(73, 20);
            label6.TabIndex = 5;
            label6.Text = "Поворот:";
            // 
            // btnApply
            // 
            btnApply.Location = new Point(26, 509);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(106, 30);
            btnApply.TabIndex = 7;
            btnApply.Text = "Применить";
            btnApply.UseVisualStyleBackColor = true;
            // 
            // txtX
            // 
            txtX.Location = new Point(102, 121);
            txtX.Name = "txtX";
            txtX.Size = new Size(46, 27);
            txtX.TabIndex = 8;
            // 
            // txtY
            // 
            txtY.Location = new Point(102, 164);
            txtY.Name = "txtY";
            txtY.Size = new Size(46, 27);
            txtY.TabIndex = 9;
            // 
            // txtWidth
            // 
            txtWidth.Location = new Point(102, 202);
            txtWidth.Name = "txtWidth";
            txtWidth.Size = new Size(46, 27);
            txtWidth.TabIndex = 10;
            // 
            // txtHeight
            // 
            txtHeight.Location = new Point(102, 240);
            txtHeight.Name = "txtHeight";
            txtHeight.Size = new Size(46, 27);
            txtHeight.TabIndex = 11;
            // 
            // txtRotation
            // 
            txtRotation.Location = new Point(102, 285);
            txtRotation.Name = "txtRotation";
            txtRotation.Size = new Size(46, 27);
            txtRotation.TabIndex = 12;
            // 
            // InspectorPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtRotation);
            Controls.Add(txtHeight);
            Controls.Add(txtWidth);
            Controls.Add(txtY);
            Controls.Add(txtX);
            Controls.Add(btnApply);
            Controls.Add(label6);
            Controls.Add(labelHeight);
            Controls.Add(labelWidth);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "InspectorPanel";
            Size = new Size(161, 637);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label labelWidth;
        private Label labelHeight;
        private Label label6;
        private Button btnApply;
        private TextBox txtX;
        private TextBox txtY;
        private TextBox txtWidth;
        private TextBox txtHeight;
        private TextBox txtRotation;
    }
}
