using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class Matrix
    {
        public float[,] matrix;

        public Matrix(float[,] a)
        {
            if (a.Length < 16)
                throw new Exception();

            matrix = new float[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    matrix[i, j] = a[i, j];
        }

        public float this[int i, int j]
        {
            get
            {
                return matrix[i, j];
            }
            set
            {
                matrix[i, j] = value;
            }
        }

        public static Matrix ZeroMatrix()
        {
            float[,] m = new float[4, 4];

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    m[i, j] = 0;

            return new Matrix(m);
        }

        public static Matrix OneMatrix()
        {
            float[,] m = new float[4, 4];

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    m[i, j] = (i == j) ? 1 : 0;

            return new Matrix(m);
        }

        public static Vector4 operator *(Matrix m, Vector4 v)
        {
            Vector4 r = new Vector4(0, 0, 0, 0);
            for (int i = 0; i < 4; i++)
            {
                r[i] = 0;
                for (int j = 0; j < 4; j++)
                    r[i] += m[i, j] * v[j];
            }
            return r;
        }
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            Matrix m = ZeroMatrix();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    for (int k = 0; k < 4; k++)
                        m[i, j] += m1[i, k] * m2[k, j];
            return m;
        }

        public static Matrix Translate(int dx, int  dy, int dz) // матрица переноса
        {
            Matrix m = OneMatrix();
            m[0, 3] = dx;
            m[1, 3] = dy;
            m[2, 3] = dz;

            return m;
        }

        public static Matrix Rotation(int axis, float angle)
        {
            Matrix m = OneMatrix();

            int r1 = (axis + 1) % 3;
            int r2 = (axis + 2) % 3;

            m[r1, r1] = (float)Math.Cos(angle);
            m[r1, r2] = (float)-Math.Sin(angle);
            m[r2, r1] = (float)Math.Sin(angle);
            m[r2, r2] = (float)Math.Cos(angle);

            return m;
        }
    }
}
