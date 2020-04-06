using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace FIPSO
{
    class Vector2d
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Lenght { get { return Sqrt(Pow(X, 2) + Pow(Y, 2)); } }

        public Vector2d(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void Scale(double length)
        {
            throw new NotImplementedException();
        }

        public Vector2d Normalize()
        {
            double d = Lenght;
            if (d == 0)
                throw new ArgumentException("Vector of 0 length");
            return new Vector2d(X / d, Y / d);
        }

        public static Vector2d operator*(double a, Vector2d v)
        {
            return new Vector2d(a * v.X, a * v.Y);
        }

        public static Vector2d operator+(Vector2d v1, Vector2d v2)
        {
            return new Vector2d(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector2d operator -(Vector2d v1, Vector2d v2)
        {
            return v1 + (-1 * v2);
        }
    }
}
