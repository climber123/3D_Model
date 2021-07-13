using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Solution
{
    public class Scene
    {
        public List<IModel> Models = new List<IModel>();

        public Bitmap DrawScene(Screen s, Camera c)
        {
            Bitmap btm = new Bitmap(s.Size.Width, s.Size.Height);
            Graphics g = Graphics.FromImage(btm);
            List<PolyLine3D> lines = new List<PolyLine3D>();
            foreach (var m in Models)
                foreach (var pl in m.GetLines())
                {
                    var p = new PolyLine3D(pl.Vertices.ConvertAll(a => c.Convert(a)), false);
                    lines.Add(p);
                }
            lines.Sort(new Comparison<PolyLine3D>((a, b) => { return (int)(a.Vertices.Average(x => x.Z)); }));
            foreach (PolyLine3D pl in lines)
            {
                List<Point> points = new List<Point>();
                foreach (Vector3 v in pl.Vertices)
                {
                    points.Add(s.Convert(v));
                }
                g.FillPolygon(Brushes.Red, points.ToArray());
                g.DrawLines(Pens.Black, points.ToArray());

            }
            g.Dispose();
            return btm;
        }
    }
}
