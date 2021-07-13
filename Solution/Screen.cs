using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Solution
{
    public class Screen
    {
        public Size Size { get; set; }
        public RectangleF Rectangle { get; set; }

        public Screen(Size s, RectangleF r)
        {
            Size = s;
            Rectangle = r;
        }

        public Point Convert(Vector3 v )
        {
            float x = (v.X - Rectangle.X) / Rectangle.Width * Size.Width;
            float y = (-Rectangle.Y + v.Y) / Rectangle.Height * Size.Height;

            return new Point((int)x, (int)y);
        }
    }
}
