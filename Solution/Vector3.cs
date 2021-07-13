using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class Vector3
    {
        private float[] values;

        public Vector3(float x, float y, float z)
        {
            values = new float[3];

            values[0] = x;
            values[1] = y;
            values[2] = z;
        }

        public Vector3(Vector4 v): this (v.X, v.Y, v.Z) { }

        public float X
        {
            get
            {
                return values[0];
            }
            set
            {
                values[0] = value;
            }
        }

        public float Y
        {
            get
            {
                return values[1];
            }
            set
            {
                values[1] = value;
            }
        }

        public float Z
        {
            get
            {
                return values[2];
            }
            set
            {
                values[2] = value;
            }
        }

        public float this[int i]
        {
            get
            {
                return values[i];
            }
            set
            {
                values[i] = value;
            }
        }
    }
}
