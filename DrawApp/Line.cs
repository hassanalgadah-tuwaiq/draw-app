using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawApp
{
    public class Line : Shape
    {
        public Line(Pen pen) : base(pen)
        {
        }

        public override void Draw(Graphics context)
        {
            //// Create pen.
            //Pen blackPen = new Pen(Color.Black, 3);

            //// Create points that define line.
            //PointF point1 = new PointF(100.0F, 100.0F);
            //PointF point2 = new PointF(500.0F, 100.0F);

            //// Draw line to screen.
            //context.DrawLine(blackPen, point1, point2);

            context.DrawLine(this.Pen,
                StartPoint.X, EndPoint.X
                , StartPoint.Y, StartPoint.Y
                );
        }
    }
}
