using graphic_editor.Models;

namespace graphic_editor
{
    public partial class Form1 : Form
    {
        private CanvasModel _model = new CanvasModel();

        public Form1()
        {
            InitializeComponent();
            canvasControl1.Model = _model;


            SetupTestShapes(); //test
        }

        private void SetupTestShapes()
        {
            var rect = new RectangleShape()
            {
                Position = new PointF(50, 50),
                Size = new SizeF(100, 80),
                FillColor = Color.Red,
                StrokeColor = Color.DarkRed
            };


            var ellipse = new EllipseShape()
            {
                Position = new PointF(200, 80),
                Size = new SizeF(120, 100),
                FillColor = Color.Blue,
                StrokeColor = Color.DarkBlue
            };


            var line = new LineShape()
            {
                Position = new PointF(350, 50),
                EndPoint = new PointF(450, 150),
                StrokeColor = Color.Green,
                StrokeThickness = 3
            };


            _model.AddShape(rect);
            _model.AddShape(ellipse);
            _model.AddShape(line);
        }
    }
}
