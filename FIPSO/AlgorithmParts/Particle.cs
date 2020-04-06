using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIPSO.AlgorithmParts
{
    class Particle
    {
        public Vector2d Velocity { get; set; }
        public double Mass { get; set; }
        public double Charge { get; set; }
        public Vector2d Position { get; set; }
        public Vector2d PersonalBest { get; set; }

        public Particle(Vector2d velocity, float mass)
        {
            Velocity = velocity;
            Mass = mass;
        }
    }
}
