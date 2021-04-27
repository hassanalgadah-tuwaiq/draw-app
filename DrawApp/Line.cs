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
            context.DrawLine(this.Pen,
                StartPoint.X, EndPoint.X
                , StartPoint.Y, StartPoint.Y
                );
        }
    }
}
