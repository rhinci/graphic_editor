using graphic_editor.Models;
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
    public partial class CanvasControl : UserControl
    {
        private CanvasModel? _model;
        public CanvasModel? Model
        {
            get { return _model; }
            set
            {
                _model = value;
                this.Invalidate();
            }
        }


        public CanvasControl()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.BackColor = Color.White;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_model == null) return;
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


            foreach (var shape in _model.Shapes)
            {
                shape.Draw(g);
            }
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (_model == null) return;
            PointF clickPoint = new PointF(e.X, e.Y);
            _model.SelectShapeAtPoint(clickPoint);
            this.Invalidate();
        }


        public void RefreshCanvas()
        {
            this.Invalidate();
        }
    }
}
