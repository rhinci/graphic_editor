using graphic_editor.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace graphic_editor.Services
{
    public class SerializationService
    {
        private class SerializableShape
        {
            public string Type { get; set; } = string.Empty;
            public float X { get; set; }
            public float Y { get; set; }
            public float Width { get; set; }
            public float Height { get; set; }
            public float EndX { get; set; }
            public float EndY { get; set; }
            public float Rotation { get; set; }
            public string FillColor { get; set; } = string.Empty;
            public float FillOpacity { get; set; }
            public string StrokeColor { get; set; } = string.Empty;
            public float StrokeThickness { get; set; }
        }

        private class SerializableCanvas
        {
            public List<SerializableShape> Shapes { get; set; } = new List<SerializableShape>();
        }
        public string Serialize(CanvasModel model)
        {
            var canvas = new SerializableCanvas();

            foreach (var shape in model.Shapes)
            {
                var serializableShape = new SerializableShape
                {
                    Type = shape.GetType().Name,
                    X = shape.Position.X,
                    Y = shape.Position.Y,
                    Rotation = shape.Rotation,
                    FillColor = ColorToString(shape.FillColor),
                    FillOpacity = shape.FillOpacity,
                    StrokeColor = ColorToString(shape.StrokeColor),
                    StrokeThickness = shape.StrokeThickness
                };

                if (shape is RectangleShape rect)
                {
                    serializableShape.Width = rect.Size.Width;
                    serializableShape.Height = rect.Size.Height;
                }
                else if (shape is EllipseShape ellipse)
                {
                    serializableShape.Width = ellipse.Size.Width;
                    serializableShape.Height = ellipse.Size.Height;
                }
                else if (shape is LineShape line)
                {
                    serializableShape.EndX = line.EndPoint.X;
                    serializableShape.EndY = line.EndPoint.Y;
                }

                canvas.Shapes.Add(serializableShape);
            }

            return JsonConvert.SerializeObject(canvas, Formatting.Indented);
        }

        public CanvasModel Deserialize(string json)
        {
            var canvas = JsonConvert.DeserializeObject<SerializableCanvas>(json);
            if (canvas == null) return new CanvasModel();

            var model = new CanvasModel();

            foreach (var serializableShape in canvas.Shapes)
            {
                Shape shape = serializableShape.Type switch
                {
                    "RectangleShape" => new RectangleShape
                    {
                        Size = new System.Drawing.SizeF(serializableShape.Width, serializableShape.Height)
                    },
                    "EllipseShape" => new EllipseShape
                    {
                        Size = new System.Drawing.SizeF(serializableShape.Width, serializableShape.Height)
                    },
                    "LineShape" => new LineShape
                    {
                        EndPoint = new System.Drawing.PointF(serializableShape.EndX, serializableShape.EndY)
                    },
                    _ => throw new InvalidOperationException($"Неизвестный тип фигуры: {serializableShape.Type}")
                };

                shape.Position = new System.Drawing.PointF(serializableShape.X, serializableShape.Y);
                shape.Rotation = serializableShape.Rotation;
                shape.FillColor = StringToColor(serializableShape.FillColor);
                shape.FillOpacity = serializableShape.FillOpacity;
                shape.StrokeColor = StringToColor(serializableShape.StrokeColor);
                shape.StrokeThickness = serializableShape.StrokeThickness;

                model.AddShape(shape);
            }

            return model;
        }

        public void SaveToFile(string path, CanvasModel model)
        {
            string json = Serialize(model);
            File.WriteAllText(path, json);
        }

        public CanvasModel LoadFromFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Файл не найден", path);

            string json = File.ReadAllText(path);
            return Deserialize(json);
        }
                        
        private string ColorToString(System.Drawing.Color color)
        {
            return color.ToArgb().ToString("X");
        }

        private System.Drawing.Color StringToColor(string colorString)
        {
            return System.Drawing.Color.FromArgb(Convert.ToInt32(colorString, 16));
        }
    }
}
