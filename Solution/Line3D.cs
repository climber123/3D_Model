using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class Line3D : IModel
    {
        List<Vector3> vertices;

        public Line3D(List<Vector3> v)
        {
            vertices = v;
        }

        public List<PolyLine3D> GetLines()
        {
            return new List<PolyLine3D>()
            {
                new PolyLine3D(vertices)
            };
        }
    }
}
