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
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            btnInspectorFillColor = new Button();
            btnInspectorStrokeColor = new Button();
            trackFillOpacity = new TrackBar();
            labelOpacityValue = new Label();
            numStrokeThickness = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)trackFillOpacity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStrokeThickness).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 23);
            label1.Name = "label1";
            label1.Size = new Size(129, 20);
            label1.TabIndex = 0;
            label1.Text = "Свойства фигуры";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 70);
            label2.Name = "label2";
            label2.Size = new Size(21, 20);
            label2.TabIndex = 1;
            label2.Text = "X:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 113);
            label3.Name = "label3";
            label3.Size = new Size(20, 20);
            label3.TabIndex = 2;
            label3.Text = "Y:";
            // 
            // labelWidth
            // 
            labelWidth.AutoSize = true;
            labelWidth.Location = new Point(26, 148);
            labelWidth.Name = "labelWidth";
            labelWidth.Size = new Size(70, 20);
            labelWidth.TabIndex = 3;
            labelWidth.Text = "Ширина:";
            // 
            // labelHeight
            // 
            labelHeight.AutoSize = true;
            labelHeight.Location = new Point(26, 189);
            labelHeight.Name = "labelHeight";
            labelHeight.Size = new Size(62, 20);
            labelHeight.TabIndex = 4;
            labelHeight.Text = "Высота:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 234);
            label6.Name = "label6";
            label6.Size = new Size(73, 20);
            label6.TabIndex = 5;
            label6.Text = "Поворот:";
            // 
            // btnApply
            // 
            btnApply.Location = new Point(26, 550);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(106, 30);
            btnApply.TabIndex = 7;
            btnApply.Text = "Применить";
            btnApply.UseVisualStyleBackColor = true;
            // 
            // txtX
            // 
            txtX.Location = new Point(102, 67);
            txtX.Name = "txtX";
            txtX.Size = new Size(46, 27);
            txtX.TabIndex = 8;
            // 
            // txtY
            // 
            txtY.Location = new Point(102, 110);
            txtY.Name = "txtY";
            txtY.Size = new Size(46, 27);
            txtY.TabIndex = 9;
            // 
            // txtWidth
            // 
            txtWidth.Location = new Point(102, 148);
            txtWidth.Name = "txtWidth";
            txtWidth.Size = new Size(46, 27);
            txtWidth.TabIndex = 10;
            // 
            // txtHeight
            // 
            txtHeight.Location = new Point(102, 186);
            txtHeight.Name = "txtHeight";
            txtHeight.Size = new Size(46, 27);
            txtHeight.TabIndex = 11;
            // 
            // txtRotation
            // 
            txtRotation.Location = new Point(102, 231);
            txtRotation.Name = "txtRotation";
            txtRotation.Size = new Size(46, 27);
            txtRotation.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 279);
            label4.Name = "label4";
            label4.Size = new Size(105, 20);
            label4.TabIndex = 13;
            label4.Text = "Цвет заливки:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 322);
            label5.Name = "label5";
            label5.Size = new Size(108, 20);
            label5.TabIndex = 14;
            label5.Text = "Цвет обводки:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(26, 360);
            label7.Name = "label7";
            label7.Size = new Size(112, 20);
            label7.TabIndex = 15;
            label7.Text = "Прозрачность:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(26, 449);
            label8.Name = "label8";
            label8.Size = new Size(75, 20);
            label8.TabIndex = 16;
            label8.Text = "Толщина:";
            // 
            // btnInspectorFillColor
            // 
            btnInspectorFillColor.Location = new Point(134, 278);
            btnInspectorFillColor.Name = "btnInspectorFillColor";
            btnInspectorFillColor.Size = new Size(43, 28);
            btnInspectorFillColor.TabIndex = 17;
            btnInspectorFillColor.UseVisualStyleBackColor = true;
            // 
            // btnInspectorStrokeColor
            // 
            btnInspectorStrokeColor.Location = new Point(134, 322);
            btnInspectorStrokeColor.Name = "btnInspectorStrokeColor";
            btnInspectorStrokeColor.Size = new Size(43, 28);
            btnInspectorStrokeColor.TabIndex = 18;
            btnInspectorStrokeColor.UseVisualStyleBackColor = true;
            // 
            // trackFillOpacity
            // 
            trackFillOpacity.Location = new Point(26, 390);
            trackFillOpacity.Name = "trackFillOpacity";
            trackFillOpacity.Size = new Size(129, 56);
            trackFillOpacity.TabIndex = 19;
            // 
            // labelOpacityValue
            // 
            labelOpacityValue.AutoSize = true;
            labelOpacityValue.Location = new Point(138, 361);
            labelOpacityValue.Name = "labelOpacityValue";
            labelOpacityValue.Size = new Size(37, 20);
            labelOpacityValue.TabIndex = 20;
            labelOpacityValue.Text = "50%";
            // 
            // numStrokeThickness
            // 
            numStrokeThickness.Location = new Point(112, 448);
            numStrokeThickness.Name = "numStrokeThickness";
            numStrokeThickness.Size = new Size(37, 27);
            numStrokeThickness.TabIndex = 21;
            // 
            // InspectorPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(numStrokeThickness);
            Controls.Add(labelOpacityValue);
            Controls.Add(trackFillOpacity);
            Controls.Add(btnInspectorStrokeColor);
            Controls.Add(btnInspectorFillColor);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
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
            Size = new Size(185, 637);
            ((System.ComponentModel.ISupportInitialize)trackFillOpacity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStrokeThickness).EndInit();
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
        private Label label4;
        private Label label5;
        private Label label7;
        private Label label8;
        private Button btnInspectorFillColor;
        private Button btnInspectorStrokeColor;
        private TrackBar trackFillOpacity;
        private Label labelOpacityValue;
        private NumericUpDown numStrokeThickness;
    }
}
