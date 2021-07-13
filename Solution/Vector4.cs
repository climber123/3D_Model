using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class Vector4
    {
        public float[] values;

        public Vector4(float x, float y, float z, float w = 1)
        {
            values = new float[4];
            values[0] = x;
            values[1] = y;
            values[2] = z;
            values[3] = w;
        }

        public Vector4(Vector3 v): this (v.X, v.Y, v.Z) { }

        public float X
        {
            get { return values[0]; }
            set { values[0] = value; }
        }
        public float Y
        {
            get { return values[1]; }
            set { values[1] = value; }
        }
        public float Z
        {
            get { return values[2]; }
            set { values[2] = value; }
        }
        public float W
        {
            get { return values[3]; }
            set { values[3] = value; }
        }

        public float this[int i]
        {
            get { return values[i]; }
            set { values[i] = value; }
        }

        public Vector4 Normalized
        {
            get
            {
                return (W == 0) ? new Vector4(X, Y, Z, W) : new Vector4(X / W, Y / W, Z / W, 1);
            }
        }
    }
}
