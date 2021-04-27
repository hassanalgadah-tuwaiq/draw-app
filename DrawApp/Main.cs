using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawApp
{
    public partial class Main : Form
    {
        List<Shape> shapes = new List<Shape>();

        ShapeType selectedShapeType = ShapeType.Circle;
        Pen pen = new Pen(Brushes.Black, 3);

        /**
         * Tracking drawing line
         * 
         */
        Point startPoint;
        Point currentPoint;
        bool isMouseDown = false;
        // ref to shapes[last]
        GraphicsPath gPaths = new GraphicsPath();

        public Main()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (Shape shape in shapes) shape.SetPen(pen).Draw(e.Graphics);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (gPaths.IsOutlineVisible(e.Location, pen))
            {
                //code



                return;
            }

            if (selectedShapeType == ShapeType.Line)
            {
                // todo: check if left button clocled
                startPoint = e.Location;
                currentPoint = e.Location;
                shapes.Add(new Line(pen)
                {
                    StartPoint = startPoint,
                    EndPoint = currentPoint
                });
                isMouseDown = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.selectedShapeType = ShapeType.Circle;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //.. code
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {

            if (selectedShapeType == ShapeType.Line)
            {
                Line lastLine = shapes[shapes.Count - 1] as Line;
                gPaths.AddLine(lastLine.StartPoint, lastLine.EndPoint);
                isMouseDown = false;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

            if (selectedShapeType == ShapeType.Line)
            {
                if (isMouseDown)
                {
                    shapes[shapes.Count - 1].EndPoint = e.Location;
                    ((Panel)sender).Invalidate();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            selectedShapeType = ShapeType.Line;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            // delete this
        }
    }
}
