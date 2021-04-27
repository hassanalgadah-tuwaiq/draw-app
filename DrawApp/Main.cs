using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawApp
{
    public partial class Main : Form
    {
        List<Shape> shapes = new List<Shape>();

        ShapeType selectedShapeType = ShapeType.Line;
        Pen pen = new Pen(Brushes.Black, 3);

        /**
         * Tracking drawing line actions
         * 
         */
        Line tempLineObject = null; // use it to cache start drawing point
        bool isDrawingLine = false;


        public Main()
        {
            InitializeComponent();

            //Pen pen = new Pen(Brushes.Black, 3);
            //Line line = new Line(pen)
            //{
            //    StartPoint = new Point(100, 100),
            //    EndPoint = new Point(100,100)
            //};

            //shapes.Add(line);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            MessageBox.Show("Test");
            foreach (Shape shape in shapes) shape.Draw(e.Graphics);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawingLine = true;
            this.shapes.Add(new Line(this.pen)
            {
                StartPoint = new Point(e.X, e.Y),
                EndPoint = new Point(e.X, e.Y)
            });
            //Invalidate(); // force redraw shapes
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawingLine = false;
            this.shapes[this.shapes.Count - 1].EndPoint = new Point(e.X, e.Y);
            this.Invalidate();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawingLine == false) return;
            this.shapes[this.shapes.Count - 1].EndPoint = new Point(e.X, e.Y);
            this.Invalidate();
        }

        //private void Form1_Paint(object sender, PaintEventArgs e)
        //{
        //    foreach (Shape shape in shapes) shape.Draw(e.Graphics);
        //}

        //private void button4_Click(object sender, EventArgs e)
        //{

        //}
    }
}
