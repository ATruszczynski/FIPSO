using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FIPSO
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector2 velocity = new Vector2(10, 10);
            velocity = (2 * velocity + new Vector2(2, 2.5f));
            Console.WriteLine($"{velocity.X} {velocity.Y}");
        }
    }
}
