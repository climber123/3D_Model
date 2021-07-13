using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class Camera
    {
        public Matrix View { get; set; }
        public Matrix Projection { get; set; }

        public Camera()
        {
            View = Matrix.OneMatrix();
            Projection = Matrix.OneMatrix();
        }

        public Vector3 Convert(Vector3 v)
        {
            return new Vector3((Projection * View * new Vector4(v)).Normalized);
        }
    }
}
